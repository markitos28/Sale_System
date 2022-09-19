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
    public class CarritoCommand: ICarritoCommand
    {
        private readonly SaleDBContext _context;

        public CarritoCommand(SaleDBContext context)
        {
            _context = context;
        }

        public async Task DeleteCarrito(int carritoId)
        {
            var carrito = _context.Carrito.Find(carritoId);
            _context.Carrito.Remove(carrito);
            await _context.SaveChangesAsync();
        }

        public async Task InsertCarrito(Carrito carrito)
        {
            _context.Add(carrito);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarrito(Guid carritoId,bool estado)
        {
            var updCarrito= _context.Carrito.Find(carritoId);
            updCarrito.Estado = estado;
            await _context.SaveChangesAsync();
        }
    }
}
