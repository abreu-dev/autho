using Autho.Api.Scope.Filters;
using Autho.Application.Contracts.Permission;
using Autho.Application.Queries.Interfaces;
using Autho.Application.Queries.Parameters;
using Autho.Core.Enums;
using Autho.Domain.Core.Data.Pagination.Interfaces;
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

        /// <summary>
        /// Obtain a list of permissions
        /// </summary>
        [HttpGet]
        [Route("api/permissions")]
        [AuthorizationRequirement(Permission.PermissionView)]
        [ProducesResponseType(200, Type = typeof(IPagedList<PermissionDto>))]
        public IActionResult Get([FromQuery] PermissionParameters parameters)
        {
            return Ok(_permissionAppQuery.GetPaged(parameters));
        }
    }
}
