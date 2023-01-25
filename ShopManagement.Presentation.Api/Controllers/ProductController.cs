using Microsoft.AspNetCore.Mvc;
using ShopManagement.Query.Contracts.Product;

namespace InventoryManagement.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery _Query;

        public ProductController(IProductQuery query)
        {
            _Query = query;
        }

        [HttpGet]
        public List<ProductQueryModel> GetArrivals()
        {
            return _Query.GetlatestArrivals();
        }

    }
}
