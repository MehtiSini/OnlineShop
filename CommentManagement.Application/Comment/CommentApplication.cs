using CommentManagement.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using MyFramework.Tools;

namespace CommentManagement.Application.Comment
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult Add(AddComment Cmd)
        {
            var operation = new OperationResult();

            var Comment = new CommentModel(Cmd.Name, Cmd.Email, Cmd.Message,
                Cmd.OwnerRecordId, Cmd.Type, Cmd.Website, Cmd.ParentId);

            _commentRepository.Create(Comment);

            _commentRepository.Save();
            return operation.Succeed();
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();

            var Comment = _commentRepository.GetById(id);

            if (Comment == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Comment.Cancel();
            _commentRepository.Save();
            return operation.Succeed();
        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();

            var Comment = _commentRepository.GetById(id);

            if (Comment == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Comment.Confirm();
            _commentRepository.Save();
            return operation.Succeed();
        }

        public string GetTypeName(int Type, long OwnerRecordId)
        {
           return _commentRepository.GetTypeName(Type, OwnerRecordId);
        }

        public List<CommentViewModel> Search(CommentSearchModel Search)
        {
            return _commentRepository.Search(Search);
        }
    }
}
