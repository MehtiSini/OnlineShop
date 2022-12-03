using Microsoft.AspNetCore.Http;
using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace Sm.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }

        [MaxFileSize(MaxFileSize: 1 * 1024 * 1024,ErrorMessage = ValidationMessage.MaxFileSize)]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public IFormFile PicturePath { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? KeyWords { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Slug { get; set; }
    }
}
