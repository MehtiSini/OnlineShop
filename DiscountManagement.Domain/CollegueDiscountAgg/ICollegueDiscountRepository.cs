using DiscountManagement.Contracts.CollegueDiscount;
using MyFramework.Domain;

namespace DiscountManagement.Domain.CollegueDiscountAgg
{
    public interface ICollegueDiscountRepository:IRepository<long,CollegueDiscountModel>
    {
        EditCollegueDiscount GetDetails(long id);
        List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel search);
    }
}
