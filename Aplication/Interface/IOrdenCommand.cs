using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IOrdenCommand
    {
        Task InsertOrden(Orden orden);
        Task DeleteOrden(int clienteId);
        Task UpdateOrden(Orden orden);
    }
}
