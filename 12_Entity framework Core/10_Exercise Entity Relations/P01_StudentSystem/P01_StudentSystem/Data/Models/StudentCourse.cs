namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StudentCourse
    {
        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
