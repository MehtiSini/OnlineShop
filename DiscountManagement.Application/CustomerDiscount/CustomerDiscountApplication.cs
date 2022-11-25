using Blog.Domain.Tools;
using DiscountManagement.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CusotmerDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using MyFramework.Tools;

namespace DiscountManagement.Application.CustomerDiscount
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _repository;

        public CustomerDiscountApplication(ICustomerDiscountRepository repository)
        {
            _repository = repository;
        }

        public OperationResult DefineDiscount(DefineCustomerDiscount cmd)
        {
            var operation = new OperationResult();

              if (_repository.Exist(x => x.ProductId == cmd.ProductId && x.DiscountRate == cmd.DiscountRate))
                return operation.Failed(OperationMessage.DuplicateRecord);

            var StartDate = cmd.StartDate.ToGeorgianDateTime();
            var EndDate = cmd.EndDate.ToGeorgianDateTime();

            var Discount = new CustomerDiscountModel(cmd.ProductId, cmd.DiscountRate, StartDate, EndDate, cmd.Reason);

            _repository.Create(Discount);

            _repository.Save();

            return operation.Succeed();
        }

        public OperationResult Edit(EditCustomerDiscount cmd)
        {
            var operation = new OperationResult();

            var Discount = _repository.GetById(cmd.Id);

            if (Discount == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            var StartDate = cmd.StartDate.ToGeorgianDateTime();
            var EndDate = cmd.EndDate.ToGeorgianDateTime();

            Discount.Edit(cmd.ProductId, cmd.DiscountRate, StartDate, EndDate, cmd.Reason);

            _repository.Save();

            return operation.Succeed();
        }

        public EditCustomerDiscount GetDetails(long Id)
        {
            return _repository.GetDetails(Id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel Search)
        {
            return _repository.Search(Search);
        }
    }
}