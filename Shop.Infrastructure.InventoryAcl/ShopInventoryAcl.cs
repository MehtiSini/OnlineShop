using InventoryManagement.Conracts.Inventory;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;

namespace Shop.Infrastructure.InventoryAcl
{
    public class ShopInventoryAcl : IShopInventoryAcl
    {
        private readonly IInventoryApplication _inventoryApplication;

        public ShopInventoryAcl(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }

        public bool ReduceFromInventory(List<OrderItem> items)
        {
            var Command = new List<ReduceInventory>();

            foreach (var orderItem in items)
            {
                var Item = new ReduceInventory(orderItem.ProductId,orderItem.Count,"خرید مشتری" , orderItem.OrderId);

                Command.Add(Item);
            }
            return _inventoryApplication.Reduce(Command).IsSucceed;
        }
    }
}