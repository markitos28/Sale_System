using Aplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Aplication.UseCase
{
    public  class CarritoProductoModule
    {
        readonly ICarritoProductoQuery _query;
        readonly ICarritoProductoCommand _command;

        public CarritoProductoModule(ICarritoProductoQuery query, ICarritoProductoCommand command)
        {
            _query = query;
            _command = command;
        }

        public async Task AgregarProductoACarrito(Guid carritoId, int productoId, int cantidad)
        {
            var carritoProducto = _query.GetCarritoProducto(carritoId, productoId);
            if(carritoProducto == null)
            {
                await _command.InsertCarritoProducto(new CarritoProducto
                {
                    CarritoId = carritoId,
                    ProductoId= productoId,
                    Cantidad= cantidad
                });
            }
            else
            {
                
            }
        }
    }
}
