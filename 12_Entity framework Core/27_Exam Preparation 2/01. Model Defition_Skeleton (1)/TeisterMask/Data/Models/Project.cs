namespace TeisterMask.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        //It is Required by default
        public  DateTime OpenDate { get; set; }

        // with ? make it non required (ca be null)
        public DateTime? DueDate { get; set; }

        //virtual for lazzy loading
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
