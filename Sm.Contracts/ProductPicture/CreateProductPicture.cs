using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        public string? PicturePath { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureTitle { get; set; }
        public List<ProductViewModel>? Products { get; set; }
    }

}
