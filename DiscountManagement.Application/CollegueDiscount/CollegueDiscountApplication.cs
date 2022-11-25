using DiscountManagement.Contracts.CollegueDiscount;
using DiscountManagement.Domain.CollegueDiscountAgg;
using MyFramework.Tools;

namespace DiscountManagement.Application.CollegueDiscount
{
    public class CollegueDiscountApplication : ICollegueDiscountApplication
    {
        private readonly ICollegueDiscountRepository _repository;

        public CollegueDiscountApplication(ICollegueDiscountRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Define(DefineCollegueDiscount cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.ProductId == cmd.ProductId && x.DiscountRate == cmd.DiscountRate))
                return operation.Failed(OperationMessage.DuplicateRecord);

            var Discount = new CollegueDiscountModel(cmd.ProductId, cmd.DiscountRate);

            _repository.Create(Discount);

            _repository.Save();

            return operation.Succeed();

        }

        public OperationResult Edit(EditCollegueDiscount cmd)
        {
            var operation = new OperationResult();

            var Discount = _repository.GetById(cmd.Id);

            if (Discount == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Discount.Edit(cmd.ProductId, cmd.DiscountRate);

            _repository.Save();

            return operation.Succeed();
        }

        public EditCollegueDiscount GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var Discount = _repository.GetById(id);

            if (Discount == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Discount.Remove();

            _repository.Save();

            return operation.Succeed(); ;
        }


        public OperationResult Activate(long id)
        {
            var operation = new OperationResult();

            var Discount = _repository.GetById(id);

            if (Discount == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Discount.Activate();

            _repository.Save();

            return operation.Succeed();
        }

        public List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel search)
        {
            return _repository.Search(search);

        }
    }
}
