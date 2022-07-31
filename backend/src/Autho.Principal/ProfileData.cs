namespace Autho.Principal
{
    public class ProfileData : BaseData
    {
        public static string TableName => "Profile";

        public string Name { get; set; }
        public static int NameMaxLength => 100;

        public virtual ICollection<ProfilePermissionData> Permissions { get; set; }
        public virtual ICollection<UserProfileData> Users { get; set; }
    }
}
