using Autho.Domain.Core.Data.Pagination.Interfaces;

namespace Autho.Application.Queries.Parameters.Interfaces
{
    public interface IProfileParameters : IParameters
    {
        IEnumerable<string> Name { get; set; }
    }
}
