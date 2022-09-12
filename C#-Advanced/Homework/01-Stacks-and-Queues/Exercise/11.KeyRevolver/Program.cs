using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            var bulletsSizeStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locksSizeQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligenceValue = int.Parse(Console.ReadLine());

            int loadedBullets = gunBarrelSize;
            while (bulletsSizeStack.Count > 0 && locksSizeQueue.Count > 0)
            {
                if (bulletsSizeStack.Pop() <= locksSizeQueue.Peek())
                {
                    locksSizeQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                    Console.WriteLine("Ping!");

                loadedBullets--;
                if (loadedBullets == 0 && bulletsSizeStack.Count > 0)
                {
                    loadedBullets += Math.Min(bulletsSizeStack.Count, gunBarrelSize);
                    Console.WriteLine("Reloading!");
                }

                intelligenceValue -= bulletPrice;
            }

            Console.WriteLine(locksSizeQueue.Count > 0
                ? $"Couldn't get through. Locks left: {locksSizeQueue.Count}"
                : $"{bulletsSizeStack.Count} bullets left. Earned ${intelligenceValue}");

        }
    }
}
