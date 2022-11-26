using MyFramework.Domain;

namespace InventoryManaement.Domain.InventoryAgg
{
    public class InventoryModel : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public int IsInStock { get; private set; }
        public List<InventoryOperation>? Operations { get; private set; }
    }

    public class InventoryOperation
    {
        public long Id { get; private set; }
        //External Or Internal Product >>
        public int OperationType { get; private set; }
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string? Description { get; private set; }
        public long OrderId { get; private set; }
        public long InventoryId { get; private set; }
        public InventoryModel? Inventory { get; private set; }
    }

}