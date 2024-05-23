using MDT.Model.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.UseCase.Invoice {
    public interface IInvoiceRequestUseCase
    {
        Task<string> AddInvoiceRequest(Dictionary<string, object> data);

    }
}
