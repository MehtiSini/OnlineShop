using MyFramework.Domain;
using MyFramework.Tools;
using ShopManagement.Domain.ProductAgg;

namespace InventoryManaement.Domain.InventoryAgg
{
    public class InventoryModel : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public int IsInStock { get; private set; }
        public List<InventoryOperation>? Operations { get; private set; }

        public InventoryModel(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            IsInStock = OperationStock.InStock;
        }

        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public long CalculateCurrentCount()
        {
            var Plus = Operations.
                Where(x => x.OperationType == OperationStock.Internal)
                .Sum(x => x.Count);

            var Minus = Operations.
             Where(x => x.OperationType == OperationStock.External)
             .Sum(x => x.Count);

            var Result = Plus - Minus;

            return Result;

        }

        public void Increase(long count, long operatorId, string desc)
        {
            //To get The Update ProductCount
            var currentCount = CalculateCurrentCount() + count;

            var operation = new InventoryOperation(OperationStock.Internal, count, operatorId, currentCount, desc, 0, Id);

            Operations.Add(operation);

            if (currentCount > 0)
            {
                IsInStock = OperationStock.InStock;
            }
        }

        public void Reduce(long count, long operatorId, string desc, long orderId)
        {
            //To get The Newest Count
            var currentCount = CalculateCurrentCount() - count;

            var operation = new InventoryOperation(OperationStock.External, count, operatorId, currentCount, desc, orderId, Id);

            Operations.Add(operation);

            if (currentCount > 0)
            {
                IsInStock = OperationStock.InStock;
            }
        }
    }

    public class InventoryOperation
    {
        public long Id { get; private set; }
        //External Or Internal Product >>
        public int OperationType { get; private set; }
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string? Description { get; private set; }
        public long OrderId { get; private set; }
        public long InventoryId { get; private set; }
        public InventoryModel? Inventory { get; private set; }

        public InventoryOperation(int operationType,
            long count, long operatorId,
            long currentCount, string? description,
            long orderId, long inventoryId)
        {
            OperationType = operationType;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
            OperationDate=DateTime.Now;
        }
    }
}