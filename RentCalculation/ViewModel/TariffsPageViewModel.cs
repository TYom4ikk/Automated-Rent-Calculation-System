using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCalculation.Model;

namespace RentCalculation.ViewModel
{
    public class TariffsPageViewModel
    {
        public List<Services> GetServices()
        {
            return Core.context.Services.ToList();
        }
        public List<Regions> GetRegions()
        {
            return Core.context.Regions.ToList();
        }
        public List<Tariffs> GetTariffs()
        {
            return Core.context.Tariffs.ToList();
        }
        public void AddTariff(Tariffs tariff)
        {
            Core.context.Tariffs.Add(tariff);
            Core.context.SaveChanges();
        }

        public void RemoveTariff(Tariffs tariff)
        {
            Core.context.Tariffs.Remove(tariff);
            Core.context.SaveChanges();
        }
    }
}
