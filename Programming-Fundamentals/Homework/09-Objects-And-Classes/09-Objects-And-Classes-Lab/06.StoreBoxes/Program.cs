using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    internal class Program
    {
        internal class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public Item(string name, double price)
            {
                Name = name;
                Price = price;
            }
        }

        internal class Box
        {
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public double Price => ItemQuantity * Item.Price;

            public Box(string serialNumber, Item item, int itemQuantity)
            {
                SerialNumber = serialNumber;
                Item = item;
                ItemQuantity = itemQuantity;
            }

            public new string ToString() => $"{SerialNumber}\n" +
                                            $"-- {Item.Name} - ${Item.Price:f2}: {ItemQuantity}\n" +
                                            $"-- ${Price:f2}";
        }

        static void Main(string[] args)
        {
            List<Box> list = new List<Box>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] boxInfo = input.Split();
                list.Add(new Box(boxInfo[0], new Item(boxInfo[1], double.Parse(boxInfo[3])), int.Parse(boxInfo[2])));

                input = Console.ReadLine();
            }

            list.Sort((box1, box2) => -box1.Price.CompareTo(box2.Price));
            list.ForEach(box => Console.WriteLine(box.ToString()));
        }
    }
}
