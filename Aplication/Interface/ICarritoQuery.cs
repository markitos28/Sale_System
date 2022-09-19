using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface ICarritoQuery
    {
        Carrito GetCarrito(Guid carritoId);
        Carrito GetCarrito(int clienteId, bool estado);
        IList<Carrito> GetCarritoAll();
    }
}
