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
    
    public partial class Invoices
    {
        public Invoices()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetails>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ApartmentId { get; set; }
        public Nullable<int> BuildingId { get; set; }
        public Nullable<System.DateTime> PeriodStart { get; set; }
        public Nullable<System.DateTime> PeriodEnd { get; set; }
        public Nullable<decimal> TotalAmound { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
