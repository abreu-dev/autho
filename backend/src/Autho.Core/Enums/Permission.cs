using System.ComponentModel.DataAnnotations;

namespace Autho.Core.Enums
{
    public enum Permission
    {
        [Display(Name = "ProfileInsert", Description = "profile-insert")]
        ProfileInsert = 1,

        [Display(Name = "ProfileUpdate", Description = "profile-update")]
        ProfileUpdate = 2,

        [Display(Name = "ProfileDelete", Description = "profile-delete")]
        ProfileDelete = 3,

        [Display(Name = "ProfileView", Description = "profile-view")]
        ProfileView = 4,

        [Display(Name = "PermissionView", Description = "permission-view")]
        PermissionView = 5,
    }
}
