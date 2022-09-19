using Aplication.Interface;
using Domain.Entities;
using Infrastructure.Migrations;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class CarritoProductoQuery : ICarritoProductoQuery
    {
        readonly SaleDBContext _context;

        public CarritoProductoQuery(SaleDBContext context)
        {
            _context = context;
        }

        public CarritoProducto GetCarritoProducto(Guid carritoId, int productoId)
        {
            var carritoProducto = (from cp in _context.CarritoProducto
                                   where cp.CarritoId == carritoId &&
                                   cp.ProductoId == productoId
                                   select cp).FirstOrDefault();
            return carritoProducto;
        }

        public IList<CarritoProducto> GetCarritoProducto(Guid carritoId)
        {
            var carritoProductos = (from cp in _context.CarritoProducto
                                    where cp.CarritoId == carritoId
                                    select cp).ToList();
            return carritoProductos;
        }

        public IList<CarritoProducto> GetCarritoProductoAll()
        {
            var carritoProductos = (from cp in _context.CarritoProducto
                                   select cp).ToList();
            return carritoProductos;
        }

    }
}
