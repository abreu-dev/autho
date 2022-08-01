using Autho.Application.Contracts;

namespace Autho.Application.Queries.Interfaces
{
    public interface IProfileAppQuery
    {
        IEnumerable<ProfileDto> GetAll();
    }
}
