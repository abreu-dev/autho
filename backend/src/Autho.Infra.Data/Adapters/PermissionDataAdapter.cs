using Autho.Domain.Entities;
using Autho.Infra.Data.Adapters.Interfaces;
using Autho.Infra.Data.Core.Adapter;
using Autho.Infra.Data.Entities;

namespace Autho.Infra.Data.Adapters
{
    public class PermissionDataAdapter : DataAdapter<PermissionDomain, PermissionData>, IPermissionDataAdapter
    {
        public override PermissionDomain Transform(PermissionData data)
        {
            return new PermissionDomain(data.Id, data.Name, data.Code);
        }

        public override PermissionData Transform(PermissionDomain domain)
        {
            return new PermissionData()
            {
                Id = domain.Id,
                Name = domain.Name,
                Code = domain.Code
            };
        }
    }
}
