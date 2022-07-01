using System;
using System.Collections.Generic;

namespace _03.Articles2
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public override string ToString() => $"{Title} - {Content}: {Author}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] articleInfo = Console.ReadLine().Split(", ");
                articles.Add(new Article(articleInfo[0], articleInfo[1], articleInfo[2]));
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }
}
