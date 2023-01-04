using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Conracts.Inventory
{
    public class ReduceInventory
    {
        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public long InventoryId { get; set; }

        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public long Count { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Description { get; set; }

        public long OrderId { get; set; }

        public ReduceInventory()
        {

        }

        public ReduceInventory(long productId, long count, string? description, long orderId)
        {
            ProductId = productId;
            Count = count;
            Description = description;
            OrderId = orderId;
        }
    }
}
