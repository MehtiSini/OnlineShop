﻿using ShopManagement.Query.Contracts.Article;

namespace ShopManagement.Query.Contracts.ArticleCategory
{
    public class ArticleCategoryQueryModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public string? Description { get; set; }
        public int ShowOrder { get; set; }
        public string? Slug { get; set; }
        public int ArticlesCount { get; set; }
        public string? MetaDescription { get; set; }
        public string? Keywords { get; set; }
        public List<string>? KeywordsList { get; set; }
        public string? CanonicalAddress { get; set; }
        public List<ArticleQueryModel>? Articles { get; set; }
    }
}
