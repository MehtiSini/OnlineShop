using AccountManagement.Contracts.Role;
using AccountManagement.Infrastrucure.EfCore.DbContextModel;
using AcoountManagement.Domain.RoleAgg;
using Blog.Domain.Tools;
using MyFramework.Infrastructure;

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
            return _context.roles.Select(x => new EditRole
            {
                Id=x.Id,
                Name=x.Name

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<RoleViewModel> ListRoles()
        {
            return _context.roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate=x.CreationDate.ToFarsi()

            }).ToList() ;
        }
    }
}
