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
            var category = new ShopManagement.Domain.ProductCategoryAgg.ProductCategory (cmd.PictureAlt, cmd.Name, cmd.PictureTitle, cmd.PicturePath,
                cmd.Description, cmd.KeyWords, cmd.MetaDescription, cmd.Slug);

            _repository.Create(category);
            _repository.SaveChanges();
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

            ProductCategory.Edit(cmd.PictureAlt, cmd.Name,
                cmd.PictureTitle, cmd.PicturePath,
                cmd.Description, cmd.KeyWords, cmd.MetaDescription, cmd.Slug);

            _repository.SaveChanges();
            return operation.Succeed();
        }

        public EditProductCategory GetDetails(long Id)
        {
           return  _repository.GetDetails(Id);

        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel cmd)
        {
          return   _repository.Search(cmd);
        }
    }
}
