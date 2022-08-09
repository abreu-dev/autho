using Autho.Application.Contracts.User;
using Autho.Application.Queries.Parameters.Interfaces;
using Autho.Domain.Core.Data.Pagination.Interfaces;

namespace Autho.Application.Queries.Interfaces
{
    public interface IUserAppQuery
    {
        IPagedList<UserDto> GetPaged(IUserParameters parameters);
    }
}
