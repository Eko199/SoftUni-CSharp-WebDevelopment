using System;
using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    internal class Lake : IEnumerable<int>
    {
        private readonly int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i += 2)
                yield return stones[i];
            for (int i = stones.Length - 1 - stones.Length % 2; i >= 1; i -= 2)
                yield return stones[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
