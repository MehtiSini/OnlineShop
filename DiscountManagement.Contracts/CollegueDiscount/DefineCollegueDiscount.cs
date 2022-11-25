using MyFramework.Tools;
using ShopManagement.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Contracts.CollegueDiscount
{
    public class DefineCollegueDiscount
    {
        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessage.IsRequired)]
        public long DiscountRate { get; set; }

        public List<ProductViewModel>? Products { get; set; }

    }

}
