using System.ComponentModel.DataAnnotations;

namespace UmbracoCMS.ViewModels;

public class HelpFormViewModel
{
    [Required(ErrorMessage = "Email field is required")]
    [Display(Name = "E-mail address")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string HelpEmail { get; set; } = null!;
}
