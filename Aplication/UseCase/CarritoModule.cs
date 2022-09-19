using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class CarritoModule
    {
        readonly ICarritoCommand _command;
        readonly ICarritoQuery _query;

        public CarritoModule(ICarritoCommand command, ICarritoQuery query)
        {
            _command = command;
            _query = query;
        }

        public Carrito GetCarrito(int clienteId)
        {
            /* Retorna un carrito activo. Si no existe, lo crea */
            var carritoOn = _query.GetCarrito(clienteId, true);
            if(carritoOn.Equals(null))
            {
                carritoOn = new Carrito
                {
                    ClienteId = clienteId,
                    Estado = true,
                };
                _command.InsertCarrito( carritoOn);
                return carritoOn;
            }
            else
            {
                return carritoOn;
            }
        }

        public void CierreCarrito(int clienteId)
        {
            /* Cierra la instancia del carrito luego de concretarse una compra */
            var carritoOn = _query.GetCarrito(clienteId, true);
            if(!carritoOn.Equals(null))
            {
                _command.UpdateCarrito(carritoOn.CarritoId, false);
            }
        }
    }
}
