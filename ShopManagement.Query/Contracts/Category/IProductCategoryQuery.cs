using Sm.Contracts.ProductCategory;

namespace ShopManagement.Query.Contracts.Category
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetCategoryWithProductsBy(string Slug);
        List<ProductCategoryQueryModel> GetCategories();
        List<ProductCategoryQueryModel> GetCategoryWithProduct();
    }
}
