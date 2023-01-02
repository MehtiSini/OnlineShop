using ShopManagement.Application.Contracts.Orders;
using ShopManagement.Contracts.Orders;

namespace ShopManagement.Application.Cart
{
    public class CartService : ICartService
    {
        public CartDetail? Cart { get; set; }

        public CartDetail Get()
        {
            return Cart;
        }

        public void Set(CartDetail cart)
        {
            Cart = cart;
        }
    }
}
