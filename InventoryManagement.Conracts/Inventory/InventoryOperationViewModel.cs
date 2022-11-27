namespace InventoryManagement.Conracts.Inventory
{
    public class InventoryOperationViewModel
    {
        public long Id { get;  set; }
        //External Or Internal Product >>
        public int OperationType { get;  set; }
        public long Count { get;  set; }
        public long OperatorId { get;  set; }
        public string? Operator { get;  set; }
        public string? OperationDate { get;  set; }
        public long CurrentCount { get;  set; }
        public string? Description { get;  set; }
        public long OrderId { get;  set; }
        public long InventoryId { get;  set; }
    }
}
