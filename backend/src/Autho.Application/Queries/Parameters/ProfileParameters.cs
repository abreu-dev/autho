using Autho.Application.Queries.Parameters.Interfaces;
using Autho.Domain.Core.Data.Pagination;

namespace Autho.Application.Queries.Parameters
{
    public class ProfileParameters : BaseParameters, IProfileParameters
    {
        public IEnumerable<string> Name { get; set; }

        public ProfileParameters()
        {
            Name = new List<string>();
        }
    }
}
