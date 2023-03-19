using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido ")]
        [StringLength(maximumLength: 4, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Title { get; set; }

        public List<Comentary> Comentaries { get; set; }

    }
}
