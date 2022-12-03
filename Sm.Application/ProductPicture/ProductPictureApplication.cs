using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using ShopManagement.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application.ProductPicture
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _repository;

        private readonly IProductRepository _productrepository;

        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository repository, IFileUploader fileUploader, IProductRepository productrepository)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _productrepository = productrepository;
        }

        public OperationResult Create(CreateProductPicture cmd)
        {
            var operation = new OperationResult();

            var Product = _productrepository.GetProductWithCategory(cmd.ProductId);

            var Path = $"{Product.Category.Slug}/{Product.Slug}";

            var FileName = _fileUploader.Upload(cmd.PicturePath, Path);

            var product = new ProductPictureModel(cmd.ProductId, FileName, cmd.PictureAlt, cmd.PictureTitle);

            _repository.Create(product);

            _repository.Save();

            return operation.Succeed();
        }

        public OperationResult Edit(EditProductPicture cmd)
        {
            var operation = new OperationResult();

            var ProductPicture = _repository.GetProductWithCategory(cmd.Id);

            if (ProductPicture == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            var Path = $"{ProductPicture.Product.Category.Slug}/{ProductPicture.Product.Slug}";

            var PicturePath = _fileUploader.Upload(cmd.PicturePath, Path);

            ProductPicture.Edit(cmd.ProductId, PicturePath, cmd.PictureAlt, cmd.PictureTitle);

            _repository.Save();
            return operation.Succeed();
        }

        public EditProductPicture GetDetails(long Id)
        {
            return _repository.GetDetails(Id);
        }

        public OperationResult Remove(long Id)
        {
            var operation = new OperationResult();

            var Product = _repository.GetById(Id);

            if (Product == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Product.Remove();
            _repository.Save();

            return operation.Succeed();
        }

        public OperationResult Activate(long Id)
        {
            var operation = new OperationResult();

            var Product = _repository.GetById(Id);

            if (Product == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Product.Activate();
            _repository.Save();

            return operation.Succeed();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }

    }
}
