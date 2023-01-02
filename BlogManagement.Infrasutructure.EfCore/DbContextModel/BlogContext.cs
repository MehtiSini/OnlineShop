using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.DbContextModel
{
    public class BlogContext : DbContext
    {
        public DbSet<ArticleCategoryModel> categories { get; set; }
        public DbSet<ArticleModel> articles { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)   
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(BlogContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
