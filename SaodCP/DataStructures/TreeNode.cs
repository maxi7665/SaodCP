namespace SaodCP.DataStructures
{
    /// <summary>
    /// Узел дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T, O>
    {
        public T Key { get; set; }
        public O? Value { get; set; }

        public TreeNode(T key, O? value)
        {
            Key = key;
            Value = value;
        }

        public TreeNode<T, O>? Left { get; set; } = null;
        public TreeNode<T, O>? Right { get; set; } = null;

        /// <summary>
        /// Разница между высотой левого и правого поддерева
        /// </summary>
        public int Diff { get => GetDiff(); }

        /// <summary>
        /// Глубина поддерева
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Обновить глубину поддерева
        /// </summary>
        public void UpdateDepth()
        {
            int rightDepth = Right?.Depth + 1 ?? 0;
            int leftDepth = Left?.Depth + 1 ?? 0;

            int max = rightDepth > leftDepth ? rightDepth : leftDepth;

            Depth = max;
        }

        /// <summary>
        /// Обновить разность 
        /// глубин поддеревьев
        /// </summary>
        public int GetDiff()
        {
            int rightDepth = Right?.Depth + 1 ?? 0;
            int leftDepth = Left?.Depth + 1 ?? 0;

            return leftDepth - rightDepth;
        }

        /// <summary>
        /// Обновить измерения узла
        /// </summary>
        public void UpdateDimensions()
        {
            UpdateDepth();
        }
    }
}
