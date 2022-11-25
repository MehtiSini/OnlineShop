using DiscountManagement.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CusotmerDiscountAgg;
using MyFramework.Domain;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long, CustomerDiscountModel>
    {
        EditCustomerDiscount GetDetails(long id);

        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel search);

    }
}
