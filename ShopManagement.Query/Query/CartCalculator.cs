using DiscountManagement.Infrastructure.EfCore.DbContextModel;
using MyFramework.Tools;
using MyFramework.Tools.Authentication;
using ShopManagement.Contracts.Orders;
using ShopManagement.Query.Contracts.Cart;

namespace ShopManagement.Query.Query
{
    public class CartCalculator : ICartCalculator
    {
        private readonly DiscountContext _discountContext;
        private readonly IAuthHelper _authHelper;

        public CartCalculator(DiscountContext discountContext, IAuthHelper authHelper)
        {
            _discountContext = discountContext;
            _authHelper = authHelper;
        }

        public CartDetail ComputeCart(List<CartItem> cartItems)
        {
            return Calculator(_discountContext, _authHelper , cartItems , new CartDetail());
        }


        public static CartDetail Calculator(DiscountContext _discountContext , IAuthHelper _authHelper, List<CartItem> items , CartDetail Cart)
        {
            
            var CollegueDiscount = _discountContext.CollegueDiscount.Where(x => x.IsRemoved == false)
              .Select(x => new { x.ProductId, x.DiscountRate }).ToList();

            var CustomerDiscount = _discountContext.CustomerDiscount.Where(x => x.DiscountFinished == false)
                .Select(x => new { x.ProductId, x.DiscountRate }).ToList();

            var CuurentRole = _authHelper.GetCurrentAccountRole();

            foreach (var item in items)
            {
                if (CuurentRole == Roles.CollegueUser)
                {
                    var collegueDiscount = CollegueDiscount.FirstOrDefault(x => x.ProductId == item.Id);
                    if (CollegueDiscount != null)
                    {
                        item.DiscountRate = collegueDiscount.DiscountRate;
                    }
                }
                else
                {
                    var customerDiscount = CustomerDiscount.FirstOrDefault(x => x.ProductId == item.Id);
                    if (customerDiscount != null)
                    {
                        item.DiscountRate = customerDiscount.DiscountRate;
                    }
                }

                item.DiscountAmount = (item.TotalPrice * item.DiscountRate) / 100;
                item.ItemPayAmount = item.TotalPrice - item.DiscountAmount;
                Cart.Add(item);
            }

            return Cart;
        }

    }
}
