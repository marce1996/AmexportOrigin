using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amexport.Models
{
    public class ShippersModel
    {
        public ShippersModel() { }

        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public int Phone { get; set; }
    }
}