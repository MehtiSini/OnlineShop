using AccountManagement.Contracts.Role;
using AccountManagement.Infrastrucure.EfCore.DbContextModel;
using AcoountManagement.Domain.RoleAgg;
using Blog.Domain.Tools;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools.Authentication;

namespace AccountManagement.Infrastrucure.EfCore.Role
{
    public class RoleRepository : RepositoryBase<long, RoleModel>, IRoleRepository
    {
        private readonly AccountContext _context;

        public RoleRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditRole GetDetails(long id)
        {
            var Role = _context.roles.Select(x => new EditRole
            {
                Id = x.Id,
                Name = x.Name,
                MappedPermission = MapPermissions(x.Permissions),

            }).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            Role.Permissions = Role.MappedPermission.Select(x => x.Code).ToList();


            return Role;

        }

        private static List<PermissionDto> MapPermissions(List<PermissionModel> permissions)
        {
            return permissions.Select(x => new PermissionDto(x.Code, x.Name)).ToList();
        }

        public List<RoleViewModel> ListRoles()
        {
            return _context.roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()

            }).ToList();
        }
    }
}
