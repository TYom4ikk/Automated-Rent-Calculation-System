using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCalculation.Model;

namespace RentCalculation.ViewModel
{
    internal class ServicesPageViewModel
    {
        public List<Services> GetServices()
        {
            return Core.context.Services.ToList();
        }

        public void AddService(Services service)
        {
            Core.context.Services.Add(service);
            Core.context.SaveChanges();
        }

        public Services FindServiceById(int id)
        {
            return Core.context.Services.Find(id);
        }

        public void RemoveService(Services service)
        {
            Core.context.Services.Remove(service);
            Core.context.SaveChanges();
        }
    }
}
