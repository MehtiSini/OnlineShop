using Blog.Domain.Tools;
using BlogManagement.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using MyFramework.Tools;

namespace BlogManagement.Application.ArticleCategory
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;

        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository repository, IFileUploader fileUploader)
        {
            _repository = repository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.Name == cmd.Name))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var slug = cmd.Slug.ToSlug();

            var PicturePath = _fileUploader.Upload(cmd.PicturePath, slug);

            var Category = new ArticleCategoryModel(cmd.Name, PicturePath, cmd.PictureAlt, cmd.PictureTitle,
                cmd.Description, cmd.ShowOrder, slug, cmd.MetaDescription, cmd.Keywords, cmd.CanonicalAddress);

            _repository.Create(Category);
            _repository.Save();
            return operation.Succeed();

        }

        public OperationResult Edit(EditArticleCategory cmd)
        {
            var operation = new OperationResult();

            var Category = _repository.GetById(cmd.Id);

            if(Category == null)
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var slug = cmd.Slug.ToSlug();

            var PicturePath = _fileUploader.Upload(cmd.PicturePath, slug);

            Category.Edit(cmd.Name, PicturePath, cmd.PictureAlt, cmd.PictureTitle,
                cmd.Description, cmd.ShowOrder, slug, cmd.MetaDescription, cmd.Keywords, cmd.CanonicalAddress);

            _repository.Save();
            return operation.Succeed();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _repository.GetArticleCategories();
        }

        public EditArticleCategory GetDetails(long Id)
        {
            return _repository.GetDetails(Id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel Search)
        {
            return _repository.Search(Search);
        }
    }
}
