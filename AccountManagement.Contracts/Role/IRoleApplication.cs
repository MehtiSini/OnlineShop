using MyFramework.Tools;

namespace AccountManagement.Contracts.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole cmd);
        OperationResult Edit(EditRole cmd);
        EditRole GetDetails(long Id);
        List<RoleViewModel> ListRoles();
    }
}
