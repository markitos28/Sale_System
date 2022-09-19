using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class OrdenModule
    {
        readonly IOrdenQuery _query;
        readonly IOrdenCommand _command;

        public OrdenModule(IOrdenQuery query, IOrdenCommand command)
        {
            _query = query;
            _command = command;
        }

        public async Task GenerarOrden(Guid carritoId, List<Producto> productos)
        {
            var orden= _query.GetOrdenCarrito(carritoId);
            if (orden == null)
            {
                /* Creamos una nueva orden para el carrito */
                decimal total = 0;
                foreach (Producto cp in productos)
                {
                    total += cp.Precio;
                }
                await _command.InsertOrden(new Orden
                {
                    CarritoId = carritoId,
                    Fecha = DateTime.Now,
                    Total = total
                });
            }
            else
            {
                /* Sumamos los productos a la orden */
                decimal total = 0;
                foreach (Producto cp in productos)
                {
                    total += cp.Precio;
                }
                await _command.UpdateOrden(orden.OrdenId, total);
            }
        }

        public Orden GetOrden(Guid carritoId)
        {
            
            return _query.GetOrden(carritoId);

        }
    }
}
