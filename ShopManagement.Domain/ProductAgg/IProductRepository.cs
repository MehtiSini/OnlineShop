using MyFramework.Domain;
using ShopManagement.Contracts.Product;
using Sm.Contracts.ProductCategory;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long,ProductModel>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
