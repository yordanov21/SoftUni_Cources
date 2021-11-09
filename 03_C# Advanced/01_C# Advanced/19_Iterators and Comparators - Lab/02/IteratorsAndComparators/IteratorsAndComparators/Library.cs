using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[]books)
        {
            this.books = new List<Book>();
        }

        public void Add(Book book)
        {
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
       => this.GetEnumerator();
    }
}
