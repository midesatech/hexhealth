using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MDT.UseCase;
using Microsoft.AspNetCore.Cors;

namespace MDT.Web
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowOrigin")]
    public class HomeController : ControllerBase
    {

        private readonly HomeUseCase homeUseCase;


        public HomeController(HomeUseCase homeUseCase)
        {
            this.homeUseCase = homeUseCase;
        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetFoo(string foo)
        {
            return await Task.Run(() =>
            {
                var ret = new { foo = foo };
                return Ok(ret);
            });
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetFood()
        {
            return await Task.Run(() =>
            {
                var food = new { Food = "Burger" };
                return Ok(food);
            });
        }

        
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetEmpleados()
        {
            var empleados = new 
            {
                empleados = await homeUseCase.ObtenerListaEmpleados()

            };

            return Ok(empleados);
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetEmpleado(string codigo)
        {
            var empleado = new 
            {
                empleado = await homeUseCase.ObtenerEmpleadoPorCodigo(codigo)

            };

            return Ok(empleado);
        }
        



    }
}
