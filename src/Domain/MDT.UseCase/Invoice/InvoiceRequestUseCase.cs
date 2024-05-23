using MDT.Model.Gateway;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.UseCase.Invoice
{
    public class InvoiceRequestUseCase : IInvoiceRequestUseCase
    {
        //private readonly IInvoiceRepository _repository;

        public InvoiceRequestUseCase()
        {
 //           _repository = repository;
        }

        public Task<string> AddInvoiceRequest(Dictionary<string, object> values)
        {
            return Task.Run(() =>
            {
                try
                {
                    foreach( KeyValuePair<string, object> kvp in values )
                    {
                       Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    }
                    return "Hi";
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
