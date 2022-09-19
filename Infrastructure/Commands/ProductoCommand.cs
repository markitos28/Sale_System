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
    public class ProductoCommand : IProductoCommand
    {
        private readonly SaleDBContext _context;

        public ProductoCommand(SaleDBContext context)
        {
            _context = context;
        }

        public async Task DeleteProducto(int productoId)
        {
            var producto = _context.Producto.Find(productoId);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
        }

        public async Task InsertProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducto(Producto producto)
        {
            var updProducto = _context.Producto.Find(producto.ProductoId);

            updProducto.Nombre= producto.Nombre.Equals(null)? updProducto.Nombre: producto.Nombre;
            updProducto.Descripcion = producto.Descripcion.Equals(null) ? updProducto.Descripcion : producto.Descripcion;
            updProducto.Marca = producto.Marca.Equals(null) ? updProducto.Marca : producto.Marca;
            updProducto.Codigo = producto.Codigo.Equals(null) ? updProducto.Codigo : producto.Codigo;
            updProducto.Precio = producto.Precio.Equals(null) ? updProducto.Precio : producto.Precio;
            updProducto.Image = producto.Image.Equals(null) ? updProducto.Image : producto.Image;

            await _context.SaveChangesAsync();

        }
    }
}
