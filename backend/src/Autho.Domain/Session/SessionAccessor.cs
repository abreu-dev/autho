using Autho.Domain.Entities;
using Autho.Domain.Session.Interfaces;

namespace Autho.Domain.Session
{
    public class SessionAccessor : ISessionAccessor
    {
        public UserDomain? User { get; set; }
    }
}
