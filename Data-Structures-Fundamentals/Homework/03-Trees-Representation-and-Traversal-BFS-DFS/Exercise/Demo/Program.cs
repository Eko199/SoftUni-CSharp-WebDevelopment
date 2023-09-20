namespace Demo
{
    using System;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            IntegerTree tree = new TreeFactory().CreateTreeFromStrings(new[] { "7 19", "7 21", "7 14", "19 1", "19 12" });
            Console.WriteLine(tree.GetDeepestKey());
        }
    }
}
