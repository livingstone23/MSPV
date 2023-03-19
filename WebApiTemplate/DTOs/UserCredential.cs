using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.DTOs
{
    public class UserCredential
    {

        [EmailAddress]
        [Required(ErrorMessage = "Name is required")]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

    }

}
