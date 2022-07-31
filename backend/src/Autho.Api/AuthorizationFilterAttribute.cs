﻿using Autho.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Autho.Api
{
    public class AuthorizationRequirementAttribute : TypeFilterAttribute
    {
        public AuthorizationRequirementAttribute(params Permission[] permissions) : base(typeof(AuthorizationRequirementFilter))
        {
            Arguments = new object[] { permissions };
        }
    }

    public class AuthorizationRequirementFilter : IAuthorizationFilter
    {
        private readonly ICollection<string> _permissionCodes;

        public AuthorizationRequirementFilter(params Permission[] permissions)
        {
            _permissionCodes = new List<string>();

            permissions.ToList().ForEach(permission =>
            {
                var permissionCode = permission.GetEnumDisplayDescription();

                if (permissionCode != null)
                {
                    _permissionCodes.Add(permissionCode);
                }
            });
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserDomain?)context.HttpContext.Items["User"];

            if (user == null)
            {
                context.Result = new ForbidResult();
            }
            else
            {
                var isAuthorized = false;
                var userPermissions = user.Profiles.SelectMany(x => x.Permissions).ToList();

                userPermissions.ForEach(userPermission =>
                {
                    if (_permissionCodes.Any(permissionCode => permissionCode == userPermission.Code))
                    {
                        isAuthorized = true;
                    }
                });

                if (!isAuthorized)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
