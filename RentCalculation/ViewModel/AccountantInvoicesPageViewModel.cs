using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCalculation.Model;

namespace RentCalculation.ViewModel
{
    internal class AccountantInvoicesPageViewModel
    {
        public List<Buildings> GetBuildings()
        {
            return Core.context.Buildings.ToList();
        }
        public List<Invoices> GetInvoicesByDesc()
        {
            return Core.context.Invoices
                    .Include("Buildings")
                    .Include("Apartments")
                    .OrderByDescending(i => i.CreatedAt)
                    .ToList();
        }

        public List<Apartments> GetApartmentsByBuilding(int id)
        {
            return Core.context.Apartments
                    .Where(a => a.BuildingId == id)
                    .ToList();
        }
    }
}
