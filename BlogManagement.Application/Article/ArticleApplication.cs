using Blog.Domain.Tools;
using BlogManagement.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EfCore.ArticleCategory;
using MyFramework.Tools;

namespace BlogManagement.Application.Article
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _repository;
        private readonly IArticleCategoryRepository _Categoryrepository;
        private readonly IFileUploader _fileUploader;

        public ArticleApplication(IArticleRepository repository, IFileUploader fileUploader, IArticleCategoryRepository categoryrepository)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _Categoryrepository = categoryrepository;
        }

        public OperationResult Create (CreateArticle cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.Title == cmd.Title))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var slug = cmd.Slug.ToSlug();

            var CategorySlug = _Categoryrepository.GetSlugById(cmd.CategoryId);

            var Path = $"{CategorySlug}/{slug}";

            var PicturePath = _fileUploader.Upload(cmd.PicturePath, Path);

            var PublishDate = cmd.PublishDate.ToGeorgianDateTime();

            var Article = new ArticleModel(cmd.Title, cmd.CategoryId, cmd.Description, cmd.ShortDescription, 
                cmd.MetaDescription,
                PicturePath, cmd.PictureAlt, cmd.PictureTitle,
                 slug, cmd.Keywords, cmd.CanonicalAddress, PublishDate);

            _repository.Create(Article);
            _repository.Save();
            return operation.Succeed();
        }

        public OperationResult Edit(EditArticle cmd)
        {
            var operation = new OperationResult();

            var Article = _repository.GetArticleWithCategory(cmd.Id);

            if (Article == null)
            {
                operation.Failed(OperationMessage.DuplicateRecord);
            }

            var slug = cmd.Slug.ToSlug();

            var Path = $"{Article.Category.Slug}/{slug}";

            var PicturePath = _fileUploader.Upload(cmd.PicturePath, Path);

            var PublishDate = cmd.PublishDate.ToGeorgianDateTime();

            Article.Edit(cmd.Title, cmd.CategoryId, cmd.Description, cmd.ShortDescription, cmd.MetaDescription,
                PicturePath, cmd.PictureAlt, cmd.PictureTitle,
                 slug, cmd.Keywords, cmd.CanonicalAddress, PublishDate);

            _repository.Save();
            return operation.Succeed();
        }

        public EditArticle GetDetails(long Id)
        {
            return _repository.GetDetails(Id);
        }

        public List<ArticleViewModel> Seacrh(ArticleSearchModel Search)
        {
            return _repository.Search(Search);

        }
    }
}
