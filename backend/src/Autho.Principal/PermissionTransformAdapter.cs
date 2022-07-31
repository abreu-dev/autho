namespace Autho.Principal
{
    public class PermissionTransformAdapter : TransformAdapter<PermissionDomain, PermissionData>, IPermissionTransformAdapter
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
