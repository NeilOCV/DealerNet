//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class orders
    {
        public int id { get; set; }
        public string order_number { get; set; }
        public System.DateTime order_date { get; set; }
        public int order_status { get; set; }
        public int items_id { get; set; }
    
        public virtual items items { get; set; }
    }
}
