namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 == 1) 
                return false;

            var stack = new Stack<char>(parentheses.Length);

            foreach (char parenthesis in parentheses)
            {
                char opposite = parenthesis switch
                {
                    ')' => '(',
                    ']' => '[',
                    '}' => '{',
                    _ => default
                };

                if (opposite == default)
                {
                    stack.Push(parenthesis);
                } 
                else if (stack.Pop() != opposite)
                {
                    return false;
                }
            }

            return !stack.Any();
        }
    }
}
