using Blog.Domain.Tools;
using MyFramework.Tools;
using ShopManagement.Domain.ProductCategoryAgg;
using Sm.Contracts.ProductCategory;

namespace Sm.Application.ProductCategory
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryApplication(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateProductCategory cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.Name == cmd.Name))
            {
                return operation.Failed("این نام قبلا ثبت شده است");
            }

            var slug = cmd.Slug.ToSlug;

            var category = new ShopManagement.Domain.ProductCategoryAgg.ProductCategoryModel(cmd.PictureAlt, cmd.Name, cmd.PictureTitle, cmd.PicturePath,
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
                operation.Failed("عملیات ویرایش انجام نشد");
            }

            if (_repository.Exist(x => x.Name == cmd.Name && x.Id != cmd.Id))
            {
                operation.Failed("عملیات ویرایش انجام نشد");
            }

            var slug = cmd.Slug.ToSlug;

            ProductCategory.Edit(cmd.PictureAlt, cmd.Name,
                cmd.PictureTitle, cmd.PicturePath,
                cmd.Description, cmd.KeyWords, cmd.MetaDescription, slug.ToString());

            _repository.Save();
            return operation.Succeed();
        }

        public EditProductCategory GetDetails(long Id)
        {
            return _repository.GetDetails(Id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel cmd)
        {
            return _repository.Search(cmd);
        }
    }
}
