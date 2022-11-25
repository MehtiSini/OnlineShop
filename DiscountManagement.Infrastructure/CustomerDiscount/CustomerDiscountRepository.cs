using Blog.Domain.Tools;
using DiscountManagement.Contracts;
using DiscountManagement.Domain.CusotmerDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace DiscountManagement.Infrastructure.EfCore.CustomerDiscount
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscountModel>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopcontext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopcontext) : base(context)
        {
            _context = context;
            _shopcontext = shopcontext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToShamsi(),
                EndDate = x.EndDate.ToShamsi(),
                Reason = x.Reason
            }).FirstOrDefault(x => x.Id == id);

        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel search)
        {
            var Product = _shopcontext.products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                StartDateEn = x.StartDate,
                EndDateEn = x.EndDate,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToShamsi(),
                EndDate = x.EndDate.ToShamsi(),
                Reason = x.Reason,
                CreationDate=x.CreationDate.ToShamsi()
            });

            if (search.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == search.ProductId);
            }

            if (!string.IsNullOrWhiteSpace(search.StartDate))
            {
                var date = DateTime.Now;
                query = query.Where(x => x.StartDateEn < date);
            }

            if (!string.IsNullOrWhiteSpace(search.EndDate))
            {
                var date = DateTime.Now;
                query = query.Where(x => x.EndDateEn >= date);
            }

            var Discount = query.OrderByDescending(x => x.Id).ToList();

            Discount.ForEach(Discount => Discount.ProductName = Product.FirstOrDefault(x => x.Id == Discount.ProductId).Name);

            return Discount;
        }
    }
}
