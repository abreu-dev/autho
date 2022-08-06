using Autho.Application.Contracts;

namespace Autho.Application.Services.Interfaces
{
    public interface IUserAppService
    {
        Task Add(UserCreationDto creationDto);
        Task Update(Guid id, UserCreationDto creationDto);
        Task Remove(Guid id);
    }
}
