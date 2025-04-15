using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCalculation.Model;

namespace RentCalculation.ViewModel
{
    public class MeterReadingsPageViewModel
    {
        public Apartments GetApartmentById(int id)
        {
            return Core.context.Apartments.Find(id);
        }
        public IEnumerable<MeterReadings> GetMeterReadingsByApartmentId(int id)
        {
            return (IEnumerable<MeterReadings>)Core.context.MeterReadings
                    .Where(r => r.ApartmentId == id)
                    .Select(r => new
                    {
                        ServiceName = r.Services.Name,
                        Date = r.Date,
                        Value = r.Value,
                        Unit = r.Services.Unit
                    })
                    .OrderByDescending(r => r.Date)
                    .ToList();
        }
    }
}
