using Aplication.Interface;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class CarritoQuery : ICarritoQuery
    {
        readonly SaleDBContext _context;

        public CarritoQuery(SaleDBContext context)
        {
            _context = context;
        }

        public Carrito GetCarrito(Guid carritoId)
        {
            var carrito = (from c in _context.Carrito
                           where c.CarritoId == carritoId
                           select c).FirstOrDefault();
            return carrito;
        }

        public Carrito GetCarrito(int clienteId, bool estado)
        {
            var carrito = (from c in _context.Carrito
                           where c.Estado== estado
                           && c.ClienteId == clienteId
                           select c).FirstOrDefault();
            return carrito;
        }

        public IList<Carrito> GetCarritoAll()
        {
            var carritos = (from c in _context.Carrito
                           select c).ToList();
            return carritos;
        }
    }
}
