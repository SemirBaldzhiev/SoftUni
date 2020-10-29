using System;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArticle = Console.ReadLine().Split(", ").ToArray();
            int n = int.Parse(Console.ReadLine());

            Article article = new Article(inputArticle[0], inputArticle[1], inputArticle[2]);

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(": ").ToArray();

                string command = tokens[0];
                string value = tokens[1];


                switch (command)
                {
                    case "Edit":
                        article.Edit(value);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(value);
                        break;
                    case "Rename":
                        article.Rename(value);
                        break;
                }
            }

            Console.WriteLine(article.ToString());

        }
    }

    public class Article
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


        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
