using MyFramework.Tools;

namespace Sm.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory cmd);
        OperationResult Edit(EditProductCategory cmd);
        List<ProductCategoryQueryModel> Search(ProductCategorySearchModel cmd);
        List<ProductCategoryQueryModel> GetProductCategories();
        EditProductCategory GetDetails(long Id);
    }
}
