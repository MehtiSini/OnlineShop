using MyFramework.Domain;
using MyFramework.Tools;

namespace CommentManagement.Domain.CommentAgg
{
    public class CommentModel : EntityBase
    {
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Website { get; private set; }
        public string? Message { get; private set; }
        public int CommentStatus { get; private set; }
        public int OwnerRecordId { get; private set; }
        public int Type { get; private set; }
        public long ParentId { get; private set; }
        public CommentModel Parent { get; private set; }

        public List<CommentModel> Child { get; private set; }

        public CommentModel(string? name, string? email, string? message,
             int ownerRecordId, int type, string? website, long parentId)
        {
            Name = name;
            Email = email;
            Message = message;
            CommentStatus = OperationComment.Waiting;
            OwnerRecordId = ownerRecordId;
            Type = type;
            Website = website;
            ParentId = parentId;
        }

        public void Confirm()
        {
            CommentStatus = OperationComment.Confirm;
        }


        public void Cancel()
        {
            CommentStatus = OperationComment.Cancel;
        }

    }
}
