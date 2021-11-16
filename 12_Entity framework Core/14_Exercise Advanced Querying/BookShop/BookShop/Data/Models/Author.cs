namespace BookShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        //TODO ICOLLECTION<BOOK> BOOKS AND CTOR FOR BOOKS COLECTION

    }
}
