using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            var openingStack = new Stack<char>();
            bool valid = true;

            foreach (char c in sequence)
            {
                if (c == '{' || c == '[' || c == '(')
                    openingStack.Push(c);
                else if (openingStack.Count == 0)
                {
                    valid = false;
                    break;
                }
                else if (c == ClosingParenthesis(openingStack.Peek()))
                    openingStack.Pop();
                else
                {
                    valid = false;
                    break;
                }
            }

            Console.WriteLine(valid && openingStack.Count == 0 ? "YES" : "NO");
        }

        static char ClosingParenthesis(char opening) => opening switch
        {
            '{' => '}',
            '[' => ']',
            '(' => ')'
        };
    }
}
