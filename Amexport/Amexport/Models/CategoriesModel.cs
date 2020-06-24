using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amexport.Models
{
    public class CategoriesModel
    {
        public CategoriesModel() { }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

    }
}