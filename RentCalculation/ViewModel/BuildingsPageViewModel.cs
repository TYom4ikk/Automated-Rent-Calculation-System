using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using RentCalculation.Model;

namespace RentCalculation.ViewModel
{
    internal class BuildingsPageViewModel
    {
        public List<Regions> GetRegions()
        {
            return Core.context.Regions.ToList();
        }
        public List<Buildings> GetBuildings()
        {
            return Core.context.Buildings.ToList();
        }
        public Buildings FindBuildingById(int id)
        {
            return Core.context.Buildings.Find(id);
        }
        public void RemoveBuilding(Buildings building)
        {
            Core.context.Buildings.Remove(building);
            Core.context.SaveChanges();
        }
        public void AddBuilding(Buildings building)
        {
            Core.context.Buildings.Add(building);
            Core.context.SaveChanges();
        }
    }
}
