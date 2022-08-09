using Autho.Application.Contracts.Profile;

namespace Autho.Application.Services.Interfaces
{
    public interface IProfileAppService
    {
        Task Add(ProfileCreationDto creationDto);
        Task Update(Guid id, ProfileCreationDto creationDto);
        Task Remove(Guid id);
    }
}
