﻿namespace ShopManagement.Contracts.Product
{
    public class CreateProduct
    {
        public string? Name { get; set; }
        public long Code { get; set; }
        public int IsInStock { get; set; }
        public double UnitPrice { get; set; }
        public string? PicturePath { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? MetaDescription { get; set; }
        public string? Slug { get; set; }
        public string? Keywords { get; set; }
        public long CategoryId { get; set; }
    }

}
