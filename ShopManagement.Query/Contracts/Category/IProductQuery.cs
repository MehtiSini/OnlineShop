using ShopManagement.Query.Contracts.Product;

namespace ShopManagement.Query.Contracts.Category
{
    public interface IProductQuery
    {
        public List<ProductQueryModel> GetlatestArrivals();
    }
}
