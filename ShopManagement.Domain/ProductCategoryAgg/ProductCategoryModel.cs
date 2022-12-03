using MyFramework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategoryModel : EntityBase
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? PicturePath { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? KeyWords { get; private set; }
        public string? MetaDescription { get; private set; }
        public long ProductsCount { get; private set; }
        public string? Slug { get; private set; }

        public List<ProductModel> Products { get; private set; }

        //Cunstructor
        public ProductCategoryModel(string? name, string? description, string? picturePath, string? pictureAlt, string? pictureTitle, string? keyWords, string? metaDescription, string? slug)
        {
            Name = name;
            Description = description;
            PicturePath = picturePath;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
        }


        //Edit Category
        public void Edit(string? name, string? description, string? picturePath, string? pictureAlt, string? pictureTitle, string? keyWords, string? metaDescription, string? slug)
        {
            Name = name;
            Description = description;
            if (!string.IsNullOrEmpty(picturePath))
            {
                PicturePath = picturePath;
            }
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
    }
}
