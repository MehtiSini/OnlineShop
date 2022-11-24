using MyFramework.Domain;
using Sm.Contracts.ProductCategory;
using System.Linq.Expressions;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long,ProductCategoryModel>
    {
        List<ProductCategoryQueryModel> GetProductCategories();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryQueryModel> Search(ProductCategorySearchModel searchModel);
    }
}
