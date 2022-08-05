using Autho.Domain.Core.Validation;

namespace Autho.Application.Services.Interfaces
{
    public interface IHealthAppService
    {
        IResult CheckHealthy();
    }
}
