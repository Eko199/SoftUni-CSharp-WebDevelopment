namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {

            var tree = new Tree<int>(2, new Tree<int>(3, new Tree<int>(11)), new Tree<int>(4));
            tree.Swap(11, 3);
            Console.WriteLine(string.Join(", ", tree.OrderDfs()));
        }
    }
}
