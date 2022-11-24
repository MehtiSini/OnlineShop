using MyFramework.Tools;
using Sm.Contracts.ProductCategory;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string? Name { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long Code { get; set; }
        public int IsInStock { get; set; }

        [Range(1,100000,ErrorMessage = ValidationMessage.IsRequired)]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PicturePath { get; set; }

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
