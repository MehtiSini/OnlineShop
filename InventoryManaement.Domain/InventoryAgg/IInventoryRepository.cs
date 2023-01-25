using InventoryManagement.Contracts.Inventory;
using MyFramework.Domain;

namespace InventoryManaement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long,InventoryModel>
    {
        EditInventory GetDetails(long id);
        InventoryModel GetInventory(long ProductId);
        List<InventoryViewModel> Search(InventorySearchModel Search);

        List<InventoryOperationViewModel> GetOperationLog(long InventoryId);


    }
}
