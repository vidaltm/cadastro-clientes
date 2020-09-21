using CadastroClientes.Common.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClientes.Common.Interface
{
    public interface INotify
    {
        Notify Invoke();
    }
}
