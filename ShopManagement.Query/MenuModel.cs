using ShopManagement.Query.Contracts.ArticleCategory;
using ShopManagement.Query.Contracts.Category;

namespace ShopManagement.Query
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel>? ArticleCategories{ get; set; }
        public List<ProductCategoryQueryModel>? ProductCategories { get; set; }
    }
}
