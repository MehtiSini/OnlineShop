using MyFramework.Tools;

namespace DiscountManagement.Contracts.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult DefineDiscount(DefineCustomerDiscount cmd);
        OperationResult Edit(EditCustomerDiscount cmd);
        EditCustomerDiscount GetDetails(long Id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel Search);
    }
}
