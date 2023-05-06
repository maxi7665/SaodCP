using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SaodCP.DataStructures
{
    public partial class Tree<T, O>
    {
        /// <summary>
        /// Балансировка дерева
        /// </summary>
        /// <param name="head"></param>
        /// <returns>Новая вершина поддерева</returns>
        private TreeNode<T, O> Rebalance(TreeNode<T, O> head)
        {
            // надо ли вообще выполнять поворот
            if (head.Diff != 2
                && head.Diff != -2)
            {
                return head;
            }

            var a = head;

            // левый поворот
            if (a.Diff == 2)
            {
                var b = head.Left;

                if (b == null)
                {
                    return head;
                }

                if (b.Diff == 1
                    || b.Diff == 0)
                {
                    return RotateLeft(head);
                }
                else if (b.Diff == -1)
                {

                    var c = b.Right;

                    if (c == null)
                    {
                        return head;
                    }

                    return BigRotateLeft(head);
                }
            }

            // правый поворот
            if (a.Diff == -2)
            {
                var b = head.Right;

                if (b == null)
                {
                    return head;
                }

                if (b.Diff == -1
                    || b.Diff == 0)
                {
                    return RotateRight(head);
                }
                else if (b.Diff == 1)
                {
                    var c = b.Left;

                    if (c == null)
                    {
                        return head;
                    }

                    return BigRotateRight(head);
                }
            }

            throw new ApplicationException("Tree Internal error");
        }

        /// <summary>
        /// левый поворот
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private TreeNode<T, O> RotateLeft(TreeNode<T, O> b)
        {
            TreeNode<T, O> a = b.Left ?? throw new NullReferenceException();

            b.Left = a.Right;

            a.Right = b;

            b.UpdateDimensions();
            a.UpdateDimensions();

            return a;
        }

        /// <summary>
        /// правый поворот
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private TreeNode<T, O> RotateRight(TreeNode<T, O> b)
        {
            TreeNode<T,O> a = b.Right ?? throw new NullReferenceException();

            b.Right = a.Left;

            a.Left = b;

            b.UpdateDimensions();
            a.UpdateDimensions();

            return a;
        }

        /// <summary>
        /// большой левый поворот
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        private TreeNode<T, O> BigRotateLeft(TreeNode<T, O> a)
        {
            a.Left = RotateRight(a.Left ?? throw new NullReferenceException());
            return RotateLeft(a);
        }

        /// <summary>
        /// большой правый поворот
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        private TreeNode<T, O> BigRotateRight(TreeNode<T, O> a)
        {
            a.Right = RotateLeft(a.Right ?? throw new NullReferenceException());
            return RotateRight(a);
        }
    }
}
