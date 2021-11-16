using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);


            ////problem 02
            //Console.Write("Input the restriction(Minor,Teen ,Adult) : ");
            //string input = Console.ReadLine();
            //string result2 = GetBooksByAgeRestriction(db, input);
            //Console.WriteLine(result2);
            //Console.WriteLine(new String('-', 100));

            ////problem 03
            //string result3 = GetGoldenBooks(db);
            //Console.WriteLine(result3);
            //Console.WriteLine(new String('-', 100));

            ////problem 04
            //string result4 = GetBooksByPrice(db);
            //Console.WriteLine(result4);
            //Console.WriteLine(new String('-', 100));

            ////problem 05
            //Console.Write("Input the Year: ");
            //int inputYear = int.Parse(Console.ReadLine());
            //string result5 = GetBooksNotReleasedIn(db, inputYear);
            //Console.WriteLine(result5);
            //Console.WriteLine(new String('-', 100));

            ////problem 06
            //Console.Write("Input Categories: ");
            //string inputCategories = Console.ReadLine();
            //string result6 = GetBooksByCategory(db, inputCategories);
            //Console.WriteLine(result6);
            //Console.WriteLine(new String('-', 100));

            ////problem 07
            //Console.Write("Input Date: ");
            //string inputDate = Console.ReadLine();
            //string result7 = GetBooksReleasedBefore(db, inputDate);
            //Console.WriteLine(result7);
            //Console.WriteLine(new String('-', 100));

            ////problem 08
            //Console.Write("Input FirstName Autor end with: ");
            //string inputStringEnd = Console.ReadLine();
            //string result8 = GetAuthorNamesEndingIn(db, inputStringEnd);
            //Console.WriteLine(result8);
            //Console.WriteLine(new String('-', 100));

            ////problem 09
            //Console.Write("Input string containing in title: ");
            //string inputStringContain = Console.ReadLine();
            //string result9 = GetBookTitlesContaining(db, inputStringContain);
            //Console.WriteLine(result9);
            //Console.WriteLine(new String('-', 100));

            ////problem 10
            //Console.Write("Input ending string by Author: ");
            //string inputStringEnding = Console.ReadLine();
            //string result10 = GetBooksByAuthor(db, inputStringEnding);
            //Console.WriteLine(result10);
            //Console.WriteLine(new String('-', 100));

            ////problem 11
            //Console.Write("Input number of charackter in Title: ");
            //int numberOfChar = int.Parse(Console.ReadLine());
            //int result11 = CountBooks(db, numberOfChar);
            //Console.WriteLine(result11);
            //Console.WriteLine(new String('-', 100));

            //problem 12
            string result12 = CountCopiesByAuthor(db);
            Console.WriteLine(result12);
            Console.WriteLine(new String('-', 100));

            //problem 13
            string result13 = GetTotalProfitByCategory(db);
            Console.WriteLine(result13);
            Console.WriteLine(new String('-', 100));

            //problem 14
            string result14 = GetMostRecentBooks(db);
            Console.WriteLine(result14);
            Console.WriteLine(new String('-', 100));


            //problem 16
            RemoveBooks(db);
        }

        //problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            //Return in a single string all book titles, each on a new line, that have age restriction, 
            //equal to the given command. Order the titles alphabetically.

            List<string> bookTitles = context
                .Books
                .AsEnumerable() //razkachame gi ot bazata inache hvurlq greshka na EF V3.1 moje i sus toList() 
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(bt => bt)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            //Return in a single string titles of the golden edition books that have less than 5000 copies,
            //each on a new line.Order them by book id ascending.

            List<string> goldenEditionBooks = context
                 .Books
                 .Where(b => b.EditionType == EditionType.Gold &&
                             b.Copies < 5000)
                 .OrderBy(b => b.BookId)
                 .Select(b => b.Title)
                 .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var title in goldenEditionBooks)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
            //moje i po tozi nachin da izkarame rezultata (bez stringBuilder)
            //return String.Join(Environment.NewLine, goldenEditionBooks);
        }

        //problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            //Return in a single string all titles and prices of books with price higher than 40,
            //each on a new row in the format given below. Order them by price descending.

            var booksAndPrice = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in booksAndPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            // Return in a single string all titles of books that are NOT released on a given year.Order them by book id ascending.
            List<string> booksTitles = context
                 .Books
                 .Where(b => b.ReleaseDate.Value.Year != year)
                 .OrderBy(b => b.BookId)
                 .Select(b => b.Title)
                 .ToList();

            return String.Join(Environment.NewLine, booksTitles);
        }

        //problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            //Return in a single string the titles of books by a given list of categories.
            //The list of categories will be given in a single line separated with one or more spaces.Ignore casing. Order by title alphabetically.

            string[] categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            List<string> booksTitles = new List<string>();

            foreach (var category in categories)
            {
                List<string> currentCatBookTitles = context
                    .Books
                    .Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == category))
                    .Select(b => b.Title)
                    .ToList();

                booksTitles.AddRange(currentCatBookTitles);
            }

            booksTitles = booksTitles.OrderBy(b => b).ToList();
            return String.Join(Environment.NewLine, booksTitles);
        }

        //problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            // Return the title, edition type and price of all books that are released before a given date.
            //The date will be a string in format dd-MM - yyyy.
            //Return all of the rows in a single string, ordered by release date descending.
            var dateAsString = date;
            var dateAsDate = DateTime.ParseExact(dateAsString, "dd-MM-yyyy", CultureInfo.CurrentCulture);
            var booksAndPrice = context
                .Books
                .Where(b => b.ReleaseDate < dateAsDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in booksAndPrice)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            //Return the full names of authors, whose first name ends with a given string.
            //Return all names in a single string, each on a new row, ordered alphabetically.

            var fullNames = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    name = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.name)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var fname in fullNames)
            {
                sb.AppendLine(fname.name);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            // Return the titles of book, which contain a given string.Ignore casing.
            //Return all titles in a single string, each on a new row, ordered alphabetically.
            var bookTitles = context
                .Books
                .AsEnumerable()
                .Where(b => b.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))  //MOJE I S ToLower(), no trqbva da se dade i na title-a i na input-a
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            //Return all titles of books and their authors’ names for books, which are written by authors whose last names start with the given string.
            //Return a single string with each title on a new row.Ignore casing.Order by book id ascending.

            var bookTitles = context
             .Books
             .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
             .OrderBy(b => b.BookId)
             .Select(b => new
             {
                 b.Title,
                 b.Author.FirstName,
                 b.Author.LastName
             })

             .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine($"{title.Title} ({title.FirstName} {title.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

            var bookTitles = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return bookTitles.Count;
        }

        //problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            // Return the total number of book copies for each author. 
            //Order the results descending by total book copies.
            //Return all results in a single string, each on a new line.

            var alutorCopies = context
                .Authors
                .Select(a => new
                {
                    FullName = a.FirstName + ' ' + a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var autor in alutorCopies)
            {
                sb.AppendLine($"{autor.FullName} - {autor.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            // Return the total profit of all books by category.Profit for a book
            //can be calculated by multiplying its number of copies by the price
            //per single book.Order the results by descending by total profit for
            //category and ascending by category name.

            var booksProfitByCategory = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                    .Select(cb => new
                    {
                        bookProfit = cb.Book.Copies * cb.Book.Price
                    })
                    .Sum(cb => cb.bookProfit)
                })
                .OrderByDescending(b => b.TotalProfit)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var bookProfit in booksProfitByCategory)
            {
                sb.AppendLine($"{bookProfit.Name} ${bookProfit.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {

            var mostrecentBooksCategory = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    MostRecenrBooks = c.CategoryBooks
                     .OrderByDescending(cb => cb.Book.ReleaseDate)
                     .Take(3)
                     .Select(cb => new
                     {
                         bookTitle = cb.Book.Title,
                         RYear = cb.Book.ReleaseDate.Value.Year
                     })
                     .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var categoty in mostrecentBooksCategory)
            {
                sb.AppendLine($"--{categoty.Name}");
                for (int i = 0; i < categoty.MostRecenrBooks.Count; i++)
                {
                    sb.AppendLine($"{categoty.MostRecenrBooks[i].bookTitle} ({categoty.MostRecenrBooks[i].RYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            // Increase the prices of all books released before 2010 by 5.
            var booksToUpdate = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var bookToRemove = context
             .Books
             .Where(b => b.Copies < 4200);

            int count = 0;
            foreach (var book in bookToRemove)
            {
                context.Remove(book);
                count++;
            }

            context.SaveChanges();

            return count;

            //can and this way too:
            //var entityForRemove = context.Books.Where(b => b.Copies < 4200);
            //var result = entityForRemove.Count();

            //context.Books.RemoveRange(entityForRemove);

            //context.SaveChanges();

            //return result;
        }
    }

}
