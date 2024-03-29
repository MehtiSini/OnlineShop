﻿using CommentManagement.Domain.CommentAgg;
using Microsoft.AspNetCore.Http;
using MyFramework.Domain;
using MyFramework.Tools;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class ProductModel : EntityBase
    {
        public string? Name { get; private set; }
        public string? Code { get; private set; }
        public string? PicturePath { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? ShortDescription { get; private set; }
        public string? Description { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? Slug { get; private set; }
        public string? Keywords { get; private set; }
        public long CategoryId { get; private set; }

        public List<ProductPictureModel> Pictures { get; private set; }
        public ProductCategoryModel? Category { get; private set; }

        public ProductModel(string? name, string? code,
           string? picturePath,
            string? pictureAlt, string? pictureTitle,
            string? shortDescription, string? description,
            string? metaDescription, string? slug,
            string? keywords, long categoryId)
        {
            Name = name;
            Code = code;

            if (!string.IsNullOrWhiteSpace(picturePath))
            {
                PicturePath = picturePath;
            }

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            MetaDescription = metaDescription;
            Slug = slug;
            Keywords = keywords;
            CategoryId = categoryId;
        }

        public void Edit(string? name, string? code,
             string? picturePath,
            string? pictureAlt, string? pictureTitle,
            string? shortDescription, string? description,
            string? metaDescription,
            string? keywords, long categoryId, string? slug)
        {
            Name = name;
            Code = code;

            if (!string.IsNullOrEmpty(picturePath))
            {
                PicturePath = picturePath;
            }
            if (categoryId == 0)
            {
                CategoryId = categoryId;
            }

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
        }
    }
}
