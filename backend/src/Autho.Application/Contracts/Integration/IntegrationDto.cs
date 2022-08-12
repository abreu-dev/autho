namespace Autho.Application.Contracts.Integration
{
    public class IntegrationDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime? StartDateImport { get; set; }
        public DateTime? EndDateImport { get; set; }
    }
}
