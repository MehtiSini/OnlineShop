using BlogManagement.Application.ArticleCategory;
using BlogManagement.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EfCore.ArticleCategory;
using BlogManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Configuration
{
    public class BlogBootStrapper
    {
        public void ConfigService(IServiceCollection service , string ConnString)
        {
            service.AddTransient<IArticleCategoryRepository , ArticleCategoryRepository>();

            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            service.AddDbContext<BlogContext>(x => x.UseSqlServer(ConnString));

        }
    }
}