namespace Tree
{
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        { }

        public List<List<int>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();
            GetPathsWithGivenSumRecursive(this, sum, new Stack<Tree<int>>(), result);

            return result;
        }

        public List<Tree<int>> SubTreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();
            GetSubtreesWithGivenSumRecursive(this, sum, result);

            return result;
        }

        public Tree<int> GetDeepestLeftomostNode() => GetDeepestNode();

        public List<int> GetMiddleKeys() => GetInternalKeys();

        private static void GetPathsWithGivenSumRecursive(Tree<int> tree, int sum, Stack<Tree<int>> path, ICollection<List<int>> result)
        {
            path.Push(tree);

            foreach (Tree<int> child in tree.Children)
            {
                GetPathsWithGivenSumRecursive(child, sum - tree.Key, path, result);
            }

            if (!tree.Children.Any() && sum == tree.Key)
            {
                var pathList = path.ToList();
                pathList.Reverse();
                result.Add(pathList.Select(t => t.Key).ToList());
            }

            path.Pop();
        }

        private static int GetSubtreesWithGivenSumRecursive(Tree<int> tree, int sum, ICollection<Tree<int>> result)
        {
            int currentSum = tree.Key + tree.Children.Sum(child => GetSubtreesWithGivenSumRecursive(child, sum, result));

            if (currentSum == sum)
                result.Add(tree);

            return currentSum;
        }
    }
}
