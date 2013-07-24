using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StefaniniPhoneBook.Models
{
    public class DetailType
    {
        public int DetailTypeID { get; set; }
        public string DetailTypeData { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}