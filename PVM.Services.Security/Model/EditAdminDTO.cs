using System.ComponentModel.DataAnnotations;

namespace PVM.Services.Security.Model
{
    public class EditAdminDTO
    {

        [Required]
        [EmailAddress]
        public String Email { get; set; }

    }
}
