using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Requests
{
    public class Notification : INotification
    {
        public string Key { get; }
        public string Value { get; }

        public Notification(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
