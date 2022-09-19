using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IOrdenQuery
    {
        Orden GetOrden(Guid ordeId);
        Orden GetOrdenCarrito(Guid carritoId);
        IList<Orden> GetOrdenAll();
    }
}
