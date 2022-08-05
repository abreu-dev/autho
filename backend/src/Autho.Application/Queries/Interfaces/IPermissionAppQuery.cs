using Autho.Application.Contracts;
using Autho.Application.Queries.Parameters.Interfaces;
using Autho.Domain.Core.Data.Pagination.Interfaces;

namespace Autho.Application.Queries.Interfaces
{
    public interface IPermissionAppQuery
    {
        IPagedList<PermissionDto> GetPaged(IPermissionParameters parameters);
    }
}
