using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(" ", 
            //    Console.ReadLine()
            //    .Split('|')
            //    .Reverse()
            //    .Select(arr =>
            //        string.Join(" ", 
            //            arr.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //                .Select(int.Parse)))));

            var list = Console.ReadLine()
                .Split('|')
                .Reverse().ToList();
            var numbers1 = new List<int>();
            foreach (var number in list)
            {
                numbers1.AddRange(number.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            var numbers2 = list.Select(arr =>
                string.Join(" ",
                    arr.Split(' ', StringSplitOptions.RemoveEmptyEntries))).ToList();

            var str1 = string.Join(" ", numbers1);
            var str2 = string.Join(" ", numbers2);
            Console.WriteLine(str1);
            //Console.WriteLine(str2);
            //Console.WriteLine(str1 == str2);
        }
    }
}
