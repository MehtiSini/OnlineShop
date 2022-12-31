using BlogManagement.Application.Article;
using BlogManagement.Application.ArticleCategory;
using BlogManagement.Contracts.Article;
using BlogManagement.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EfCore.Article;
using BlogManagement.Infrastructure.EfCore.ArticleCategory;
using BlogManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Query.Contracts.Article;
using ShopManagement.Query.Contracts.ArticleCategory;
using ShopManagement.Query.Query;

namespace BlogManagement.Configuration
{
    public class BlogBootStrapper
    {
        public void ConfigService(IServiceCollection service , string ConnString)
        {
            service.AddTransient<IArticleCategoryRepository , ArticleCategoryRepository>();
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddTransient<IArticleApplication, ArticleApplication>();

            service.AddTransient<IArticleQuery, ArticleQuery>();
            service.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

            service.AddDbContext<BlogContext>(x => x.UseSqlServer(ConnString));

        }
    }
}