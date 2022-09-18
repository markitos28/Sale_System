using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IProductoCommand
    {
        Task InsertProducto(Producto producto);
        Task DeleteProducto(int productoId);
        Task UpdateProducto(Producto producto);
    }
}
