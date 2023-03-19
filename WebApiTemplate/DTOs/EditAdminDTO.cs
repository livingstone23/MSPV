using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.DTOs
{
    public class EditAdminDTO
    {
        [Required]
        [EmailAddress]
        public String Email    { get; set; }

    }
}
