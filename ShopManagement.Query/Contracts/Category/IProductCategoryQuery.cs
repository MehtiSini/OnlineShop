using Sm.Contracts.ProductCategory;

namespace ShopManagement.Query.Contracts.Category
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetCategories();
        List<ProductCategoryQueryModel> GetCategoryWithProduct();
    }
}
