using Domain.Interfaces.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Notifications
{
    public class NotificationHandler : INotificationHandler<Notification>
    {
        public List<Notification> _notifications { get; private set; }

        public NotificationHandler()
        {
            _notifications= new List<Notification>();
        }
        public bool HasNotification() => _notifications.Any();

        public string GetMessage() => _notifications.FirstOrDefault().Message;

        public int GetStatusCode() => _notifications.FirstOrDefault().StatusCode;

        public IReadOnlyCollection<Notification> GetNotifications() => _notifications;

        public List<object> GetNotificationsErrors() => _notifications.Select(x => x.Errors).ToList();

        public void AddNotification(string message, string error)
        {
            _notifications.Add(new Notification(message, error));
        }

        public void AddNotification(int statusCode, string message, string error)
        {
            _notifications.Add(new Notification(message, error, statusCode));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

       
    }
}
