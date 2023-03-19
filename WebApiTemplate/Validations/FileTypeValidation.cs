using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.Validations
{
    public class FileTypeValidation : ValidationAttribute
    {

        private readonly string[] _validTypes;

        public FileTypeValidation(string[] validTypes)
        {
                
            _validTypes = validTypes;

        }

        public FileTypeValidation(GrouptypeFileValidation grouptypeFileValidation)
        {
            if (grouptypeFileValidation == GrouptypeFileValidation.Imagen)
            {
                _validTypes = new string[] {"image/jpeg", "image/png", "image/gif"};

            }
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (!_validTypes.Contains(formFile.ContentType))
            {
                return new ValidationResult($"El tipo del archivo debe ser de tipo: { string.Join(",",_validTypes)}");
            }

            return ValidationResult.Success;


        }


    }

    public enum GrouptypeFileValidation
    {
        Imagen
    }
}
