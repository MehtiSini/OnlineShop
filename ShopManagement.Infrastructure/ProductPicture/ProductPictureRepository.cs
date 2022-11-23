using Blog.Domain.Tools;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using ShopManagement.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using System.Linq.Expressions;

namespace ShopManagement.Infrastructure.EfCore.ProductPicture
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPictureModel>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.productPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                ProductId = x.ProductId,
                PicturePath = x.PicturePath,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,

            }).FirstOrDefault(x => x.Id == id);

        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.productPictures.Include(X => X.Product).Select(x => new ProductPictureViewModel
            {
                Id = x.Id.ToString(),
                PicturePath = x.PicturePath,
                CreationDate = x.CreationDate.ToShamsi(),
                Product = x.Product.Name,
                ProductId = x.ProductId.ToString(),
                IsRemoved=x.IsRemoved
            });

            if (searchModel.ProductId != 0)
            {
                query = query.Where(x => x.ProductId.Contains(searchModel.ProductId.ToString()));
            }

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
