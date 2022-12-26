using AccountManagement.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    public class IndexModel : PageModel
    {
        private readonly IRoleApplication _applicationRole;

        public List<RoleViewModel>? Roles;

        public IndexModel(IRoleApplication applicationRole)
        {
            _applicationRole = applicationRole;
        }

        public void OnGet()
        {
            Roles = _applicationRole.ListRoles();
        }


    }
}
