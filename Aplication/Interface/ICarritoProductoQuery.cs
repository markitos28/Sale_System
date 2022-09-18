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
        CarritoProducto GetCarritoProducto(int carritoId, int productoId);
        IList<CarritoProducto> GetCarritoProducto();
    }
}
