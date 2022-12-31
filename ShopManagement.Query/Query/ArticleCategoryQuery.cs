using Blog.Domain.Tools;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Tools;
using ShopManagement.Query.Contracts.Article;
using ShopManagement.Query.Contracts.ArticleCategory;

namespace ShopManagement.Query.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _context;

        public ArticleCategoryQuery(BlogContext context)
        {
            _context = context;
        }

        public List<ArticleCategoryQueryModel> GetArticleCategories()
        {
            return _context.categories.Include(x => x.Articles).Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ArticlesCount = x.Articles.Count,
                Description = x.Description,
                PictureAlt = x.PictureAlt,
                PicturePath = x.PicturePath,
                PictureTitle = x.PictureTitle

            }).OrderByDescending(x => x.Id).ToList();
        }

        public ArticleCategoryQueryModel GetArticleCategoryDetails(string slug)
        {
            var Category = _context.categories.Include(x => x.Articles).Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Keywords = x.Keywords,
                ArticlesCount = x.Articles.Count,
                Description = x.Description,
                PictureAlt = x.PictureAlt,
                PicturePath = x.PicturePath,
                PictureTitle = x.PictureTitle,
                Articles = MapArticles(x.Articles)

            }).FirstOrDefault(x => x.Slug == slug);

            if (!string.IsNullOrWhiteSpace(Category.Keywords))
            {
                Category.KeywordsList = Category.Keywords.Split(',').ToList();
            }

            return Category;
        }

        private static List<ArticleQueryModel> MapArticles(List<ArticleModel> articles)
        {
            return articles.Select(x => new ArticleQueryModel
            {
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                PicturePath = x.PicturePath,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
            }).ToList();
        }
    }
}
