using System.ComponentModel.DataAnnotations;

namespace Autho.Core.Enums
{
    public enum Permission
    {
        [Display(Name = "PermissionProfileInsert", Description = "permission-profile-insert")]
        PermissionProfileInsert = 0,

        [Display(Name = "PermissionProfileUpdate", Description = "permission-profile-update")]
        PermissionProfileUpdate = 1,

        [Display(Name = "PermissionProfileDelete", Description = "permission-profile-delete")]
        PermissionProfileDelete = 2,

        [Display(Name = "PermissionProfileView", Description = "permission-profile-view")]
        PermissionProfileView = 3,
    }
}
