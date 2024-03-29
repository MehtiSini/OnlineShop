﻿using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Contracts.Inventory
{
    public class CreateInventory
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 1000000000000000, ErrorMessage = ValidationMessage.IsRequired)]
        public double UnitPrice { get; set; }

        public List<ProductViewModel>? Products { get; set; }
    }
}
