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
    
    public partial class InvoiceDetails
    {
        public long Id { get; set; }
        public Nullable<int> InvoiceId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> Consumption { get; set; }
        public Nullable<decimal> Amount { get; set; }
    
        public virtual Invoices Invoices { get; set; }
        public virtual Services Services { get; set; }
    }
}
