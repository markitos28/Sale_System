using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class ProductModule
    {
        readonly IProductoCommand _command;
        readonly IProductoQuery _query;

        public ProductModule(IProductoQuery query, IProductoCommand command)
        {
            _command = command;
            _query = query;
        }

        public async Task AltaProducto(string nombre, string descripcion, string marca, string codigo, decimal precio, string imagen)
        {
            if (!nombre.Equals(null) ||
                !descripcion.Equals(null) ||
                !marca.Equals(null) ||
                !codigo.Equals(null) ||
                !precio.Equals(null) ||
                 precio.Equals(0) ||
                 imagen.Equals(null)
                )
            {
                await _command.InsertProducto(new Producto
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Marca = marca,
                    Codigo = codigo,
                    Precio = precio,
                    Image = imagen
                });
            };
        }
        public async Task BorrarProducto(string codigo)
        {
            if(codigo == null)
            {
                var producto = _query.GetProducto(codigo);
                await _command.DeleteProducto(producto.ProductoId);
            }
            
        }

        public List<Producto> ListarProductos()
        {
            return _query.GetProductoAll().ToList();
        }
        
    }
}
