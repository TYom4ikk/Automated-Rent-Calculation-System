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
    
    public partial class Regions
    {
        public Regions()
        {
            this.Buildings = new HashSet<Buildings>();
            this.Tariffs = new HashSet<Tariffs>();
        }
    
        public short Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Buildings> Buildings { get; set; }
        public virtual ICollection<Tariffs> Tariffs { get; set; }
    }
}
