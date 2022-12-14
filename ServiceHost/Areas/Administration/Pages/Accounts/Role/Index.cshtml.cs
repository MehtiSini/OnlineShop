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

        public IActionResult OnGetCreate()
        {
            var command = new CreateRole();
            return Partial("./Register", command);
        }

        public JsonResult OnPostCreate(CreateRole create)
        {
            var result = _applicationRole.Create(create);

            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Role = _applicationRole.GetDetails(id);

            return Partial("Edit", Role);
        }

        public JsonResult OnPostEdit(EditRole cmd)
        {
            var result = _applicationRole.Edit(cmd);

            return new JsonResult(result);
        }

    }
}
