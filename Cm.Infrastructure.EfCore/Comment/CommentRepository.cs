using Blog.Domain.Tools;
using BlogManagement.Infrastructure.EfCore.DbContextModel;
using CommentManagement.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace CommentManagement.Infrastructure.EfCore.Comment
{
    public class CommentRepository : RepositoryBase<long, CommentModel>, ICommentRepository
    {
        private readonly CommentContext _commentContext;
        private readonly ShopContext _shopContext;
        private readonly BlogContext _blogContext;

        public CommentRepository(CommentContext context, ShopContext shopContext, BlogContext blogontext) : base(context)
        {
            _commentContext = context;
            _shopContext = shopContext;
            _blogContext = blogontext;
        }

        public string GetTypeName(int Type, long OwnerRecordId)
        {
            if (Type == 1)
            {
                return _shopContext.products.FirstOrDefault(x => x.Id == OwnerRecordId).Name;
            }

            if (Type == 2)
            {
                return _blogContext.articles.FirstOrDefault(x => x.Id == OwnerRecordId).Title;
            }

            return "";
        }

        public List<CommentViewModel> Search(CommentSearchModel search)
        {
            var Query = _commentContext.comments.Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Website = x.Website,
                CreationDate = x.CreationDate.ToFarsi(),
                CommentStatus = x.CommentStatus,
                Message = x.Message,
                OnwerRecordID = x.OwnerRecordId,
                Type=x.Type
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
