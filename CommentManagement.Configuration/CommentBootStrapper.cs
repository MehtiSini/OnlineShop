using CommentManagement.Application.Comment;
using CommentManagement.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EfCore.Comment;
using CommentManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Configuration
{
    public class CommentBootStrapper
    {
        public void ConfigService(IServiceCollection service , string ConnString)
        { 
            service.AddTransient<ICommentApplication, CommentApplication>();
            service.AddTransient<ICommentRepository, CommentRepository>();

            service.AddDbContext<CommentContext>(x => x.UseSqlServer(ConnString));
        }
    }
}