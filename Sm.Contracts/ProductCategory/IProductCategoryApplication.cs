using MyFramework.Tools;

namespace Sm.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory cmd);
        OperationResult Edit(EditProductCategory cmd);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel cmd);
        List<ProductCategoryViewModel> GetProductCategories();
        EditProductCategory GetDetails(long Id);
    }
}
