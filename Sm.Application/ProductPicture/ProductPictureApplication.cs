using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using ShopManagement.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application.ProductPicture
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _repository;

        public ProductPictureApplication(IProductPictureRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateProductPicture cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.PictureTitle == cmd.PictureTitle))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var product = new ProductPictureModel(cmd.ProductId, cmd.PicturePath, cmd.PictureAlt, cmd.PictureTitle);

            _repository.Create(product);

            _repository.Save();

            return operation.Succeed();
        }

        public OperationResult Edit(EditProductPicture cmd)
        {
            var operation = new OperationResult();

            var ProductPicture = _repository.GetById(cmd.Id);

            if (ProductPicture == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            //if (_repository.Exist(x => x.PicturePath == cmd.PicturePath))
            //{
            //    return operation.Failed(OperationMessage.DuplicateRecord);
            //}

            ProductPicture.Edit(cmd.ProductId, cmd.PicturePath, cmd.PictureAlt, cmd.PictureTitle);

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
