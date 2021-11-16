namespace P01_StudentSystem.Data.Models
{
    using P01_StudentSystem.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ResourceTypeEnum ContentType { get; set; }

        [Required]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }

    }
}
