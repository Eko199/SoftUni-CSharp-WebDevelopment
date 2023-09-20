namespace Tree
{
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private readonly Dictionary<int, IntegerTree> nodesByKey;

        public TreeFactory()
        {
            nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (string pair in input)
            {
                int[] pairInt = pair.Split().Select(int.Parse).ToArray();

                CreateNodeByKey(pairInt[0]);
                CreateNodeByKey(pairInt[1]);

                AddEdge(pairInt[0], pairInt[1]);
            }

            return GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!nodesByKey.ContainsKey(key))
            {
                nodesByKey[key] = new IntegerTree(key);
            }

            return nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            nodesByKey[parent].AddChild(nodesByKey[child]);
            nodesByKey[child].AddParent(nodesByKey[parent]);
        }

        public IntegerTree GetRoot() 
            => nodesByKey.Single(keyTree => keyTree.Value.Parent == null).Value;
    }
}
