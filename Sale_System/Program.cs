using Aplication.Interface;
using Domain.Entities;
using Infrastructure.Commands;
using Infrastructure.Persistence;
using Infrastructure.Querys;

SaleDBContext conexion= new SaleDBContext();




var a= new ClienteQuery(conexion).GetCliente(2);

Console.WriteLine(a.Apellido);