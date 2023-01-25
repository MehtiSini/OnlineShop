using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Contracts.Inventory
{
    public class IncreaseInventory
    {
        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }
        public long InventoryId { get; set; }
        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public long Count { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Description { get; set; }
    }
}
