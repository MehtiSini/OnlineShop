using MyFramework.Tools;
using ShopManagement.Contracts.ProductPicture;
using Sm.Contracts.ProductCategory;

namespace ShopManagement.Contracts.Product
{
    public interface IProductApplication  
    {
        OperationResult Create(CreateProduct cmd);
        OperationResult Edit(EditProduct cmd);
        EditProduct GetDetails(long Id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetProducts();
    }
}
