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
    public class OrdenCommand : IOrdenCommand
    {
        private readonly SaleDBContext _context;

        public OrdenCommand(SaleDBContext context)
        {
            _context = context;
        }
        public async Task DeleteOrden(int ordenId)
        {
            var orden = _context.Orden.Find(ordenId);
            _context.Orden.Remove(orden);
            await _context.SaveChangesAsync();
        }

        public async Task InsertOrden(Orden orden)
        {
            _context.Orden.Add(orden);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrden(Guid ordenId, decimal total)
        {
            var updOrden = _context.Orden.Find(ordenId);
            updOrden.Total += total;
            await _context.SaveChangesAsync();
        }
    }
}
