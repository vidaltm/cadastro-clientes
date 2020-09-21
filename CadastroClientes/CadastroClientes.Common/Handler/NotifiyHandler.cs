﻿using CadastroClientes.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroClientes.Common.Handler
{
    public class NotifiyHandler : INotificationHandler<Notifications>
    {
        private List<Notifications> _notifications;

        public NotifiyHandler()
        {
            _notifications = new List<Notifications>();
        }
        public Task Handle(Notifications message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual List<Notifications> GetNotifications()
        {
            return _notifications.Where(not =>
                not.GetType() == typeof(Notifications)).ToList();
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<Notifications>();
        }
    }
}
