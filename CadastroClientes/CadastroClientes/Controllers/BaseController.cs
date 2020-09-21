
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Common.Handler;
using CadastroClientes.Common.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    public class BaseController : Controller
    {
        private readonly NotifiyHandler _messageHandler;

        protected BaseController(
            INotificationHandler<Notifications> notification)
        {
            _messageHandler = (NotifiyHandler)notification;
        }

        protected bool HasNotifications()
        {
            return _messageHandler.HasNotifications();
        }

        protected bool OperacaoValida() => !_messageHandler.HasNotifications();

        protected BadRequestObjectResult BadRequestResponse()
        {
            return BadRequest(_messageHandler.GetNotifications().Select(n => n));
        }
    }
}
