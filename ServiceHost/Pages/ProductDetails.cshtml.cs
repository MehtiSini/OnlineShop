using CommentManagement.Contracts.Comment;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Query.Contracts.Product;

namespace ServiceHost.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductQueryModel Product;

        public ProductDetailsModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string Id)
        {
            Product = _productQuery.GetProductDetails(Id);
        }

        public IActionResult OnPost(AddComment Command, string ProductSlug)
        {
            Command.Type = CommentType.Product;
            _commentApplication.Add(Command);
            return RedirectToPage("/ProductDetails", new { Id = ProductSlug });
        }

    }
}
