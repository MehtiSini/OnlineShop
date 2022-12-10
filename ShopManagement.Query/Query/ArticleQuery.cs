using Blog.Domain.Tools;
using BlogManagement.Infrastructure.EfCore.DbContextModel;
using CommentManagement.Infrastructure.EfCore;
using CommentManagement.Infrastructure.EfCore.DbContextModel;
using CommentManagement.Query.Contracts.Comment;
using Microsoft.EntityFrameworkCore;
using MyFramework.Tools;
using ShopManagement.Query.Contracts.Article;

namespace ShopManagement.Query.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _Context;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext context, CommentContext commentContext)
        {
            _Context = context;
            _commentContext = commentContext;
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
                      Keywords = x.Keywords,
                      MetaDescription = x.MetaDescription

                  }).FirstOrDefault(x => x.Slug == slug);

            Article.KeywordsList = Article.Keywords.Split(',').ToList();

            var Comments = _commentContext.comments
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.OwnerRecordId == Article.Id)
                .Where(x => x.CommentStatus == OperationComment.Confirm)
                .Include(x=>x.Parent)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    Name = x.Name,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ParentId = x.ParentId
                }).OrderByDescending(x => x.Id).ToList();

            foreach (var item in Comments)
            {
                if (item.ParentId > 0)
                {
                    item.ParentName = Comments.FirstOrDefault(x => x.Id == x.ParentId)?.ParentName;
                }
            }

            Article.Comments = Comments;

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
