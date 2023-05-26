using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MDT.Model;
using MDT.Model.Gateway;

namespace MDT.UseCase
{
    public class HomeUseCase : IHomeUseCase
    {

        private readonly IEmpleadoRepository empleadoRepository;
        
        public HomeUseCase(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        public Task<List<Empleado>> ObtenerListaEmpleados()
        {
            return Task.Run(() =>
            {
                try
                {
                    return empleadoRepository.ObtenerListaEmpleados();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<Empleado> ObtenerEmpleadoPorCodigo(string codigo)
        {
            return Task.Run(() =>
            {
                try
                {
                    return empleadoRepository.ObtenerEmpleadoPorCodigo(codigo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }
    }
}