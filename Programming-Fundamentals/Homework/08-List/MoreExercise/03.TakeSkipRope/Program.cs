using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.TakeSkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> stringList = Console.ReadLine().ToList();
            List<int> takeList = stringList.Where(c => char.IsDigit(c)).Select(c => c - '0').ToList();
            stringList.RemoveAll(c => char.IsDigit(c));

            List<int> skipList = takeList.Where((x, index) => index % 2 == 1).ToList();
            takeList = takeList.Where((x, index) => index % 2 == 0).ToList();

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < skipList.Count; i++)
            {
                stringBuilder.Append(string.Join("", stringList.Take(takeList[i])));
                stringList.RemoveRange(0, Math.Min(skipList[i] + takeList[i], stringList.Count));
            }

            Console.WriteLine(stringBuilder);
        }
    }
}
