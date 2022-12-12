using AcoountManagement.Domain.AccountAgg;
using MyFramework.Domain;

namespace AcoountManagement.Domain.RoleAgg
{
    public class RoleModel : EntityBase
    {
        public string? Name { get; private set; }
        public List<AccountModel> Accounts { get; private set; }

        public RoleModel(string? name)
        {
            Name = name;
            Accounts = new List<AccountModel>();
        }

        public void Edit(string? name)
        {
            Name = name;
        }
    }
}
