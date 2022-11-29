using Microsoft.AspNetCore.Mvc;
using ShopManagement.Query.Contracts.Product;

namespace ServiceHost.ViewComponents
{
    public class LatestArrivalsViewComponent : ViewComponent
    {
        private readonly IProductQuery _query;

        public LatestArrivalsViewComponent(IProductQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var Product = _query.GetlatestArrivals();

            return View(Product);
        }

    }
}
