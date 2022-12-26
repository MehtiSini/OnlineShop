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
                        new PermissionDto(10,"افزودن محصول"),
                        new PermissionDto(11,"جست و جوی محصولات"),
                        new PermissionDto(12,"ویرایش محصولات"),
                        new PermissionDto(13,"لیست محصولات")
                  }
                },
                {
                    "ProductCategory" , new List<PermissionDto>
                    {
                        new PermissionDto(20,"افزودن کتگوری"),
                        new PermissionDto(21,"جست و جوی کتگوری"),
                        new PermissionDto(22,"ویرایش کتگوری"),
                        new PermissionDto(22,"لیست کتگوری ها")
                    }
                }
            };
        }
    }
}
