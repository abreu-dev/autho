using Autho.Application.Contracts.Profile;
using Autho.Application.Queries.Parameters.Interfaces;
using Autho.Domain.Core.Data.Pagination.Interfaces;

namespace Autho.Application.Queries.Interfaces
{
    public interface IProfileAppQuery
    {
        IPagedList<ProfileDto> GetPaged(IProfileParameters parameters);
    }
}
