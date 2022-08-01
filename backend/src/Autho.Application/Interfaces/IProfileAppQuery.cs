using Autho.Application.Contracts;

namespace Autho.Application.Interfaces
{
    public interface IProfileAppQuery
    {
        IEnumerable<ProfileDto> GetAll();
    }
}
