using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cupsQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var bottlesStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedWater = 0, currentCup = cupsQueue.Dequeue();

            while (bottlesStack.Count > 0 && currentCup > 0)
            {
                currentCup -= bottlesStack.Pop();

                if (currentCup > 0) continue;

                wastedWater += Math.Abs(currentCup);

                if (cupsQueue.Count > 0)
                    currentCup = cupsQueue.Dequeue();
            }

            if (currentCup > 0)
            {
                var temp = new Queue<int>(cupsQueue);
                cupsQueue.Clear();
                cupsQueue.Enqueue(currentCup);

                while (temp.Count > 0)
                {
                    cupsQueue.Enqueue(temp.Dequeue());
                }
            }

            Console.WriteLine(cupsQueue.Count == 0 ? "Bottles: " + string.Join(" ", bottlesStack) : "Cups: " + string.Join(" ", cupsQueue));
            Console.WriteLine("Wasted litters of water: " + wastedWater);
        }
    }
}
