using CadastroClientes.Common.Handler;
using CadastroClientes.Common.Interface;
using CadastroClientes.Common.Model;
using CadastroClientes.Common.Utils;
using FluentValidation.Results;
using MediatR;
using System.Threading;

namespace CadastroClientes.Common.Implementation
{
    public class Notify : INotify
    {
        private readonly NotifiyHandler _messageHandler;

        public Notify(INotificationHandler<Notifications> notification)
        {
            _messageHandler = (NotifiyHandler)notification;
        }

        public Notify Invoke()
        {
            return this;
        }

        public bool IsValid()
        {
            return !_messageHandler.HasNotifications();
        }

        public void NewNotification(string key, string message)
        {
            _messageHandler.Handle(new Notifications(key, message), default(CancellationToken));
        }

        public void NewNotification(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
                _messageHandler.Handle(new Notifications(Resources.ErroDeDominio, erro.ErrorMessage), default(CancellationToken));
        }
    }
}
