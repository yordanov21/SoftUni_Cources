namespace BookShop.Data.Models
{
    using BookShop.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        //•	Id - integer, Primary Key
        //•	Name - text with length[3, 30]. (required)
        //•	Genre - enumeration of type Genre, with possible values(Biography = 1, Business = 2, Science = 3) (required)
        //•	Price - decimal in range between 0.01 and max value of the decimal
        //•	Pages – integer in range between 50 and 5000
        //•	PublishedOn - date and time(required)
        //•	AuthorsBooks - collection of type AuthorBook

        public Book()
        {
            this.AuthorsBooks = new HashSet<AuthorBook>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

       // [Required] // ne e nujbo bazata shte se seti sama 
        public Genre Genre { get; set; }

        public decimal Price { get; set; }

        public int Pages { get; set; }

        //[Required] // it is required bu defaut(ako iskame da ne e required slagame edna ? sled DateTime)
        public DateTime PublishedOn { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }

    }
}
