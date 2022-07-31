namespace Autho.Principal
{
    public abstract class TransformAdapter<TBaseDomain, TBaseData> : ITransformAdapter<TBaseDomain, TBaseData>
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
