using System;

namespace _03.Cards
{
    using System.Collections.Generic;

    internal class Card
    {
        private const string InvalidCardExceptionMessage = "Invalid card!";

        private static readonly IReadOnlySet<string> Faces = new HashSet<string>
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
        };

        private static readonly IReadOnlyDictionary<char, char> Suits = new Dictionary<char, char>
        {
            { 'S', '\u2660' },
            { 'H', '\u2665' },
            { 'D', '\u2666' },
            { 'C', '\u2663' }
        };

        private string face;
        private char suit;

        public Card(string face, char suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            private init
            {
                if (!Faces.Contains(value))
                    throw new ArgumentException(InvalidCardExceptionMessage);

                face = value;
            }
        }

        public char Suit
        {
            get => suit;
            private init
            {
                if (!Suits.ContainsKey(value))
                    throw new ArgumentException(InvalidCardExceptionMessage);

                suit = value;
            }
        }

        public override string ToString() => $"[{Face}{Suits[Suit]}]";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cardsInfo = Console.ReadLine().Split(", ");
            var cards = new List<Card>(cardsInfo.Length);

            foreach (string cardInfo in cardsInfo)
            {
                string[] faceSuit = cardInfo.Split();

                try
                {
                    cards.Add(new Card(faceSuit[0], faceSuit[1][0]));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(' ', cards));
        }
    }
}
