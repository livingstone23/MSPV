using System.ComponentModel.DataAnnotations;

namespace PVM.Services.Security.Model;

public class PolicyUserLogin
{

    [Required]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;

}