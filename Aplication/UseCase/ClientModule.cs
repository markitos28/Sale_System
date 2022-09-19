using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class ClientModule
    {
        readonly IClienteCommand _command;
        readonly IClienteQuery _query;

        public ClientModule(IClienteQuery query, IClienteCommand command)
        {
            _command = command;
            _query = query;
        }

        public async Task AltaCliente(string nombre, string apellido, string dni, string direccion, string telefono)
        {
            if (!nombre.Equals(null) || 
                !apellido.Equals(null) || 
                !direccion.Equals(null) || 
                !dni.Equals(null) ||
                !telefono.Equals(null))
            {
                await _command.InsertCliente(new Cliente
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Direccion = direccion,
                    DNI = dni,
                    Telefono = telefono
                });
            }
            ;
        }

        public async Task BajaCliente(string dni)
        {
            int numero;
            bool validacion = int.TryParse(dni, out numero);
            if (!dni.Equals(null) || !validacion )
            {
                var cliente = _query.GetCliente(dni);
                await _command.DeleteCliente(cliente.ClienteId);
            }
        }

        public List<Cliente> ListarClientes()
        {
            return _query.GetClienteAll().ToList();
        }

        public Cliente BuscarCliente(string dni)
        {
            int numero;
            bool validacion = int.TryParse(dni, out numero);
            if (!dni.Equals(null) || !validacion)
            {
                return _query.GetCliente(dni);
            }
            return null;
        }
    }
}
