using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StefaniniPhoneBook.Models
{
    public class Detail
    {
        public int DetailID { get; set; }
        public int DetailTypeID { get; set; }
        public int ContactID { get; set; }
        public string DetailData { get; set; }

        public virtual DetailType DetailType { get; set; }
        public virtual Contact Contact { get; set; }
    }
}