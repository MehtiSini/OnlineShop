using Blog.Domain.Tools;
using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using ShopManagement.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application.Product
{
    public class ProductApplicaiton : IProductApplication
    {
        private readonly IProductRepository _repository;

        public ProductApplicaiton(IProductRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateProduct cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.Name == cmd.Name))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var slug = cmd.Slug.ToSlug();

            var product = new ProductModel(cmd.Name, cmd.Code, cmd.PicturePath
                , cmd.PictureAlt, cmd.PictureTitle, cmd.Description, cmd.ShortDescription, cmd.MetaDescription, slug, cmd.Keywords, cmd.CategoryId);

            _repository.Create(product);

            _repository.Save();

            return operation.Succeed();

        }

        public OperationResult Edit(EditProduct cmd)
        {
            var operation = new OperationResult();

            var Product = _repository.GetById(cmd.Id);

            if (Product == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            if (_repository.Exist(x => x.Name == cmd.Name && x.Id != cmd.Id))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var slug = cmd.Slug.ToSlug();

            Product.Edit(cmd.Name, cmd.Code, cmd.PicturePath
                , cmd.PictureAlt, cmd.PictureTitle, cmd.Description, cmd.ShortDescription, cmd.MetaDescription, cmd.Keywords, cmd.CategoryId,slug);

            _repository.Save();

            return operation.Succeed();

        }

        public EditProduct GetDetails(long Id)
        {
            return _repository.GetDetails(Id);

        }

        public List<ProductViewModel> GetProducts()
        {
            return _repository.GetProducts();

        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }
}
