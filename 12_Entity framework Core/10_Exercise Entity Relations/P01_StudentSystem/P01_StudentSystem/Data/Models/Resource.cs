namespace P01_StudentSystem.Data.Models
{
    using P01_StudentSystem.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }


        [Required]
        public int CourceId { get; set; }
        public virtual Course Course { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public ResourceTypeEnum ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

   


    }
}
