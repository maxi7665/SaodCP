using System.Collections;

namespace SaodCP.DataStructures
{
    /// <summary>
    /// Реализация IEnumerable для Tree, чтобы было удобно использовать
    /// Используется прямой обход дерева (вершина, левый, правый)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="O"></typeparam>
    public partial class Tree<T, O> : IEnumerable<KeyValuePair<T, O>>
    {       
        /// <summary>
        /// Получить Enumerator (обход дерева в прямом порядке)
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<T, O>> GetEnumerator()
        {
            var pairs = new List<KeyValuePair<T, O>>();

            var node = head;

            AddToList(node);

            void AddToList(TreeNode<T,O>? node)
            {
                if (node == null)
                {
                    return;
                }

                pairs.Add(new(node.Key, node.Value));

                AddToList(node.Left);
                AddToList(node.Right);
            }

            return pairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
