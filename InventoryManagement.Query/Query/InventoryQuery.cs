using InventoryManagement.Infrastructure.EfCore.DbContextModel;
using InventoryManagement.Query.Contracts;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace InventoryManagement.Query.Query
{
    public class InventoryQuery : IInventoryQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _InventoryContext;

        public InventoryQuery(ShopContext shopContext, InventoryContext inventoryContext)
        {
            _shopContext = shopContext;
            _InventoryContext = inventoryContext;
        }

        public StockStatus CheckStock(IsInStock Command)
        {
            var Inventory = _InventoryContext.Inventories.FirstOrDefault(x => x.ProductId == Command.ProductId);

            var productName = _shopContext.products.FirstOrDefault(x => x.Id == Command.ProductId).Name;

            if (Inventory == null || Inventory.CalculateCurrentCount() < Command.count)
            {
                return new StockStatus
                {
                    InStock = false,
                    ProductName = productName
                };
            };

            return new StockStatus
            {
                InStock = true
            };
        }
    }
}
