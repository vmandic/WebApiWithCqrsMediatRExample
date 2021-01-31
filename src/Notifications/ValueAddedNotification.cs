using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WebApiWithCqrsMediatRExample.Notifications
{
    public class ValueAddedNotification : INotification
    {
        public ValueAddedNotification(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }

    public class EmailHandler : INotificationHandler<ValueAddedNotification>
    {
        private readonly FakeDataStore _db;

        public EmailHandler(FakeDataStore db)
        {
            _db = db;
        }

        public Task Handle(ValueAddedNotification notification, CancellationToken cancellationToken)
        {
            _db.EventOccured(notification.Value, "Email sent");
            return Task.CompletedTask;
        }
    }

    public class CacheInvalidationHandler : INotificationHandler<ValueAddedNotification>
    {
        private readonly FakeDataStore _db;
        public CacheInvalidationHandler(FakeDataStore db)
        {
            _db = db;
        }
        public Task Handle(ValueAddedNotification notification, CancellationToken cancellationToken)
        {
            _db.EventOccured(notification.Value, "Cache invalidated");
            return Task.CompletedTask;
        }
    }
}