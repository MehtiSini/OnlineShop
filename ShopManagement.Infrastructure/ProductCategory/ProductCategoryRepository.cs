﻿using Blog.Domain.Tools;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using Sm.Contracts.ProductCategory;
using System.Linq.Expressions;

namespace ShopManagement.Infrastructure.EfCore.ProductCategory
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategoryModel>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public string GetSlugById(long id)
        {
            return _context.productCategories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.productCategories.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                KeyWords = x.KeyWords,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureTitle,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.productCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();

        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.productCategories.Include(x => x.Products).Select(x => new ProductCategoryViewModel
            {
                CreationDate = x.CreationDate.ToShamsi(),
                Id = x.Id,
                Name = x.Name,
                PicturePath = x.PicturePath,
                ProductsCount = x.Products.Count,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            }


            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
