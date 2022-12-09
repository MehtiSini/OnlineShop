namespace ShopManagement.Query.Contracts.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        ArticleCategoryQueryModel GetArticleCategoryDetails(string Slug);
        List<ArticleCategoryQueryModel> GetArticleCategories();
    }
}
