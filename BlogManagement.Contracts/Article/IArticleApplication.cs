using MyFramework.Tools;

namespace BlogManagement.Contracts.Article
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticle cmd);
        OperationResult Edit(EditArticle cmd);
        EditArticle GetDetails(long Id);
        List<ArticleViewModel> Seacrh(ArticleSearchModel Search);
    }
}
