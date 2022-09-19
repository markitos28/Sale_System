using Aplication.Interface;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class ProductoQuery : IProductoQuery
    {
        readonly SaleDBContext _context;

        public ProductoQuery(SaleDBContext context)
        {
            _context = context;
        }

        public Producto GetProducto(int productoId)
        {
            var producto = (from p in _context.Producto
                            where p.ProductoId == productoId
                            select p).FirstOrDefault();
            return producto;
        }

        public Producto GetProducto(string codigo)
        {
            var producto = (from p in _context.Producto
                            where p.Codigo == codigo
                            select p).FirstOrDefault();
            return producto;
        }

        public IList<Producto> GetProductoAll()
        {
            var productos = (from p in _context.Producto
                            select p).ToList();
            return productos;
        }
    }
}
