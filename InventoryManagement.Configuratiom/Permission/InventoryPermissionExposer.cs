using InventoryManagement.Infrastructure.Configuration.Permission;
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
                        new PermissionDto(InventoryPermissions.CreateInventory,"ساخت انبار"),
                        new PermissionDto(InventoryPermissions.SearchInventory,"جست و جوی در انبار"),
                        new PermissionDto(InventoryPermissions.EditInventory,"ویرایش انبار"),
                        new PermissionDto(InventoryPermissions.ListInventory,"لیست انبار"),
                        new PermissionDto(InventoryPermissions.Increase,"افزایش موجودی"),
                        new PermissionDto(InventoryPermissions.Reduce,"کاهش موجودی"),
                        new PermissionDto(InventoryPermissions.OperationLog,"گزارش انبار")
                  }
                }
            };
        }
    }
}
