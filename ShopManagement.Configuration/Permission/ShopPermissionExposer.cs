using MyFramework.Tools.Authentication;

namespace ShopManagement.Configuration.Permission
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Product", new List<PermissionDto>
                  {
                        new PermissionDto(ShopPermissions.CreateProduct,"افزودن محصول"),
                        new PermissionDto(ShopPermissions.SearchProducts,"جست و جوی محصولات"),
                        new PermissionDto(ShopPermissions.EditProduct,"ویرایش محصولات"),
                  }
                },
                {
                    "ProductCategory" , new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.CreateProductCategory,"افزودن کتگوری"),
                        new PermissionDto(ShopPermissions.SearchProductCategories,"جست و جوی کتگوری"),
                        new PermissionDto(ShopPermissions.EditProductCategory,"ویرایش کتگوری"),
                    }
                }
            };
        }
    }
}
