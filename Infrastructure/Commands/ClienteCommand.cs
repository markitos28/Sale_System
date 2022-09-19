using Aplication.Interface;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class ClienteCommand: IClienteCommand
    {
        private readonly SaleDBContext _context;

        public ClienteCommand(SaleDBContext context)
        {
            _context = context;
        }

        public async Task DeleteCliente(int clienteId)
        {
            var cliente = _context.Cliente.Find(clienteId);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task InsertCliente(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateCliente(Cliente cliente)
        {
            /* Para actualizar un registro de cliente se pasa todo el objeto y solo actualiza lo que no venga nulo*/
            var updCliente = _context.Cliente.Find(cliente.ClienteId);

            updCliente.DNI= cliente.DNI.Equals(null) ? updCliente.DNI : cliente.DNI;
            updCliente.Nombre = cliente.Nombre.Equals(null) ? updCliente.Nombre : cliente.Nombre;
            updCliente.Apellido = cliente.Apellido.Equals(null) ? updCliente.Apellido : cliente.Apellido;
            updCliente.Direccion = cliente.Direccion.Equals(null) ? updCliente.Direccion: cliente.Direccion;
            updCliente.Telefono = cliente.Telefono.Equals(null) ? updCliente.Telefono : cliente.Telefono;

            await _context.SaveChangesAsync();
        }
    }
}
