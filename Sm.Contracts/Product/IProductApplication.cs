using MyFramework.Tools;
using ShopManagement.Contracts.ProductPicture;

namespace ShopManagement.Contracts.Product
{
    public interface IProductApplication  
    {
        OperationResult Create(CreateProduct cmd);
        OperationResult Edit(EditProduct cmd);
        OperationResult InStock(long Id);
        OperationResult OutOfStock(long Id);
        EditProduct GetDetails(long Id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
