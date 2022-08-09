namespace Autho.Domain.Core.Entities
{
    public abstract class BaseDomain
    {
        public Guid Id { get; private set; }

        protected BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        protected BaseDomain(Guid id)
        {
            Id = id;
        }
    }
}
