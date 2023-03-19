using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiTemplate.Validations;

namespace WebApiTemplate.Models
{
    public class Author: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido ")]
        [StringLength(maximumLength:50, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]

        //Utilizando regla de validacion personalizada
        [FirstLetterInCapital]
        public string Name { get; set; }


        public DateTime BirthDay { get; set; }


        public string Picture { get; set; }


        [NotMapped]
        [Range(18,120)]
        public int? Edad { get; set; }

        //[NotMapped]
        //[CreditCard]
        //public string? TarjetaDeCredito { get; set; }

        //[Url]
        //[NotMapped]
        //public string URL { get; set; }

        [NotMapped]
        public int? Menor { get; set; }

        [NotMapped]
        public int? Mayor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var primeraLetra = Name[0].ToString();
            
                if(primeraLetra != primeraLetra.ToUpper())
                {
                    //Se inserta un elemento en la coleccion de registros.
                    yield return new ValidationResult("La primera Letra debe ser mayuscula", new string[] { nameof(Name) });
                }
            }

            //Validamos se confirme la validacion de los comparativo de los campos
            if (Menor > Mayor)
            {
                yield return new ValidationResult("Este valor no puede ser mas grande que el campo mayor", new string[] { nameof(Menor) });
            }

        }



    }
}
