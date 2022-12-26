namespace MyFramework.Tools.Authentication
{
    // To Define Permission

    public interface IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose();
    }
}
