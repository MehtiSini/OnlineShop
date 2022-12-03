using Microsoft.AspNetCore.Http;
using MyFramework.Tools;
using Sm.Contracts.ProductCategory;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Name { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Code { get; set; }

        [MaxFileSize(MaxFileSize: 3 * 1024 * 1024, ErrorMessage = ValidationMessage.MaxFileSize)]
        //[FileExtensionsLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessage.InValidFileFormat)]
        public IFormFile? PicturePath { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? ShortDescription { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Description { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Slug { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long CategoryId { get; set; }

        public List<ProductCategoryQueryModel>? Categories { get; set; }

    }

}
