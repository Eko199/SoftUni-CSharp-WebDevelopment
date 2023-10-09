using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var heap = new OrderedBag<int>();
            int steps = 0;

            foreach (int cookie in cookies)
            {
                heap.Add(cookie);
            }

            while (heap.Count > 1)
            {
                if (heap.GetFirst() > minSweetness)
                {
                    break;
                }

                int first = heap.RemoveFirst();
                int second = heap.RemoveFirst();

                heap.Add(first + 2 * second);
                steps++;
            }

            return heap.Count == 1 && heap.GetFirst() < minSweetness ? -1 : steps;
        }
    }
}
