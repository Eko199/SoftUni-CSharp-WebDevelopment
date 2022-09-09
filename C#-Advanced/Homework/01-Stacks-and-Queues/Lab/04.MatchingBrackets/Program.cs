using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            var openingBracketsStack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] =='(')
                    openingBracketsStack.Push(i);
                else if (expression[i] == ')')
                {
                    int startIndex = openingBracketsStack.Pop();
                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
