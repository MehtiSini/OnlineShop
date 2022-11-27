using Blog.Domain.Tools;
using InventoryManaement.Domain.InventoryAgg;
using InventoryManagement.Conracts.Inventory;
using InventoryManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace InventoryManagement.Infrastructure.EfCore.Inventory
{
    public class InventoryRepository : RepositoryBase<long, InventoryModel>, IInventoryRepository
    {
        private readonly InventoryContext _InventoryContext;

        private readonly ShopContext _Shopcontext;

        public InventoryRepository(InventoryContext inventorycontext, ShopContext shopcontext) : base(inventorycontext)
        {
            _InventoryContext = inventorycontext;
            _Shopcontext = shopcontext;
        }

        public EditInventory GetDetails(long id)
        {
            return _InventoryContext.Inventories.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice

            }).FirstOrDefault(x => x.Id == id);
        }

        public InventoryModel GetInventory(long ProductId)
        {
            return _InventoryContext.Inventories.FirstOrDefault(x => x.ProductId == ProductId);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long InventoryId)
        {
            var Inventory = _InventoryContext.Inventories.FirstOrDefault(x => x.Id == InventoryId);

            return Inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                InventoryId = x.InventoryId,
                OrderId = x.OrderId,
                OperationDate = x.OperationDate.ToShamsi(),
                OperationType = x.OperationType,
                Operator = "مدیر سیسیتم",
                OperatorId = x.OperatorId
                    
            }).OrderBy(x => x.Id).ToList();

        }

        public List<InventoryViewModel> Search(InventorySearchModel Search)
        {
            var products = _Shopcontext.products.Select(x => new { x.Id, x.Name });

            var query = _InventoryContext.Inventories.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToShamsi(),
                IsInStock = x.IsInStock,
                UnitPrice = x.UnitPrice,
                ProductId = x.ProductId,
                CurrentCount = x.CalculateCurrentCount()
            });

            if (Search.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == Search.ProductId);
            }

            //if (Search.IsInStock == OperationStock.InStock)
            //{
            //    query = query.Where(x => x.IsInStock == Search.IsInStock);
            //}

            if (Search.IsInStock == OperationStock.InStock)
            {
                query = query.Where(x => x.IsInStock == 0);
            }

            var Inventory = query.OrderByDescending(x => x.Id).ToList();

            Inventory.ForEach(item =>
            {
                item.ProductName = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            });

            return Inventory;
        }
    }
}
