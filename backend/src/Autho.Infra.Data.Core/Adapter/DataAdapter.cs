using Autho.Domain.Core.Entities;
using Autho.Infra.Data.Core.Entities;

namespace Autho.Infra.Data.Core.Adapter
{
    public abstract class DataAdapter<TBaseDomain, TBaseData> : IDataAdapter<TBaseDomain, TBaseData>
        where TBaseDomain : BaseDomain
        where TBaseData : BaseData
    {
        public abstract TBaseDomain Transform(TBaseData data);

        public IEnumerable<TBaseDomain> Transform(IEnumerable<TBaseData> datas)
        {
            return datas.Select(data => Transform(data));
        }

        public abstract TBaseData Transform(TBaseDomain domain);

        public IEnumerable<TBaseData> Transform(IEnumerable<TBaseDomain> domains)
        {
            return domains.Select(domain => Transform(domain));
        }
    }
}
