namespace Autho.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        void Complete();
    }
}
