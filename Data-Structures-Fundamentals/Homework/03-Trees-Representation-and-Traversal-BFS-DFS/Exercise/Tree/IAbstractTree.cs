namespace Tree
{
    using System.Collections.Generic;

    public interface IAbstractTree<T>
    {
        T Key { get; }
        IReadOnlyCollection<Tree<T>> Children { get; }

        void AddParent(Tree<T> parent);

        void AddChild(Tree<T> child);

        string GetAsString();

        List<T> GetLeafKeys();

        List<T> GetInternalKeys();

        T GetDeepestKey();

        List<T> GetLongestPath();
    }
}
