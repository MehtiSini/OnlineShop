using MyFramework.Tools;

namespace CommentManagement.Contracts.Comment
{
    public interface ICommentApplication
    {
        OperationResult Add(AddComment Cmd);
        OperationResult Confirm(long id);
        OperationResult Cancel(long id);
        List<CommentViewModel> Search(CommentSearchModel Cmd);
    }
}
