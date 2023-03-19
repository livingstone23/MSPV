using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.Validations
{
    public class FirstLetterInCapital: ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            //confirma que al ser nulo se valide para la proxima regla.
            if (value == null || string.IsNullOrEmpty(value.ToString()) )
            {
                return ValidationResult.Success;
            }


            var primeraLetra = value.ToString()[0].ToString();

            if (primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayuscula");
            }

            return ValidationResult.Success;


        }



    }
}
