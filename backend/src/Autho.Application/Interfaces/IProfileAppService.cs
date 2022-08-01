using Autho.Application.Contracts;
using Autho.Domain.Core.Validation;

namespace Autho.Application.Interfaces
{
    public interface IProfileAppService
    {
        IResult Add(ProfileCreationDto creationDto);
        IResult Update(Guid id, ProfileCreationDto creationDto);
        IResult Remove(Guid id);
    }
}
