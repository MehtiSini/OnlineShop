using MyFramework.Tools;

namespace InventoryManagement.Contracts.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory cmd);
        OperationResult Edit(EditInventory cmd);
        OperationResult Increase(IncreaseInventory cmd);

        //For Administrator ==>
        //It Can Only Reduce Count of one product at the moment
        OperationResult Reduce(ReduceInventory cmd);

        //For USER ==> is Buying Some Products
        //, Maybe He Chooses more than One Product
        //So We Need lists of Products
        OperationResult Reduce(List<ReduceInventory> cmd);

        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel Search);

        List<InventoryOperationViewModel> GetOperationLog(long InventoryId);

    }
}
