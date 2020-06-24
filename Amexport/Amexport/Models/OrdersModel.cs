using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amexport.Models
{
    public class OrdersModel
    {
        public OrdersModel() { }

        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime RequiredDate { get; set; }
        public System.DateTime ShippedDate { get; set; }
        public string ShipVia { get; set; }
        public string Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public int ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public int ShipperID { get; set; }
    }
}