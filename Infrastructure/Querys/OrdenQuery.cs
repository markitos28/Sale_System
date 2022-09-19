using Aplication.Interface;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class OrdenQuery:IOrdenQuery
    {
        readonly SaleDBContext _context;

        public OrdenQuery(SaleDBContext context)
        {
            _context = context;
        }

        public Orden GetOrden(Guid ordenId)
        {
            var orden = (from o in _context.Orden
                         where o.OrdenId == ordenId
                         select o).FirstOrDefault();
            return orden;
        }
        public Orden GetOrdenCarrito(Guid carritoId)
        {
            var orden = (from o in _context.Orden
                         where o.CarritoId == carritoId
                         select o).FirstOrDefault();
            return orden;
        }

        public IList<Orden> GetOrdenAll()
        {
            var ordenes = (from o in _context.Orden
                         select o).ToList();
            return ordenes;
        }
    }
}
