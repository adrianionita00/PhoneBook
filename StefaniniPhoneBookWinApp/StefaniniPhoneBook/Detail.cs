//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StefaniniPhoneBook
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detail
    {
        public int ID { get; set; }
        public int ContactID { get; set; }
        public int DetailTypeID { get; set; }
        public string DetailData { get; set; }
    
        public virtual Contact Contact { get; set; }
        public virtual DetailType DetailType { get; set; }
    }
}
