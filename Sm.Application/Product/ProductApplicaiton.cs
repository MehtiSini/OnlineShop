using Blog.Domain.Tools;
using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using ShopManagement.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application.Product
{
    public class ProductApplicaiton : IProductApplication
    {
        private readonly IFileUploader _fileUploader;

        private readonly IProductRepository _repository;

        private readonly IProductCategoryRepository _CategoryRepository;

        public ProductApplicaiton(IProductRepository repository, IFileUploader fileUploader, IProductCategoryRepository categoryRepository)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _CategoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateProduct cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.Name == cmd.Name))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var CategorySlug = _CategoryRepository.GetSlugById(cmd.CategoryId);

            var PictureSlugPath = cmd.Slug;

            var slug = cmd.Slug.ToSlug();

            var Path = $"{CategorySlug}/{slug}";

            var FileName = _fileUploader.Upload(cmd.PicturePath, Path);

            var product = new ProductModel(cmd.Name, cmd.Code, FileName
                , cmd.PictureAlt, cmd.PictureTitle, cmd.Description, cmd.ShortDescription,
                cmd.MetaDescription, slug, cmd.Keywords, cmd.CategoryId);

            _repository.Create(product);

            _repository.Save();

            return operation.Succeed();
        }

        public OperationResult Edit(EditProduct cmd)
        {
            var operation = new OperationResult();

            var Product = _repository.GetProductWithCategory(cmd.Id);

            if (Product == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            if (_repository.Exist(x => x.Name == cmd.Name && x.Id != cmd.Id))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var CategorySlug = Product.Category.Slug;

            var PictureSlugPath = cmd.Slug;

            var slug = cmd.Slug.ToSlug();

            var Path = $"{CategorySlug}/{slug}";

            var FileName = _fileUploader.Upload(cmd.PicturePath, Path);

            Product.Edit(cmd.Name, cmd.Code, FileName
                , cmd.PictureAlt, cmd.PictureTitle,
                cmd.ShortDescription, cmd.Description, cmd.MetaDescription, cmd.Keywords, cmd.CategoryId, slug);

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
