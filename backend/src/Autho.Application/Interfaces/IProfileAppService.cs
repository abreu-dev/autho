using Autho.Application.Contracts;

namespace Autho.Application.Interfaces
{
    public interface IProfileAppService
    {
        Task Add(ProfileCreationDto creationDto);
        Task Update(Guid id, ProfileCreationDto creationDto);
        Task Remove(Guid id);
    }
}
