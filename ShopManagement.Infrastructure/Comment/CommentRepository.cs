using Blog.Domain.Tools;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using ShopManagement.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace ShopManagement.Infrastructure.EfCore.Comment
{
    public class CommentRepository : RepositoryBase<long, CommentModel>, ICommentRepository
    {
        private readonly ShopContext _context;

        public CommentRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> Search(CommentSearchModel search)
        {
            var Query = _context.comments.Include(x => x.Product).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Email = x.Email,
                CommentStatus = x.CommentStatus,
                Message = x.Message,
                Name = x.Name,
                ProductId = x.ProductId,
                Product = x.Product.Name,
                CreationDate=x.Product.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                Query = Query.Where(x => x.Name.Contains(search.Name));
            }

            if (!string.IsNullOrWhiteSpace(search.Email))
            {
                Query = Query.Where(x => x.Email.Contains(search.Email));
            }

            return Query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
