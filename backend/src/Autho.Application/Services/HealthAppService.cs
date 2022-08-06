using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.Validation;
using Autho.Domain.Core.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Resources;
using Autho.Infra.Data.Context;

namespace Autho.Application.Services
{
    public class HealthAppService : IHealthAppService
    {
        private readonly IAuthoContext _context;

        public HealthAppService(IAuthoContext context)
        {
            _context = context;
        }

        public IResult CheckHealthy()
        {
            if (!_context.IsAvailable())
            {
                return new Result(ResultType.Failure,
                    new ResultError("DatabaseUnavailable", "Database Unavailable", AuthoResource.DatabaseUnavailable));
            }

            return new Result(ResultType.Success);
        }
    }
}
