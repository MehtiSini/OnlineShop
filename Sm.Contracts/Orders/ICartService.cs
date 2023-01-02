using ShopManagement.Contracts.Orders;

namespace ShopManagement.Application.Contracts.Orders
{
    public interface ICartService
    {
        void Set(CartDetail cart);
        CartDetail Get();
    }
}
