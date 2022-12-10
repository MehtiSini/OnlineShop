using CommentManagement.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using MyFramework.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long,CommentModel>
    {
        List<CommentViewModel> Search(CommentSearchModel search);
    }
}
