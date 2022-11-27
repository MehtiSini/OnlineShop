namespace InventoryManagement.Conracts.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string? ProductName { get; set; }
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int IsInStock { get; set; }
        public long CurrentCount { get; set; }
        public string? CreationDate { get; set; }
    }

}
