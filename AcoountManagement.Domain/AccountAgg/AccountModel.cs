using AcoountManagement.Domain.RoleAgg;
using MyFramework.Domain;

namespace AcoountManagement.Domain.AccountAgg
{
    public class AccountModel : EntityBase
    {
        public string? FullName { get; private set; }
        public string? Username { get; private set; }
        public string? Password { get; private set; }
        public string? Mobile { get; private set; }
        public string? ProfilePhoto { get; private set; }
        public long RoleId { get; private set; }

        public RoleModel Role{ get; private set; }

        public AccountModel(string? fullName, string? username, string? password,
            string? mobile, string? profilePhoto, long roleId)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            Mobile = mobile;
            ProfilePhoto = profilePhoto;
            RoleId = roleId;
        }

        public void Edit(string? fullName, string? username,
            string? mobile, string? profilePhoto, long roleId)
        {
            FullName = fullName;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
            {
                ProfilePhoto = profilePhoto;
            }
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

    }
}
