using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amexport.Models
{
    public class EmployeesModel
    {
        public EmployeesModel() { }

        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public System.DateTime BirthDate { get; set; }
        public System.DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public int HomePhone { get; set; }
        public Nullable<int> Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public Nullable<int> ReportsTo { get; set; }
    }
}