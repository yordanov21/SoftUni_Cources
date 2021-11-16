namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AuthorBook
    {

        //•	AuthorId - integer, Primary Key, Foreign key(required)
        //•	Author -  Author
        //•	BookId - integer, Primary Key, Foreign key(required)
        //•	Book - Book

        [ForeignKey(nameof(Author))]
        [Required]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        //moje da se zapishe i taka, gornoto e po pravilno
        [ForeignKey("Book")]
        [Required]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
