using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaodCP.DataStructures
{
    public class Tree<T, O>
    {
        private TreeNode<T, O>? head = null;

        private Comparison<T> _comparison;

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
        public void Add(T key, O value)
        { 
            var node = new TreeNode<T, O>(key, value);

            if (head == null)
            {
                head = node;

                return;
            }

            RecursiveAdd(head, node);
        }

        private void RecursiveAdd(
            TreeNode<T, O> parent, 
            TreeNode<T, O> addNode)
        {
            var cmp = _comparison(parent.Key, addNode.Key);

            if (cmp > 0)
            {
                if (parent.Left != null)
                {
                    RecursiveAdd(parent.Left, addNode);

                    return;
                }
                else
                {
                    parent.Left = addNode;
                }
            }
            else if (cmp < 0)
            {
                if (parent.Right != null)
                {
                    RecursiveAdd(parent.Right, addNode);

                    return;
                }
                else
                {
                    parent.Right = addNode;
                }
            }
            else
            {
                parent.Value = addNode.Value;
            }
        }

        // найти и удалить
        private bool FindAndRemove(
            TreeNode<T, O> parent,
            T key)
        {
            var cmp = _comparison(parent.Key, key);

            if (cmp == 0)
            {
                throw new ApplicationException("Tree internal error");
            }

            // ключ меньше чем ключ родителя
            // необходимо сравнить с левым потомком
            if (cmp > 0)
            {
                if (parent.Left == null)
                {
                    return false;
                }

                var leftCmp = _comparison(parent.Left.Key, key);

                if (leftCmp == 0)
                {
                    // todo
                    //parent.Left = Delete();
                }
                else
                {
                    // ищем значение для удаления в левом поддереве
                    return FindAndRemove(parent.Left, key);
                }
            }
            else
            {
                if (parent.Right == null)
                {
                    return false;
                }

                var rightCmp = _comparison(parent.Right.Key, key);

                if (rightCmp == 0)
                {
                    // todo
                    //parent.Right = Delete();
                }
                else
                {
                    // ищем значение для удаления в правом поддереве
                    return FindAndRemove(parent.Right, key);
                }
            }
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
