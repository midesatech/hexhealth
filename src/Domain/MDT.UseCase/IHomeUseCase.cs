using System.Threading.Tasks;
using MDT.Model;
using System.Collections.Generic;

namespace MDT.UseCase
{
    public interface IHomeUseCase
    {
        Task<List<Empleado>> ObtenerListaEmpleados();
        Task<Empleado> ObtenerEmpleadoPorCodigo(string codigo);
    }
}