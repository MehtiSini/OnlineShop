using MyFramework.Domain;
using MyFramework.Tools;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPictureModel : EntityBase
    {
        public long ProductId { get; private set; }
        public string? PicturePath { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public bool IsRemoved { get; private set; }

        public ProductModel? Product { get; private set; }


        public ProductPictureModel(long pictureID, string? picturePath, string? pictureAlt, string? pictureTitle)
        {
            ProductId = pictureID;
            PicturePath = picturePath;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemoved = false;
        }

        public void Edit(long pictureID, string? picturePath, string? pictureAlt, string? pictureTitle)
        {
            ProductId = pictureID;
            PicturePath = picturePath;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemoved = false;
        }

        public void Activate()
        {
            IsRemoved = true;
        }

    }
}
