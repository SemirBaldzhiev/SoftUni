using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] inputArticle = Console.ReadLine().Split(", ").ToArray();

                Article article = new Article(inputArticle[0], inputArticle[1], inputArticle[2]);

                articles.Add(article);
            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (criteria == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString());
            }
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
