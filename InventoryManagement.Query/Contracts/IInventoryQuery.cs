namespace InventoryManagement.Query.Contracts
{
    public interface IInventoryQuery
    {
        public StockStatus CheckStock(IsInStock Command);
    }
}
