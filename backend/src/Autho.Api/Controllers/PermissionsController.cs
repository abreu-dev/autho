using Autho.Api.Scope.Filters;
using Autho.Application.Queries.Interfaces;
using Autho.Application.Queries.Parameters;
using Autho.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class PermissionsController : BaseController
    {
        private readonly IPermissionAppQuery _permissionAppQuery;

        public PermissionsController(IPermissionAppQuery permissionAppQuery)
        {
            _permissionAppQuery = permissionAppQuery;
        }

        [HttpGet, Route("api/permissions"), AuthorizationRequirement(Permission.PermissionView)]
        public IActionResult Get([FromQuery] PermissionParameters parameters)
        {
            return Ok(_permissionAppQuery.GetPaged(parameters));
        }
    }
}
