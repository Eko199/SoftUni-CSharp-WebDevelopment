using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            var instancesStack = new Stack<string>(new string[] {string.Empty});

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                switch (commands[0])
                {
                    case "1":
                        sb.Append(commands[1]);
                        instancesStack.Push(sb.ToString());
                        break;
                    case "2":
                        int count = int.Parse(commands[1]);
                        sb.Remove(sb.Length - count, count);
                        instancesStack.Push(sb.ToString());
                        break;
                    case "3":
                        Console.WriteLine(sb[int.Parse(commands[1]) - 1]);
                        break;
                    case "4":
                        instancesStack.Pop();
                        sb = new StringBuilder(instancesStack.Peek());
                        break;
                }
            }
        }
    }
}
