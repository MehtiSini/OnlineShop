using Blog.Domain.Tools;
using MyFramework.Tools;
using ShopManagement.Contracts.Product;
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
                return operation.Failed(OperationMessage.DuplicateName);
            }

            var slug = cmd.Slug.ToSlug();

            var product = new ProductModel(cmd.Name, cmd.Code, cmd.UnitPrice, cmd.PicturePath
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

            if (_repository.Exist(x => x.Name == cmd.Name && x.Id == cmd.Id))
            {
                return operation.Failed(OperationMessage.DuplicateName);
            }

            Product.Edit(cmd.Name, cmd.Code, cmd.UnitPrice, cmd.PicturePath
                , cmd.PictureAlt, cmd.PictureTitle, cmd.Description, cmd.ShortDescription, cmd.MetaDescription, cmd.Keywords, cmd.CategoryId);

            _repository.Save();

            return operation.Succeed();

        }

        public EditProduct GetDetails(long Id)
        {
            return _repository.GetDetails(Id);

        }

        public OperationResult InStock(long Id)
        {
            var operation = new OperationResult();

            var Product = _repository.GetById(Id);

            if (Product == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Product.InStock();
            _repository.Save();

            return operation.Succeed();

        }

        public OperationResult OutOfStock(long Id)
        {
            var operation = new OperationResult();

            var Product = _repository.GetById(Id);

            if (Product == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Product.OutOfStock();
            _repository.Save();

            return operation.Succeed();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }
}
