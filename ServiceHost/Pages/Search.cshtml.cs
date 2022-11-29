using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Query.Contracts.Product;
using ShopManagement.Query.Query;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        public string? Value { get; set; }

        public List<ProductQueryModel>? Products { get; set; }

        private readonly IProductQuery _ProductQuery;

        public SearchModel(IProductQuery productQuery)
        {
            _ProductQuery = productQuery;
        }

        public void OnGet(string value)
        {
            Value = value;

            Products = _ProductQuery.Search(value);
        }
    }
}
