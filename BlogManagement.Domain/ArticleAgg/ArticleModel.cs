using BlogManagement.Domain.ArticleCategoryAgg;
using MyFramework.Domain;

namespace BlogManagement.Domain.ArticleAgg
{
    public class ArticleModel : EntityBase
    {
        public string? Title { get; private set; }
        public long CategoryId { get; private set; }
        public string? Description { get; private set; }
        public string? ShortDescription { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? PicturePath { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? Slug { get; private set; }
        public string? Keywords { get; private set; }
        public string? CanonicalAddress { get; private set; }
        public DateTime PublishDate { get; private set; }

        public ArticleCategoryModel? Category { get; private set; }

        public ArticleModel(
            string? title, long categoryId, string? description,
            string? shortDescription, string? metaDescription, string? picturePath,
            string? pictureAlt, string? pictureTitle, string? slug, string? keywords,
            string? canonicalAddress, DateTime publishDate
            )
        {
            Title = title;
            CategoryId = categoryId;
            Description = description;
            ShortDescription = shortDescription;
            MetaDescription = metaDescription;
            PicturePath = picturePath;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            PublishDate = publishDate;
        }

        public void Edit(
             string? title, long categoryId, string? description,
            string? shortDescription, string? metaDescription, string? picturePath,
            string? pictureAlt, string? pictureTitle, string? slug, string? keywords,
            string? canonicalAddress, DateTime publishDate)
        {
            Title = title;
            Description = description;
            ShortDescription = shortDescription;
            MetaDescription = metaDescription;
            if (!string.IsNullOrWhiteSpace(picturePath))
            {
                PicturePath = picturePath;
            }
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            PublishDate = publishDate;
            CategoryId = categoryId;
        }
    }
}
