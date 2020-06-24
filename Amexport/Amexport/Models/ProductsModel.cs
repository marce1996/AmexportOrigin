using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amexport.Models
{
    public class ProductsModel
    {
        public ProductsModel() { }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public string Discontinued { get; set; }
    }
}