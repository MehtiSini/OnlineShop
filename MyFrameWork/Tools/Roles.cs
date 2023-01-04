namespace MyFramework.Tools
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string NormalUser = "2";
        public const string ContentUploader = "3";
        public const string CollegueUser = "4";

        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";
                case 2:
                    return "کابر ساده";
                case 3:
                    return "محتوا گذار";
                case 4:
                    return "کاربر همکار";
                default:
                    return "نامشخص";
            }
        }

    }
}
