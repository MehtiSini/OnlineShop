using AccountManagement.Contracts.Role;
using MyFramework.Domain;

namespace AcoountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long,RoleModel>
    {
        EditRole GetDetails(long Id);
        List<RoleViewModel> ListRoles();
    }
}
