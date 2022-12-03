using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyFramework.Tools
{
    public class MaxFileSizeAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int MaxFileSize;

        public MaxFileSizeAttribute(int MaxFileSize)
        {
            this.MaxFileSize = MaxFileSize;
        }

        public override bool IsValid(object? Value)
        {
            var File = Value as IFormFile;

            if (File == null)
            {
                return false;
            }

            return File.Length < MaxFileSize;
        }

        // This Mehtod Helps Us To add Validation From Client Side
        // Before Posting The Model 
        // ==> By JQuery

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-maxFileSize", ErrorMessage);
        }
    }
}
