using MyFramework.Tools.Authentication;

namespace AccountManagement.Contracts.Role
{
    public class EditRole : CreateRole
    {
        public long Id { get; set; }
        public List<PermissionDto>? MappedPermission { get; set; }

    }
}
