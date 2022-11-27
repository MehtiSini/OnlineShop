using MyFramework.Domain;
using MyFramework.Tools;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class ProductModel : EntityBase
    {
        public string? Name { get; private set; }
        public long Code { get; private set; }
        public string? PicturePath { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? ShortDescription { get; private set; }
        public string? Description { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? Slug { get; private set; }
        public string? Keywords { get; private set; }

        public ICollection<ProductPictureModel> Pictures { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategoryModel? Category { get; private set; }

        public ProductModel(string? name, long code,
           string? picturePath,
            string? pictureAlt, string? pictureTitle,
            string? shortDescription, string? description,
            string? metaDescription, string? slug,
            string? keywords, long categoryId)
        {
            Name = name;
            Code = code;
            PicturePath = picturePath;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            MetaDescription = metaDescription;
            Slug = slug;
            Keywords = keywords;
            CategoryId = categoryId;
        }

        public void Edit(string? name, long code,
             string? picturePath,
            string? pictureAlt, string? pictureTitle,
            string? shortDescription, string? description,
            string? metaDescription,
            string? keywords, long categoryId, string? slug)
        {
            Name = name;
            Code = code;
            PicturePath = picturePath;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            MetaDescription = metaDescription;
            Keywords = keywords;
            CategoryId = categoryId;
            Slug = slug;
        }


    }
}
