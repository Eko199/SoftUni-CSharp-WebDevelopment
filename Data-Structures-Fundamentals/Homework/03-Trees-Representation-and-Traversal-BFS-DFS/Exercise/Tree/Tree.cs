namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this.children = new List<Tree<T>>(children.Length * 2);

            foreach (Tree<T> child in children)
            {
                AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();

        public void AddChild(Tree<T> child) => children.Add(child);

        public void AddParent(Tree<T> parent) => Parent = parent;

        public string GetAsString()
        {
            var sb = new StringBuilder();
            DfsTreeAsString(sb, 0);

            return sb.ToString().Trim();
        }

        public List<T> GetInternalKeys() 
            => FindNodesWithDfs(tree => tree.Children.Any() && tree.Parent != null)
                .Select(tree => tree.Key)
                .ToList();

        public List<T> GetLeafKeys() 
            => GetLeafNodes().Select(tree => tree.Key).ToList();

        public T GetDeepestKey() => GetDeepestNode().Key;

        public List<T> GetLongestPath()
        {
            Tree<T> node = GetDeepestNode();
            var path = new List<T>();

            while (node != null)
            {
                path.Add(node.Key);
                node = node.Parent;
            }

            path.Reverse();
            return path;
        }

        protected IEnumerable<Tree<T>> GetLeafNodes()
            => FindNodesWithDfs(tree => tree.children.Count == 0);

        protected Tree<T> GetDeepestNode()
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            Tree<T> deepestTree = this;

            while (queue.Count > 0)
            {
                deepestTree = queue.Dequeue();

                for (int i = deepestTree.children.Count - 1; i >= 0; i--)
                {
                    queue.Enqueue(deepestTree.children[i]);
                }
            }

            return deepestTree;
        }

        private void DfsTreeAsString(StringBuilder sb, int ident)
        {
            sb.Append(' ', ident * 2)
                .AppendLine(Key.ToString());

            foreach (Tree<T> child in children)
            {
                child.DfsTreeAsString(sb, ident + 1);
            }
        }

        private IEnumerable<Tree<T>> FindNodesWithDfs(Predicate<Tree<T>> predicate)
        {
            var result = new List<Tree<T>>();
            DfsPredicate(predicate, result);

            return result;
        }

        private void DfsPredicate(Predicate<Tree<T>> predicate, IList<Tree<T>> result)
        {
            foreach (Tree<T> child in children)
            {
                child.DfsPredicate(predicate, result);
            }

            if (predicate.Invoke(this))
                result.Add(this);
        }
    }
}
