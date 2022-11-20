using MyFramework.Tools;

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
