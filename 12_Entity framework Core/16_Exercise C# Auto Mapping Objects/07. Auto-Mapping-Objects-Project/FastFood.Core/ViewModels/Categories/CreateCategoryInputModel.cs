namespace FastFood.Core.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryInputModel
    {
        //* put validation in input model
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string CategoryName { get; set; }
    }
}
