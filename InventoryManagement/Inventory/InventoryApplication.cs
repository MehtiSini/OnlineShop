﻿using InventoryManaement.Domain.InventoryAgg;
using InventoryManagement.Conracts.Inventory;
using MyFramework.Tools;

namespace InventoryManagement.Application.Inventory
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _repository;

        public InventoryApplication(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateInventory cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.ProductId == cmd.ProductId && x.UnitPrice == cmd.UnitPrice))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var Inventory = new InventoryModel(cmd.ProductId, cmd.UnitPrice);

            _repository.Create(Inventory);
            _repository.Save();

            return operation.Succeed();
        }

        public OperationResult Edit(EditInventory cmd)
        {
            var operation = new OperationResult();

            var Inventory = _repository.GetById(cmd.Id);

            if (Inventory == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            Inventory.Edit(cmd.ProductId, cmd.UnitPrice);
            _repository.Save();

            return operation.Succeed();
        }

        public EditInventory GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long InventoryId)
        {
            return _repository.GetOperationLog(InventoryId);
        }

        public OperationResult Increase(IncreaseInventory cmd)
        {
            var operation = new OperationResult();

            var Inventory = _repository.GetById(cmd.InventoryId);

            if (Inventory == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            var OperatorId = 1;

            Inventory.Increase(cmd.Count, OperatorId, cmd.Description);

            _repository.Save();

            return operation.Succeed();

        }

        public OperationResult Reduce(ReduceInventory cmd)
        {
            var operation = new OperationResult();

            var Inventory = _repository.GetById(cmd.InventoryId);

            if (Inventory == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            var OperatorId = 1;

            Inventory.Reduce(cmd.Count, OperatorId, cmd.Description, 0);

            _repository.Save();

            return operation.Succeed();
        }

        public OperationResult Reduce(List<ReduceInventory> cmd)
        {
            var operation = new OperationResult();

            var OperatorId = 1;

            foreach (var item in cmd)
            {
                var Inventory = _repository.GetInventory(item.ProductId);

                Inventory.Reduce(item.Count, OperatorId, item.Description, 0);
            }

            _repository.Save();

            return operation.Succeed();
        }

        public List<InventoryViewModel> Search(InventorySearchModel Search)
        {
            return _repository.Search(Search);
        }
    }
}