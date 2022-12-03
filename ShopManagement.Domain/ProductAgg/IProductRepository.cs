using MyFramework.Domain;
using ShopManagement.Contracts.Product;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long,ProductModel>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
        ProductModel GetProductWithCategory(long Id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
