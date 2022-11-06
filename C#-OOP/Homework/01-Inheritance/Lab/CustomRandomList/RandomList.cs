using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int rndIndex = random.Next(0, Count);

            string randomString = this[rndIndex];
            RemoveAt(rndIndex);

            return randomString;
        }
    }
}
