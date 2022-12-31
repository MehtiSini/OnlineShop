using Blog.Domain.Tools;
using BlogManagement.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools;

namespace BlogManagement.Infrastructure.EfCore.Article
{
    public class ArticleRepository : RepositoryBase<long, ArticleModel>, IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public EditArticle GetDetails(long id)
        {
            return _context.articles.Select(x => new EditArticle
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Title = x.Title,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CategoryId = x.CategoryId,
                PublishDate = x.PublishDate.ToString()

            }).FirstOrDefault(x => x.Id == id);
        }

        public ArticleModel GetArticleWithCategory(long id)
        {
            return _context.articles
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel Search)
        {
            var Query = _context.articles.Include(x => x.Category).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Category = x.Category.Name,
                Description = x.Description,
                Title = x.Title,
                PicturePath = x.PicturePath,
                Slug = x.Slug,
                CreationDate = x.CreationDate.ToFarsi(),
                PublishDate = x.PublishDate.ToFarsi(),
            });

            if (!string.IsNullOrWhiteSpace(Search.Title))
            {
                Query = Query.Where(x => x.Title.Contains(Search.Title));
            }

            if (Search.CategoryId > 0)
            {
                Query = Query.Where(x => x.CategoryId == Search.CategoryId);
            }

            return Query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
