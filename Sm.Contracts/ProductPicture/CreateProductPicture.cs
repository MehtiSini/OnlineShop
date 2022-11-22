namespace ShopManagement.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        public long PictureID { get; set; }
        public string? PicturePath { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
    }

}
