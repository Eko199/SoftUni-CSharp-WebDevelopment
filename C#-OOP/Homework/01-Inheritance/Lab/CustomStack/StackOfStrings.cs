using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => Count == 0;

        public Stack<string> AddRange(ICollection<string> range)
        {
            foreach (string str in range)
            {
                Push(str);
            }

            return this;
        }
    }
}
