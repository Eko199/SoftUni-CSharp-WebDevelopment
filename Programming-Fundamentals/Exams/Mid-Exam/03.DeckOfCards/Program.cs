using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine().Split(", ").ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");

                switch (tokens[0])
                {
                    case "Add":
                        if (!deck.Contains(tokens[1]))
                        {
                            deck.Add(tokens[1]);
                            Console.WriteLine("Card successfully added");
                        }
                        else
                            Console.WriteLine("Card is already in the deck");
                        break;
                    case "Remove":
                        if (deck.Contains(tokens[1]))
                        {
                            deck.Remove(tokens[1]);
                            Console.WriteLine("Card successfully removed");
                        }
                        else
                            Console.WriteLine("Card not found");
                        break;
                    case "Remove At":
                        int index1 = int.Parse(tokens[1]);
                        if (IsIndexValid(index1, deck))
                        {
                            deck.RemoveAt(index1);
                            Console.WriteLine("Card successfully removed");
                        }
                        else
                            Console.WriteLine("Index out of range");
                        break;
                    case "Insert":
                        int index2 = int.Parse(tokens[1]);
                        if (IsIndexValid(index2, deck))
                        {
                            if (deck.Contains(tokens[2]))
                                Console.WriteLine("Card is already added");
                            else
                            {
                                deck.Insert(index2, tokens[2]);
                                Console.WriteLine("Card successfully added");
                            }
                        }
                        else
                            Console.WriteLine("Index out of range");
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", deck));
        }

        private static bool IsIndexValid(int index, ICollection<string> list) => index >= 0 && index < list.Count;
    }
}
