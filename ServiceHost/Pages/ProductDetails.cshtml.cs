using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Query.Contracts.Product;
using ShopManagement.Query.Query;

namespace ServiceHost.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProductQuery _productQuery;

        public ProductQueryModel Product;

        public ProductDetailsModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet(string Id)
        {
            Product = _productQuery.GetProductDetails(Id);
        }
    }
}
