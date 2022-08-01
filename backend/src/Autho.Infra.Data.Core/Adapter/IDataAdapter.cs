using Autho.Domain.Core.Entities;
using Autho.Infra.Data.Core.Entities;

namespace Autho.Infra.Data.Core.Adapter
{
    public interface IDataAdapter<TBaseDomain, TBaseData>
        where TBaseDomain : BaseDomain
        where TBaseData : BaseData
    {
        TBaseDomain Transform(TBaseData data);
        IEnumerable<TBaseDomain> Transform(IEnumerable<TBaseData> datas);

        TBaseData Transform(TBaseDomain domain);
        IEnumerable<TBaseData> Transform(IEnumerable<TBaseDomain> domains);
    }
}
