namespace ShopManagement.Query.Contracts.Article
{
    public interface IArticleQuery
    {
        ArticleQueryModel GetArticleDetails(string Slug);
        List<ArticleQueryModel> GetLatestArticles();
    }
}
