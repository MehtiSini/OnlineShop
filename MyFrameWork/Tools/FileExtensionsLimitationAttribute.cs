using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyFramework.Tools
{
    public class FileExtensionsLimitationAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[]? _ValidExtensions;

        public FileExtensionsLimitationAttribute(string[]? validExtensions)
        {
            _ValidExtensions = validExtensions;
        }

        public bool IsValid(object? Value)
        {
            var File = Value as IFormFile;

            if (File == null)
            {
                return false;
            }
            var FileExtension = Path.GetExtension(File.FileName);

            return _ValidExtensions.Contains(FileExtension.ToLower());
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-fileExtensionLimit", ErrorMessage);
        }
    }
}
