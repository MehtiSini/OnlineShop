using Blog.Domain.Tools;
using DiscountManagement.Contracts.CollegueDiscount;
using DiscountManagement.Domain.CollegueDiscountAgg;
using DiscountManagement.Infrastructure.EfCore.DbContextModel;
using MyFramework.Infrastructure;
using MyFramework.Tools;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace DiscountManagement.Infrastructure.EfCore.CollegueDiscount
{
    public class CollegueDiscountRepository : RepositoryBase<long, CollegueDiscountModel>, ICollegueDiscountRepository
    {
        private readonly DiscountContext _DiscountContext;

        private readonly ShopContext _shopContext;

        public CollegueDiscountRepository(DiscountContext discountContext, ShopContext shopContext) : base(discountContext)
        {
            _DiscountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditCollegueDiscount GetDetails(long id)
        {
            return _DiscountContext.CollegueDiscount.Select(x => new EditCollegueDiscount
            {

                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel search)
        {
            var Product = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _DiscountContext.CollegueDiscount.Select(x => new CollegueDiscountViewModel
            {
                CreationDate = x.CreationDate.ToShamsi(),
                DiscountRate = x.DiscountRate,
                ID = x.Id,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemoved

            });

            if (search.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == search.ProductId);
            }

            var Discount = query.OrderByDescending(x => x.ID).ToList();

            Discount.ForEach(Discount => Discount.ProductName = Product.FirstOrDefault(x => x.Id == Discount.ProductId).Name);

            return Discount;


        }
    }
}
