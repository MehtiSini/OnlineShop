using MyFramework.Domain;
using MyFramework.Infrastructure;
using MyFramework.Tools;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.CommentAgg
{
    public class CommentModel : EntityBase
    {
        public long ProductId { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Message { get; private set; }
        public int CommentStatus { get; private set; }

        public ProductModel? Product { get; private set; }

        public CommentModel()
        {

        }

        public CommentModel(string? name, string? email, string? message, long productId)
        {
            Name = name;
            Email = email;
            Message = message;
            ProductId = productId;
            CommentStatus = OperationComment.Waiting;
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
