using System;
using System.Threading.Channels;

namespace GenericScale
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            EqualityScale<int> scale = new EqualityScale<int>(5, 5);
            Console.WriteLine(scale.AreEqual());
        }
    }
}
