using Autho.Application.Contracts.Integration;
using Autho.Application.Queries.Integrations.Interfaces;
using Autho.Core.Extensions;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Entities.Integration;

namespace Autho.Application.Queries.Integrations
{
    public class IntegrationAppQuery : IIntegrationAppQuery
    {
        private readonly IAuthoContext _context;

        public IntegrationAppQuery(IAuthoContext context)
        {
            _context = context;
        }

        public IntegrationDto? Get(Guid integrationId)
        {
            var source = _context.Query<IntegrationData>();

            var dto = (from integration in source
                       where integration.Id == integrationId
                       select new IntegrationDto()
                       {
                           Id = integration.Id,
                           Status = integration.Status.GetEnumDisplayName() ?? string.Empty,
                           StartDateImport = integration.StartDateImport,
                           EndDateImport = integration.EndDateImport
                       }).FirstOrDefault();

            return dto;
        }
    }
}
