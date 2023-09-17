namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private Tree<T> parent;
        private readonly IList<Tree<T>> children;

        public Tree(T value)
        {
            this.value = value;
            children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> node = FindNodeWithDfs(parentKey) 
                            ?? throw new ArgumentNullException(nameof(parentKey), "Not such tree found.");

            child.parent = node;
            node.children.Add(child);
        }

        public IEnumerable<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                result.Add(node.value);

                foreach (Tree<T> child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result = new List<T>();
            Dfs(result);
            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> node = FindNodeWithDfs(nodeKey)
                           ?? throw new ArgumentNullException(nameof(nodeKey), "Not such tree found.");

            Tree<T> nodeParent = node.parent 
                                 ?? throw new ArgumentException("Can't remove root of the tree.");

            nodeParent.children.Remove(node);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = FindNodeWithDfs(firstKey);
            Tree<T> secondNode = FindNodeWithDfs(secondKey);

            if (firstNode is null || secondNode is null)
                throw new ArgumentNullException();

            Tree<T> firstParent = firstNode.parent;
            Tree<T> secondParent = secondNode.parent;

            if (firstParent is null || secondParent is null)
                throw new ArgumentException("Cannot swap root.");

            int firstIndex = firstParent.children.IndexOf(firstNode);
            int secondIndex = secondParent.children.IndexOf(secondNode);

            firstParent.children[firstIndex] = secondNode;
            secondNode.parent = firstParent;

            secondParent.children[secondIndex] = firstNode;
            firstNode.parent = secondParent;
        }

        private void Dfs(ICollection<T> result)
        {
            foreach (Tree<T> child in children)
            {
                child.Dfs(result);
            }

            result.Add(value);
        }

        private Tree<T> FindNodeWithDfs(T key)
        {
            foreach (Tree<T> child in children)
            {
                Tree<T> result = child.FindNodeWithDfs(key);

                if (result != null)
                    return result;
            }

            return value.Equals(key) ? this : null;
        }
    }
}
