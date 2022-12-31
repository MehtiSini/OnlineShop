using ShopManagement.Contracts.Orders;

namespace ShopManagement.Query.Contracts.Cart
{
    public interface ICartCalculator
    {
        CartDetail ComputeCart(List<CartItem> cartItems);
    }
}
