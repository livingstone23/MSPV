using System.ComponentModel.DataAnnotations;
using WebApiTemplate.Validations;

namespace WebApiTemplate.DTOs
{
    public class AuthorCreationDTO
    {

        [Required(ErrorMessage = "El campo {0} es requerido ")]
        [StringLength(maximumLength: 4, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [FirstLetterInCapital]
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        //Validacion personalizada.
        [FileSizeValidation(MaxWeightInMegaBites: 4)]
        [FileTypeValidation(grouptypeFileValidation:GrouptypeFileValidation.Imagen)]
        public IFormFile Picture { get; set; }




    }


}
