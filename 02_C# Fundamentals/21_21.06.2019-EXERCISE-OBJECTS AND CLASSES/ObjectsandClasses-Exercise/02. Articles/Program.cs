using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleArgs = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            string title = articleArgs[0];
             string content= articleArgs[1];
            string author= articleArgs[2];

            Article article = new Article(title, content, author); //създаваме си инстанция на класa Article.

            int numOfComands = int.Parse(Console.ReadLine());

            for(int i=0; i < numOfComands; i++)
            {
                string[] comandArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = comandArgs[0];

                if(command== "Edit")
                {
                    string currentContetnt = comandArgs[1];
                    article.Edit(currentContetnt);
                }
                else if(command== "ChangeAuthor")
                {
                    string currentAuthor = comandArgs[1];
                    article.ChangeAuthor(currentAuthor);
                }
                else if(command== "Rename")
                {
                    string currentTitle = comandArgs[1];
                    article.Rename(currentTitle);
                }
            }
            Console.WriteLine(article);
        }
    }

    class Article
    {
        public string Title { get; set; }       //пропъртита
        public string Content { get; set; }     //пропъртита
        public string Author { get; set; }      //пропъртита
        public Article (string title, string content, string author)    //конструктор
        {
            this.Title = title;      //сетваме ги
            this.Content = Content;  //сетваме ги
            this.Author = author;    //сетваме ги
        }

        public void Edit(string newContent)  //метод
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)   //метод
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)    //метод
        {
            this.Title = newTitle;
        }

        public override string ToString()  //override-ваме to стрингметод
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
