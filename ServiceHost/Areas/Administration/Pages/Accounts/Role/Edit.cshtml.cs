using AccountManagement.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFramework.Tools.Authentication;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    public class EditModel : PageModel
    {
        public EditRole Command;

        public List<SelectListItem> Permissions = new List<SelectListItem>();

        private readonly IRoleApplication _roleApplication;

        private readonly IEnumerable<IPermissionExposer> _Exposer;

        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposer)
        {
            _roleApplication = roleApplication;
            _Exposer = exposer;
        }

        public void OnGet(long id)
        {
            Command = _roleApplication.GetDetails(id);
            var permissions = new List<PermissionDto>();

            foreach (var Exposer in _Exposer)
            {
                var ExposedPermission = Exposer.Expose();

                foreach (var (Key, Value) in ExposedPermission)
                {
                    permissions.AddRange(Value);

                    var group = new SelectListGroup
                    {
                        Name = Key
                    };

                    foreach (var permission in Value)
                    {
                        var Item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group
                        };

                        if(Command.MappedPermission.Any(x=>x.Code == permission.Code))
                        {
                            Item.Selected = true;
                        }

                        Permissions.Add(Item);

                    }
                }

            }

        }

        public IActionResult OnPost(EditRole command)
        {
            _roleApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}