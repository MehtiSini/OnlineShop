using MyFramework.Domain;

namespace DiscountManagement.Domain.CollegueDiscountAgg
{
    public class CollegueDiscountModel : EntityBase
    {
        public long ProductId { get;private set; }
        public long DiscountRate { get; private set; }
        public bool IsRemoved { get; private set; }

        public CollegueDiscountModel(long productId, long discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsRemoved = false;
        }

        public void Edit(long productId, long discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Activate()
        {
            IsRemoved = false;
        }

    }
}
