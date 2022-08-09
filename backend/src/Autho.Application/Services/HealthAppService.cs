using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.Validations;
using Autho.Domain.Core.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;
using Autho.Infra.Data.Context;

namespace Autho.Application.Services
{
    public class HealthAppService : IHealthAppService
    {
        private readonly IAuthoContext _context;
        private readonly IGlobalizationService _globalizationService;

        public HealthAppService(IAuthoContext context,
                                IGlobalizationService globalizationService)
        {
            _context = context;
            _globalizationService = globalizationService;
        }

        public IResult CheckHealthy()
        {
            if (!_context.IsAvailable())
            {
                return new Result(ResultType.Failure,
                    new ResultError(_globalizationService.ErrorMessage(_globalizationService.DatabaseUnavailable)));
            }

            return new Result(ResultType.Success);
        }
    }
}
