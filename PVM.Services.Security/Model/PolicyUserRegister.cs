using System.ComponentModel.DataAnnotations;

namespace PVM.Services.Security.Model;

public class PolicyUserRegister
{

    [Required, EmailAddress]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

    [Compare("Password", ErrorMessage = "The passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

}