using Castle.Components.DictionaryAdapter;
namespace TeisterMask.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Employee()
        {
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Username { get; set; }

        [Required] //the another email validation will be in a DTO
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        //virtual for lazzy loading
        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}
