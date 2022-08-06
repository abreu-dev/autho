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



        [Display(Name = "UserInsert", Description = "user-insert")]
        UserInsert = 6,

        [Display(Name = "UserUpdate", Description = "user-update")]
        UserUpdate = 7,

        [Display(Name = "UserDelete", Description = "user-delete")]
        UserDelete = 8,

        [Display(Name = "UserView", Description = "user-view")]
        UserView = 9,
    }
}
