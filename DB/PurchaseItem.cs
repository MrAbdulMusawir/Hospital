//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseItem
    {
        public int ID { get; set; }
        public Nullable<int> PurchaseID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<int> SalePercentage { get; set; }
        public Nullable<int> PurchasePercentage { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
    
        public virtual Purchase Purchase { get; set; }
    }
}