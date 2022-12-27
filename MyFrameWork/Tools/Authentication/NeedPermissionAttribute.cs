namespace MyFramework.Tools.Authentication
{
    public class NeedPermissionAttribute : Attribute
    {
        public int Permission { get; set; }

        public NeedPermissionAttribute(int permission)
        {
            Permission = permission;
        }
    }
}
