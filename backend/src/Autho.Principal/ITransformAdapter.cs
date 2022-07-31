namespace Autho.Principal
{
    public interface ITransformAdapter<TBaseDomain, TBaseData>
        where TBaseDomain : BaseDomain
        where TBaseData : BaseData
    {
        TBaseDomain Transform(TBaseData data);
        IEnumerable<TBaseDomain> Transform(IEnumerable<TBaseData> datas);

        TBaseData Transform(TBaseDomain domain);
        IEnumerable<TBaseData> Transform(IEnumerable<TBaseDomain> domains);
    }
}
