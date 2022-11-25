using MyFramework.Tools;

namespace DiscountManagement.Contracts.CollegueDiscount
{
    public interface ICollegueDiscountApplication
    {
        OperationResult Define(DefineCollegueDiscount cmd);
        OperationResult Edit(EditCollegueDiscount cmd);
        OperationResult Remove(long id);
        OperationResult Activate(long id);
        EditCollegueDiscount GetDetails(long id);
        List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel search);
    }
}
