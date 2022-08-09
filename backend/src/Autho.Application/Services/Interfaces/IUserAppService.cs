using Autho.Application.Contracts.User;

namespace Autho.Application.Services.Interfaces
{
    public interface IUserAppService
    {
        Task Add(UserCreationDto creationDto);
        Task Update(Guid id, UserCreationDto creationDto);
        Task Remove(Guid id);
    }
}
