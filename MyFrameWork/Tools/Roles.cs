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
            return id switch
            {
                1 => "مدیرسیستم",
                2 => "کابر ساده",
                3 => "محتوا گذار",
                4 => "کاربر همکار",
                _ => "نامشخص",
            };
        }

    }
}
