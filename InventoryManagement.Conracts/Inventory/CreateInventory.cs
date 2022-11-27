using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Conracts.Inventory
{
    public class CreateInventory
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public double UnitPrice { get; set; }

        public List<ProductViewModel>? Products { get; set; }
    }
}
