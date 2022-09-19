using Aplication.Interface;
using Aplication.UseCase;
using Domain.Entities;
using Infrastructure.Commands;
using Infrastructure.Persistence;
using Infrastructure.Querys;

SaleDBContext conexion= new SaleDBContext();
IClienteQuery cq = new ClienteQuery(conexion);
IClienteCommand cc = new ClienteCommand(conexion);
ICarritoQuery ctq = new CarritoQuery(conexion);
ICarritoCommand ctc = new CarritoCommand(conexion);
IProductoQuery pq = new ProductoQuery(conexion);
IProductoCommand pc = new ProductoCommand(conexion);
ICarritoProductoQuery cpq = new CarritoProductoQuery(conexion);
ICarritoProductoCommand cpc = new CarritoProductoCommand(conexion);
IOrdenQuery oq = new OrdenQuery(conexion);
IOrdenCommand oc = new OrdenCommand(conexion);

ClientModule clienteMod = new ClientModule(cq, cc);
CarritoModule carritoMod = new CarritoModule(ctc, ctq);
ProductModule productoMod = new ProductModule(pq, pc);
CarritoProductoModule carritoProductoMod = new CarritoProductoModule(cpq, cpc);
OrdenModule ordenMod = new OrdenModule(oq, oc);




