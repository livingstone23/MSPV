using Microsoft.AspNetCore.Identity;

namespace WebApiTemplate.Models
{
    public class Comentary
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }


    }
}
