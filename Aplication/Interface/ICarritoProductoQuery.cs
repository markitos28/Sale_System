using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface ICarritoProductoQuery
    {
        CarritoProducto GetCarritoProducto(Guid carritoId, int productoId);
        IList<CarritoProducto> GetCarritoProductoAll();
        IList<CarritoProducto> GetCarritoProducto(Guid carritoId);
    }
}
