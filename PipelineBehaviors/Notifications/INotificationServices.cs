﻿using Flunt.Notifications;

namespace PipelineBehaviors.Notifications;

public interface INotificationServices
{
    void AddNotification(Notification notificacao);
    void AddNotifications(IEnumerable<Notification> notificacoes);
    IEnumerable<Notification> GetNotifications();
    bool HasNotifications();
    void ClearNotifications();
}
