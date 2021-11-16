namespace BookShop.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;


    public class ImportAuthorDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^(\\d{3})\\-(\\d{3})\\-(\\d{4})$")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //this is array of iner DTO(ImportAuthorBookDto)
        public ImportAuthorBookDto[] Books { get; set; }
    //        "FirstName": "K",
    //"LastName": "Tribbeck",
    //"Phone": "808-944-5051",
    //"Email": "btribbeck0@last.fm",
    //"Books": [

    }
}
