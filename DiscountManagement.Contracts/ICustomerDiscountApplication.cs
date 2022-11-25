using MyFramework.Tools;

namespace DiscountManagement.Contracts
{
    public interface ICustomerDiscountApplication
    {
        OperationResult DefineDiscount(DefineCustomerDiscount cmd);
        OperationResult Edit(EditCustomerDiscount cmd);
        EditCustomerDiscount GetDetails(long Id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel Search);
    }
}
