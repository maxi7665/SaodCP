using System.Drawing.Design;
using System.Net.Sockets;

namespace SaodCP.DataStructures
{
    public partial class Tree<T, O>
    {
        private TreeNode<T, O>? head = null;

        private Comparison<T> _comparison;

        public int Count { get; private set; } = 0;

        public Tree()
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new ApplicationException(
                    $"{nameof(T)} is not IComparable and Comparison<{nameof(T)}> was not provided");
            }

            _comparison = (first, second) => ((IComparable)first).CompareTo(second);
        }

        public Tree(Comparison<T> comparison)
        {
            _comparison = comparison;
        }

        /// <summary>
        /// Добавить пару ключ-значение
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(T key, O? value = default)
        { 
            var node = new TreeNode<T, O>(key, value);

            if (head == null)
            {
                head = node;

                Count = 1;

                return;
            }

            head = RecursiveAdd(head, node);
        }

        private TreeNode<T, O> RecursiveAdd(
            TreeNode<T, O> parent, 
            TreeNode<T, O> addNode)
        {
            var cmp = _comparison(parent.Key, addNode.Key);

            if (cmp > 0)
            {
                if (parent.Left != null)
                {
                    parent.Left = RecursiveAdd(parent.Left, addNode);
                }
                else
                {
                    parent.Left = addNode;

                    Count++;
                }

                parent.UpdateDimensions();

                if (parent.Diff >= 2
                    || parent.Diff <= -2)
                {
                    parent = Rebalance(parent);
                }

                return parent;
            }
            else if (cmp < 0)
            {
                if (parent.Right != null)
                {
                    parent.Right = RecursiveAdd(parent.Right, addNode);
                }
                else
                {
                    parent.Right = addNode;

                    Count++;
                }

                parent.UpdateDimensions();

                if (parent.Diff >= 2
                    || parent.Diff <= -2)
                {
                    parent = Rebalance(parent);
                }

                return parent;
            }
            else
            {
                parent.Value = addNode.Value;

                parent.UpdateDimensions();

                return parent;
            }
        }

        public bool Remove(T key)
        {
            if (head == null)
            {
                return false;
            }

            bool ret = false;

            head = DeleteNode(head, key, ref ret);

            if (ret)
            {
                Count--;
            }

            return ret;
        }

        private TreeNode<T, O>? DeleteNode(
            TreeNode<T, O> currentNode,
            T itemValue)
        {
            bool stackBool = false;

            return DeleteNode(currentNode, itemValue, ref stackBool);
        }

        // найти и удалить
        private TreeNode<T,O>? DeleteNode(
            TreeNode<T,O> currentNode, 
            T itemValue, 
            ref bool result)
        {
            result = true;

            var cmp = _comparison(currentNode.Key, itemValue);

            // если нашли нужный элемент, начинаем процедуру удаления
            if (cmp == 0)
            {
                // обработка самого простого случая, вместо узла возвращается null
                if (currentNode.Left == null
                    && currentNode.Right == null)
                {
                    return null;
                }

                // обработка двух случаев, с только одним из поддеревьев
                if (currentNode.Left == null)
                {
                    return currentNode.Right;
                }

                if (currentNode.Right == null)
                {
                    return currentNode.Left;
                }

                // если у ноды есть оба потомка
                var minNodeInRightSubtree = FindMinNode(currentNode.Right);
                // заменили текущий элемент минимальным из правого поддерева
                currentNode.Value = minNodeInRightSubtree.Value;
                currentNode.Key = minNodeInRightSubtree.Key;

                // ищем в правом поддереве минимальный элемент,
                // значение которого уже вставлено на место текущего
                currentNode.Right = DeleteNode(
                  currentNode.Right,
                  minNodeInRightSubtree.Key);

                return currentNode;
            }  

            // попадаем сюда, если элемент не был найден,
            // просто проваливаемся в дерево глубже и глубже

            // производится рекурсивный вызов этой же функции,
            // при этом если элемент не будет найден,
            // то алгоритм просто будет возвращать существующую ссылку на поддерево,
            // которая присвоится в ту же позицию
            if (cmp > 0)
            {
                if (currentNode.Left == null)
                {
                    result = false;

                    return currentNode;
                }

                // проваливаемся в левое поддерево,
                // после рекурсивной отработки функции _deleteNode
                // будет возвращен текущий элемент,
                // который в предыдущем вызове будет присвоен
                currentNode.Left = DeleteNode(
                    currentNode.Left, 
                    itemValue,
                    ref result);

                // если нового ребенка после удаления надо балансировать, балансируем
                if (currentNode.Left != null)
                {
                    if (currentNode.Left.Diff == 2
                        || currentNode.Left.Diff == -2)
                    {
                        currentNode.Left = Rebalance(currentNode.Left);
                    }
                }

                // обновление параметров
                currentNode.UpdateDimensions();

                // присваивание на рекурсивный уровень выше,
                // может быть как в левое поддерево,так и в правое,
                // на текущем уровне мы не знаем какое поддерево обрабатываем
                return currentNode;
            }

            // аналогичная обработка для правого поддерева
            if (cmp < 0)
            {
                if (currentNode.Right == null)
                {
                    result = false;

                    return currentNode;
                }

                currentNode.Right = DeleteNode(
                    currentNode.Right, 
                    itemValue,
                    ref result);

                // если ребенка после удаления надо балансировать, балансируем
                if (currentNode.Right != null)
                {
                    if (currentNode.Right.Diff == 2
                        || currentNode.Right.Diff == -2)
                    {
                        currentNode.Right = Rebalance(currentNode.Right);
                    }
                }

                currentNode.UpdateDimensions();

                return currentNode;
            }

            throw new ApplicationException("Delete Element error");
        }

        private TreeNode<T,O> FindMinNode(TreeNode<T, O> node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return FindMinNode(node.Left);
        }

        /// <summary>
        /// Найти значение по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public O? Find(T key)
        {
            if (head == null)
            {
                return default;
            }

            return RecursiveFind(head, key);
        }

        private O? RecursiveFind(TreeNode<T,O> parent, T key)
        {
            var cmp = _comparison(parent.Key, key);

            if (cmp == 0)
            {
                return parent.Value;
            }
            else if (cmp > 0)
            {
                if (parent.Left == null)
                {
                    return default;
                }

                return RecursiveFind(parent.Left, key);
            }
            else
            {
                if (parent.Right == null)
                {
                    return default;
                }
                
                return RecursiveFind(parent.Right, key);
            }
        }
    }
}
