using AcoountManagement.Domain.AccountAgg;
using MyFramework.Domain;

namespace AcoountManagement.Domain.RoleAgg
{
    public class RoleModel : EntityBase
    {
        public string? Name { get; private set; }
        public List<AccountModel> Accounts { get; private set; }

        public List<PermissionModel> Permissions { get; private set; }

        protected RoleModel()
        {

        }

        public RoleModel(string? name , List<PermissionModel> permissions)
        {
            Name = name;
            Accounts = new List<AccountModel>();
            Permissions = permissions;
        }

        public void Edit(string? name , List<PermissionModel> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}
