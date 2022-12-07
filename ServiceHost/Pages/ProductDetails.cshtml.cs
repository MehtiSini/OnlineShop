using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Contracts.Comment;
using ShopManagement.Query.Contracts.Product;
using ShopManagement.Query.Query;

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
            _commentApplication.Add(Command);

            return RedirectToPage("/ProductDetails", new { Id = ProductSlug });
        }

    }
}
