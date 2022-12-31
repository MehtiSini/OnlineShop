using Blog.Domain.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace ShopManagement.Infrastructure.EfCore.Product
{
    public class ProductRepository : RepositoryBase<long, ProductModel>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                MetaDescription = x.MetaDescription,
                Code = x.Code,
                CategoryId = x.CategoryId,
                Keywords = x.Keywords,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }


        public List<ProductViewModel> GetProducts()
        {
            return _context.products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.products.Include(x => x.Category).Select(x => new ProductViewModel
            {
                Name = x.Name,
                Code = x.Code.ToString(),
                Id = x.Id,
                CreationDate = x.CreationDate.ToShamsi(),
                PicturePath = x.PicturePath,
                CategoryName = x.Category.Name,
                CategoryId = x.CategoryId,
                Slug = x.Slug
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
            {
                query = query.Where(x => x.Code.Contains(searchModel.Code.ToString()));
            }

            if (searchModel.CategoryId != 0)
            {

                query = query.Where(x => x.CategoryId == searchModel.CategoryId);
            }

            return query.OrderByDescending(x => x.Id).ToList();

        }

        public ProductModel GetProductWithCategory(long id)
        {
            return _context.products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }
    }
}
