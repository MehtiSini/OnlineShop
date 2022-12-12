using AccountManagement.Contracts.Role;
using AcoountManagement.Domain.RoleAgg;
using MyFramework.Tools;

namespace AccountManagement.Applications.Role
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _repository;

        public RoleApplication(IRoleRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateRole cmd)
        {
            var operation = new OperationResult();

            if (_repository.Exist(x => x.Name == cmd.Name))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var Role = new RoleModel(cmd.Name);

            _repository.Create(Role);
            _repository.Save();
            return operation.Succeed();
        }

        public OperationResult Edit(EditRole cmd)
        {
            var operation = new OperationResult();

            var Role = _repository.GetById(cmd.Id);

            if (Role == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            if (_repository.Exist(x => x.Name == cmd.Name && x.Id != cmd.Id))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            Role.Edit(cmd.Name);
            _repository.Save();
            return operation.Succeed();
        }

        public EditRole GetDetails(long Id)
        {
            return _repository.GetDetails(Id);
        }

        public List<RoleViewModel> ListRoles()
        {
           return _repository.ListRoles();
        }
    }
}
