using Autho.Domain.Entities;

namespace Autho.Domain.Session.Interfaces
{
    public interface ISessionAccessor
    {
        UserDomain? User { get; set; }
    }
}
