using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace WebApiTemplate.Validations;

public class FileSizeValidation: ValidationAttribute
{
    private readonly int _maxWeightInMegaBites;

    public FileSizeValidation(int MaxWeightInMegaBites)
    {
        _maxWeightInMegaBites = MaxWeightInMegaBites;
    }


    /// <summary>
    /// Valida el peso maximo de un archivo
    /// </summary>
    /// <param name="value"></param>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        IFormFile formFile = value as IFormFile;

        if (formFile == null)
        {
            return  ValidationResult.Success;
        }

        if (formFile.Length > _maxWeightInMegaBites * 1024 * 1024)
        {
            return new ValidationResult($"El peso maximo del archivo no debe ser mayor a {_maxWeightInMegaBites}mb");
        }

        return ValidationResult.Success;


    }

}