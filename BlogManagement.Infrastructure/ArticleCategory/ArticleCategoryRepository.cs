using Blog.Domain.Tools;
using BlogManagement.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools;

namespace BlogManagement.Infrastructure.EfCore.ArticleCategory
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategoryModel>, IArticleCategoryRepository
    {
        private readonly BlogContext _context;

        public ArticleCategoryRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _context.categories.Select(x => new ArticleCategoryViewModel
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();
        }


        public EditArticleCategory GetDetails(long id)
        {
            return _context.categories.Select(x => new EditArticleCategory
            {
                Id = x.Id,
                ShowOrder = x.ShowOrder,
                CanonicalAddress = x.CanonicalAddress,
                Slug = x.Slug,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle

            }).FirstOrDefault(x => x.Id == id);

        }

        public string GetSlugById(long id)
        {
            return _context.categories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel Search)
        {
            var Query = _context.categories.Include(x=>x.Articles).Select(x => new ArticleCategoryViewModel
            {
                Id=x.Id,
                ShowOrder = x.ShowOrder,
                Description = x.Description,
                Name = x.Name,
                PicturePath = x.PicturePath,
                Slug = x.Slug,
                ArticlesCount=x.Articles.Count,
                CreationDate=x.CreationDate.ToShamsi()
            });

            if (!string.IsNullOrWhiteSpace(Search.Name))
            {
                Query = Query.Where(x => x.Name.Contains(Search.Name));
            }

            return Query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
