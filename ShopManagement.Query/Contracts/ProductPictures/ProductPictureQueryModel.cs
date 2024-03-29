﻿namespace ShopManagement.Query.Contracts.ProductPictures
{
    public class ProductPictureQueryModel
    {
        public long ProductId { get; set; }
        public string? PicturePath { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public bool IsRemoved { get;  set; }
    }
}
