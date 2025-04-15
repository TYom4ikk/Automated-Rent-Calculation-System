using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCalculation.Model;

namespace RentCalculation.ViewModel
{
    public class InvoicesPageViewModel
    {
        public Users GetUserById(int id)
        {
            return Core.context.Users
                    .FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<Invoices> GetInvoicesByApartmentId(int id)
        {
            return (IEnumerable<Invoices>)Core.context.Invoices
                    .Where(i => i.ApartmentId == id)
                    .OrderByDescending(i => i.Id)
                    .Select(i => new
                    {
                        i.Id,
                        Period = $"Квитанция №{i.Id}",
                        i.TotalAmound,
                    })
                    .ToList();
        }
    }
}
