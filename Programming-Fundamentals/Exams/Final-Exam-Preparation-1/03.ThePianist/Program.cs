using System;
using System.Collections.Generic;

namespace _03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pieces = new Dictionary<string, (string, string)>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('|');
                pieces.Add(tokens[0], (tokens[1], tokens[2]));
            }

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] tokens = input.Split('|');
                string piece = tokens[1];

                switch (tokens[0])
                {
                    case "Add":
                        if (pieces.ContainsKey(piece))
                            Console.WriteLine(piece + " is already in the collection!");
                        else
                        {
                            pieces.Add(piece, (tokens[2], tokens[3]));
                            Console.WriteLine($"{piece} by {tokens[2]} in {tokens[3]} added to the collection!");
                        }
                        break;
                    case "Remove":
                        if (!pieces.ContainsKey(piece))
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        else
                        {
                            pieces.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        break;
                    case "ChangeKey":
                        if (!pieces.ContainsKey(piece))
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        else
                        {
                            pieces[piece] = (pieces[piece].Item1, tokens[2]);
                            Console.WriteLine($"Changed the key of {piece} to {tokens[2]}!");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var (piece, composerAndKey) in pieces)
            {
                Console.WriteLine($"{piece} -> Composer: {composerAndKey.Item1}, Key: {composerAndKey.Item2}");
            }
        }
    }
}
