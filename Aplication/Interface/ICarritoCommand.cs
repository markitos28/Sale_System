using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface ICarritoCommand
    {
        Task InsertCarrito(Carrito carrito);
        Task DeleteCarrito(int carritoId);
        Task UpdateCarrito(Carrito carrito);
    }
}
