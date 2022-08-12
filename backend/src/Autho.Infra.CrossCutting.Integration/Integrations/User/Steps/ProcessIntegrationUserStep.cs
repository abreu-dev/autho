using Autho.Domain.Entities.Integration;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.Steps
{
    public class ProcessIntegrationUserStep : IProcessIntegrationUserStep
    {
        public async Task<IntegrationDomain?> Execute(IntegrationDomain? data)
        {
            if (data != null)
            {
                Console.WriteLine($"Users: {data.Users.Count}");
            }
            
            return data;
        }
    }
}
