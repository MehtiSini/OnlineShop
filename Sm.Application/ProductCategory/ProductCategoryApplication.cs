using Blog.Domain.Tools;
using MyFramework.Tools;
using ShopManagement.Domain.ProductCategoryAgg;
using Sm.Contracts.ProductCategory;

namespace Sm.Application.ProductCategory
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IFileUploader _fileUploader;

        private readonly IProductCategoryRepository _repository;

        public ProductCategoryApplication(IProductCategoryRepository repository, IFileUploader fileUploader)
        {
            _repository = repository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.Name == cmd.Name))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var slug = cmd.Slug.ToSlug();

            var PicturePath = _fileUploader.Upload(cmd.PicturePath,cmd.Slug);

            var category = new ProductCategoryModel(cmd.PictureAlt, cmd.Name, cmd.PictureTitle, PicturePath,
                cmd.Description, cmd.KeyWords, cmd.MetaDescription, slug.ToString());

            _repository.Create(category);
            _repository.Save();
            return operation.Succeed();
        }

        public OperationResult Edit(EditProductCategory cmd)
        {
            var operation = new OperationResult();

            var ProductCategory = _repository.GetById(cmd.Id);

            if (ProductCategory == null)
            {
                operation.Failed(OperationMessage.NotFound);
            }

            if (_repository.Exist(x => x.Name == cmd.Name && x.Id != cmd.Id))
            {
                operation.Failed(OperationMessage.DuplicateRecord);
            }

            var slug = cmd.Slug.ToSlug();

            var PicturePath = _fileUploader.Upload(cmd.PicturePath, cmd.Slug);

            ProductCategory.Edit(cmd.Name, cmd.Description, PicturePath, cmd.PictureAlt,
         cmd.PictureTitle, cmd.KeyWords, cmd.MetaDescription, slug);

            _repository.Save();
            return operation.Succeed();
        }

        public EditProductCategory GetDetails(long Id)
        {
            return _repository.GetDetails(Id);
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {

            return _repository.GetProductCategories();

        }

        public List<ProductCategoryQueryModel> Search(ProductCategorySearchModel cmd)
        {
            return _repository.Search(cmd);
        }
    }
}
