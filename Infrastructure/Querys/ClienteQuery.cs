using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Interface;
using Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Querys
{
    public class ClienteQuery: IClienteQuery
    {
        private readonly SaleDBContext _context;
        public ClienteQuery(SaleDBContext context)
        {
            _context = context;
        }

        public Cliente GetCliente(int clienteId)
        {
            //var cliente = _context.Cliente.Include(s => s.CarritosId)
            //    .FirstOrDefault(s => s.ClienteId == clienteId);

            var cliente = (from c in _context.Cliente
                           join a in _context.Carrito
                           on c.ClienteId equals a.ClienteId
                           select c).FirstOrDefault();
            return cliente;
        }

        public IList<Cliente> GetClienteAll()
        {
            var cliente = (from c in _context.Cliente
                           join a in _context.Carrito
                           on c.ClienteId equals a.ClienteId
                           select c).ToList();
            return cliente;
        }
    }
}
