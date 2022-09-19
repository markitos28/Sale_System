using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Aplication.Interface
{
    public interface IClienteQuery
    {
        Cliente GetCliente(int clienteId);
        Cliente GetCliente(string clienteNombre, string clienteApellido);
        Cliente GetCliente(string clienteDni);
        IList<Cliente> GetClienteAll();

    }
}
