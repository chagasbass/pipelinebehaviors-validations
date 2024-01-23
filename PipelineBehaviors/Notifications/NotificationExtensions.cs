﻿using PipelineBehaviors.Notifications;

namespace TesteWorker.Worker.Extensions.Notifications;

public static class NotificationExtensions
{
    public static IServiceCollection AddNotificationControl(this IServiceCollection services)
    {
        services.AddSingleton<INotificationServices, NotificationServices>();
        return services;
    }
}
