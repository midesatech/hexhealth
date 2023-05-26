using System.Threading.Tasks;
using System.Collections.Generic;

namespace MDT.Model.Gateway
{
    public interface IEmpleadoRepository
    {
         Task<Empleado> ObtenerEmpleadoPorCodigo(string codigo);
         List<Empleado> ObtenerListaEmpleados();
    }
}