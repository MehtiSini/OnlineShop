namespace AcoountManagement.Domain.RoleAgg
{
    public class PermissionModel
    {
        public long Id { get; private set; }
        public int Code { get; private set; }
        public string? Name { get; private set; }
        public long RoleId { get; private set; }

        public RoleModel? Role { get; private set; }

        protected PermissionModel()
        {

        }

        public PermissionModel(int code)
        {
            Code = code;
        }

        public PermissionModel(int code, string? name)
        {
            Code = code;
            Name = name;
        }
    }
}
