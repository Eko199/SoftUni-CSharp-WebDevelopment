using System;

namespace _02.Articles
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

        public void Edit(string newContent) => Content = newContent;

        public void ChangeAuthor(string newAuthor) => Author = newAuthor;

        public void Rename(string newTitle) => Title = newTitle;

        public override string ToString() => $"{Title} - {Content}: {Author}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleInfo = Console.ReadLine().Split(", ");
            Article article = new Article(articleInfo[0], articleInfo[1], articleInfo[2]);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(": ");

                switch (commands[0])
                {
                    case "Edit":
                        article.Edit(commands[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(commands[1]);
                        break;
                    case "Rename":
                        article.Rename(commands[1]);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}
