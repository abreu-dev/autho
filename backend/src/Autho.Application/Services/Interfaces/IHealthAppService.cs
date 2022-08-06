using Autho.Domain.Core.Validations.Interfaces;

namespace Autho.Application.Services.Interfaces
{
    public interface IHealthAppService
    {
        IResult CheckHealthy();
    }
}
