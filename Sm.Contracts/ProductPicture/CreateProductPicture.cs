using Microsoft.AspNetCore.Http;
using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        [MaxFileSize(MaxFileSize: 1 * 1024 * 1024, ErrorMessage = ValidationMessage.MaxFileSize)]
        //[FileExtensionsLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessage.InValidFileFormat)]
        public IFormFile? PicturePath { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureTitle { get; set; }

        public List<ProductViewModel>? Products { get; set; }
    }

}
