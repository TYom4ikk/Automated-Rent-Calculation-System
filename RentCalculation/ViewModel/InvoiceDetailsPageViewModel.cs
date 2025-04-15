using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCalculation.Model;

namespace RentCalculation.ViewModel
{
    public class InvoiceDetailsPageViewModel
    {
        public Invoices GetInvoicesById(int id)
        {
            return Core.context.Invoices
                    .FirstOrDefault(i => i.Id == id);
        }
        public IEnumerable<Invoices> GetInvoicesByInvoiceId(int invoiceId)
        {
            return (IEnumerable<Invoices>)Core.context.InvoiceDetails
                    .Where(d => d.InvoiceId == invoiceId)
                    .Select(d => new
                    {
                        ServiceName = d.Services.Name,
                        Amount = d.Amount,
                        Unit = d.Services.Unit
                    })
                    .ToList();
        }
    }
}
