//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentCalculation.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Services
    {
        public Services()
        {
            this.BuildingFacilities = new HashSet<BuildingFacilities>();
            this.InvoiceDetails = new HashSet<InvoiceDetails>();
            this.MeterReadings = new HashSet<MeterReadings>();
            this.Tariffs = new HashSet<Tariffs>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    
        public virtual ICollection<BuildingFacilities> BuildingFacilities { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual ICollection<MeterReadings> MeterReadings { get; set; }
        public virtual ICollection<Tariffs> Tariffs { get; set; }
    }
}
