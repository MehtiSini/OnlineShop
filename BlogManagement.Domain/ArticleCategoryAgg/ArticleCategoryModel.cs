using MyFramework.Domain;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategoryModel : EntityBase
    {
        public string? Name { get; private set; }
        public string? PicturePath { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? Description { get; private set; }
        public int ShowOrder { get; private set; }
        public string? Slug { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? Keywords { get; private set; }
        public string? CanonicalAddress { get; private set; }


        public ArticleCategoryModel(
            string? name, string? picturePath, string? pictureAlt,
           string? pictureTitle, string? description,
           int showOrder, string? slug, string? metaDescription,
           string? keywords, string? canonicalAddress)
        {
            Name = name;
            PicturePath = picturePath;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            MetaDescription = metaDescription;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
        }

        public void Edit(
               string? name, string? picturePath, string? pictureAlt,
           string? pictureTitle, string? description,
           int showOrder, string? slug, string? metaDescription,
           string? keywords, string? canonicalAddress)
        {
            Name = name;
            if (!string.IsNullOrWhiteSpace(picturePath))
            {
                PicturePath = picturePath;
            }
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            MetaDescription = metaDescription;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;

        }

    }
}
