using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    internal class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> list = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] songInfo = Console.ReadLine().Split('_');
                list.Add(new Song(songInfo[0], songInfo[1], songInfo[2]));
            }

            string option = Console.ReadLine();
            switch (option)
            {
                case "all":
                    list.ForEach(song => Console.WriteLine(song.Name));
                    break;
                default:
                    list.Where(song => song.TypeList.Equals(option)).ToList().ForEach(song => Console.WriteLine(song.Name));
                    break;
            }
        }
    }
}
