using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> hand1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> hand2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (hand1.Count > 0 && hand2.Count > 0)
            {
                if (hand1[0] == hand2[0])
                {
                    hand1.RemoveAt(0);
                    hand2.RemoveAt(0);
                    continue;
                }

                List<int> winningHand = hand1[0] > hand2[0] ? hand1 : hand2;
                List<int> lostHand = hand1[0] > hand2[0] ? hand2 : hand1;

                int wonCard = winningHand[0];
                int lostCard = lostHand[0];

                winningHand.RemoveAt(0);
                lostHand.RemoveAt(0);

                winningHand.Add(lostCard);
                winningHand.Add(wonCard);
            }

            List<int> winnerHand = hand1.Count > 0 ? hand1 : hand2;
            Console.WriteLine("{0} player wins! Sum: {1}", 
                winnerHand.Equals(hand1) ? "First" : "Second", winnerHand.Sum());
        }
    }
}
