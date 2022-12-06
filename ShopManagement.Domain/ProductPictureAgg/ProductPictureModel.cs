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

        public ProductPictureModel()
        {

        }

        public ProductPictureModel(long productId, string? picturePath, string? pictureAlt, string? pictureTitle)
        {
            ProductId = productId;
            PicturePath = picturePath;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemoved = false;
        }

        public void Edit(long productId, string? picturePath, string? pictureAlt, string? pictureTitle)
        {
            ProductId = productId;

            if (!string.IsNullOrEmpty(picturePath))
            {
                PicturePath = picturePath;
            }

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Activate()
        {
            IsRemoved = false;
        }

    }
}
