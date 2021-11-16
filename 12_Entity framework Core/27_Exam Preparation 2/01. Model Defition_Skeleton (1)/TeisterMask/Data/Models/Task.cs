namespace TeisterMask.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TeisterMask.Data.Models.Enums;


    public class Task
    {
        public Task()
        {
            //DONT FORGET TO INIZIALIZATE THE COLECTION !!!!!!!!!!!!!!!!!!
            // IT CAN PASS TO CREATE THE DATABASE BUT IT IS NOT CREATE THE IMPORT!!!!!
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        //It is Required by default
        public DateTime OpenDate { get; set; }

        //It is Required by default
        public DateTime DueDate { get; set; }

        //[Required] it's not nesesery, the DB will make it, because enum is integer an integer is non-nullabel
        public ExecutionType ExecutionType { get; set; }

        //[Required] it's not nesesery, the DB will make it.
        public LabelType LabelType { get; set; }

        [ForeignKey(nameof(Project))]
        [Required] //can also without [Required]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }

    }
}
