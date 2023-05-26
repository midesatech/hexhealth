using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MDT.Model;
using MDT.Model.Gateway;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;

namespace MDT.MongoDb.Entities
{
    public class EmpleadoAdapter : IEmpleadoRepository
    {
        private readonly Context mongodb;


        public EmpleadoAdapter(string stringmongoconection, string databasename)
        {
            mongodb = new Context(stringmongoconection, databasename);
        }

        public Task<Empleado> ObtenerEmpleadoPorCodigo(string codigo)
        {
            return Task.Run(() =>
            {
                return MapperObject.mapperWithConstructor.Map<Empleado>(mongodb.Empleados.AsQueryable().FirstOrDefault(empleado => empleado.Codigo == codigo));
            });
        }

        public List<Empleado> ObtenerListaEmpleados()
        {           
            Console.Out.WriteLine("ObtenerListaEmpleados");
                var empleados = new List<Empleado>();

                mongodb.Empleados.AsQueryable().ToList().ForEach(empleado =>
                {
                    Console.Out.WriteLine(empleado.Codigo + "|" + empleado.Nombre + "|" + empleado.Apellido);
                    empleados.Add(MapperObject.mapper.Map<Empleado>(empleado));
                });
                return empleados;
            
        }
    }
}