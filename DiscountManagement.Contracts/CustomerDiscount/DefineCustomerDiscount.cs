using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Contracts.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public int DiscountRate { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? StartDate { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? EndDate { get; set; }

        [Required( ErrorMessage = ValidationMessage.IsRequired)]
        public string? Reason { get; set; }

        public List<ProductViewModel>? Products { get; set; }
    }

}