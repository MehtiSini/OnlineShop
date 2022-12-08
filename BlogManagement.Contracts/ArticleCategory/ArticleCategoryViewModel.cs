using Microsoft.AspNetCore.Http;

namespace BlogManagement.Contracts.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? Description { get; set; }
        public int ShowOrder { get; set; }
        public string? Slug { get; set; }
        public string? CreationDate { get; set; }
        public int ArticlesCount { get; set; }
    }
}
