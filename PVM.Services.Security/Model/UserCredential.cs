using System.ComponentModel.DataAnnotations;

namespace PVM.Services.Security.Model
{
    public class UserCredential
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
