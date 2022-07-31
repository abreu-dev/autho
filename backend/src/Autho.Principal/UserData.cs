﻿namespace Autho.Principal
{
    public class UserData : BaseData
    {
        public static string TableName => "User";

        public string Name { get; set; }
        public static int NameMaxLength => 100;

        public string Email { get; set; }
        public static int EmailMaxLength => 100;

        public string Login { get; set; }
        public static int LoginMaxLength => 100;

        public string Password { get; set; }
        public static int PasswordMaxLength => 100;

        public virtual ICollection<UserProfileData> Profiles { get; set; }
    }
}
