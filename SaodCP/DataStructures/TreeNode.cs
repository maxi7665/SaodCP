using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaodCP.DataStructures
{
    /// <summary>
    /// Узел дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T,O>
    {
        public T Key { get; set; }
        public O Value { get; set; }

        public TreeNode(T key, O value)
        {
            Key = key;
            Value = value;
        }

        public TreeNode<T, O>? Left { get; set; } = null;
        public TreeNode<T, O>? Right { get; set; } = null;

        public int GetDepth()
        {
            int rightDepth = Right?.GetDepth() ?? 0;
            int leftDepth = Left?.GetDepth() ?? 0;

            int max = rightDepth > leftDepth ? rightDepth : leftDepth;

            return max + 1;
        }
    }
}
