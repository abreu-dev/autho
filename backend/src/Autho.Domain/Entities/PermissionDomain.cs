namespace Autho.Principal
{
    public class PermissionDomain : BaseDomain
    {
        public string Name { get; private set; }
        public string Code { get; private set; }

        public PermissionDomain(Guid id) : base(id)
        {
        }

        public PermissionDomain(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public PermissionDomain(Guid id, string name, string code) : base(id)
        {
            Name = name;
            Code = code;
        }
    }
}
