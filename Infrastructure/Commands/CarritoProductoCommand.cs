using Aplication.Interface;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class CarritoProductoCommand : ICarritoProductoCommand
    {
        private readonly SaleDBContext _context;

        public CarritoProductoCommand(SaleDBContext context)
        {
            _context = context;
        }
        public async Task DeleteCarritoProducto(int carritoId, int productoId)
        {
            var carritoProducto = _context.CarritoProducto.Find(carritoId,productoId);
            _context.CarritoProducto.Remove(carritoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task InsertCarritoProducto(CarritoProducto carritoProducto)
        {
            _context.Add(carritoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarritoProducto(int carritoId, int productoId, int cantidad)
        {
            var updCarritoProducto = _context.CarritoProducto.Find(carritoId,productoId);
            updCarritoProducto.Cantidad = cantidad;
            await _context.SaveChangesAsync();
        }
    }
}
