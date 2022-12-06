using MyFramework.Tools;
using ShopManagement.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;

namespace ShopManagement.Application.Comment
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
                Cmd.ProductId);

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

        public List<CommentViewModel> Search(CommentSearchModel Cmd)
        {
            return _commentRepository.Search(Cmd);
        }
    }
}
