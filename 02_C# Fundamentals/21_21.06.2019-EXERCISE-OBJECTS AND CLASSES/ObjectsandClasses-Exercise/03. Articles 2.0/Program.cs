using System;
using System.Collections.Generic;
using System.Linq;


namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Article> listArticle = new List<Article>();
            for (int i = 0; i < count; i++)
            {
                string[] artclesArr = Console.ReadLine().Split(", ");

                string title = artclesArr[0];
                string content = artclesArr[1];
                string author = artclesArr[2];

                Article article = new Article(title, content, author);
                listArticle.Add(article);
            }

            string command = Console.ReadLine();

            if (command == "title")
            {
                listArticle = listArticle.OrderBy(x => x.Title).ToList();
            }
            else if (command == "content")
            {
                listArticle = listArticle.OrderBy(x => x.Content).ToList();
            }
            else if (command == "author")
            {
                listArticle = listArticle.OrderBy(x => x.Author).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, listArticle));
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title,string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}

