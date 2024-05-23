using MDT.Model.Data;
using MDT.UseCase.Invoice;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.Web
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowOrigin")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRequestUseCase requestUseCase;

        public InvoiceController(IInvoiceRequestUseCase requestUseCase)
        {
            this.requestUseCase = requestUseCase;
        }


        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<string>> CreateInvoiceRequest([FromBody] Dictionary<string, object> data)
        {
            try
            {
                if (data == null)
                    return BadRequest();

                var createdAward = await requestUseCase.AddInvoiceRequest(data);

                return createdAward;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new award record");
            }
        }
    }
}
