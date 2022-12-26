using MyFramework.Tools.Authentication;

namespace InventoryManagement.Configuratiom.Permission
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Inventory", new List<PermissionDto>
                  {
                        new PermissionDto(50,"ساخت انبار"),
                        new PermissionDto(51,"جست و جوی در انبار"),
                        new PermissionDto(52,"ویرایش انبار"),
                        new PermissionDto(53,"لیست انبار")
                  }
                }
            };
        }
    }
}
