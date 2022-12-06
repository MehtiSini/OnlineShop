using MyFramework.Domain;
using MyFramework.Infrastructure;
using ShopManagement.Contracts.Comment;

namespace ShopManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long,CommentModel>
    {
        List<CommentViewModel> Search(CommentSearchModel search);
    }
}
