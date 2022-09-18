using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface ICarritoProductoCommand
    {
        Task InsertCarritoProducto(CarritoProducto carritoProducto);
        Task DeleteCarritoProducto(int carritoId, int productoId);
    }
}
