﻿
using Domain.Notifications;
using System.Collections.ObjectModel;

namespace Domain.Interfaces.Notifications
{
    public interface INotificationHandler<T> where T : Notification
    {
        bool HasNotification();
        IReadOnlyCollection<Notification> GetNotifications();
        public List<object> GetNotificationsErrors();
        string GetMessage();
        int GetStatusCode();
        void AddNotification(string message, string error);
        void AddNotification(int statusCode, string message, string error);
        void AddNotification(T notification);
        void AddNotifications(IEnumerable<T> notifications);
    }
}
