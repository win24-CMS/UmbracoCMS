using System.ComponentModel.DataAnnotations;

namespace UmbracoCMS.ViewModels;

public class QuestionFormViewModel
{
    [Required(ErrorMessage = "Name field is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email field is required")]
    [Display(Name = "Email")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Question field is required")]
    [Display(Name = "Question")]
    public string Question { get; set; } = null!;
}
