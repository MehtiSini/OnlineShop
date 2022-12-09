using Blog.Domain.Tools;
using BlogManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Query.Contracts.Article;

namespace ShopManagement.Query.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _Context;

        public ArticleQuery(BlogContext context)
        {
            _Context = context;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var Article = _Context.articles.Include(x => x.Category)
                  .Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryModel
                  {
                      Id = x.Id,
                      CategoryId = x.CategoryId,
                      CategoryName = x.Category.Name,
                      CategorySlug = x.Category.Slug,
                      PublishDate = x.PublishDate.ToFarsi(),
                      Title = x.Title,
                      Slug = x.Slug,
                      ShortDescription = x.ShortDescription,
                      PictureAlt = x.PictureAlt,
                      PicturePath = x.PicturePath,
                      PictureTitle = x.PictureTitle,
                      Description = x.Description,
                      Keywords = x.Keywords

                  }).FirstOrDefault(x => x.Slug == slug);

            Article.KeywordsList = Article.Keywords.Split(',').ToList();


            return Article;
        }

        public List<ArticleQueryModel> GetLatestArticles()
        {
            return _Context.articles.Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryModel
                {
                    Id = x.Id,
                    PublishDate = x.CreationDate.ToFarsi(),
                    Title = x.Title,
                    Slug = x.Slug,
                    ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + "...",
                    PictureAlt = x.PictureAlt,
                    PicturePath = x.PicturePath,
                    PictureTitle = x.PictureTitle

                }).OrderByDescending(x => x.Id).Take(3).ToList();
        }
    }
}
