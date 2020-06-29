using Amexport.Models;
using AutoMapper;
using BLL.Interfaces;
using ENTITI;
using javax.xml.ws;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Amexport.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService<Employees> service;
        private readonly IMapper Mapper;

        public EmployeesController(IEmployeesService<Employees> service, IMapper mapper)
        {
            this.service = service;
            this.Mapper = mapper;
        }
        // GET: Categories
        public ActionResult Index()
        {
            ViewData["Titulo"] = "Empleados";
            ViewData["Entity"] = "Employees";
            ViewData["Controller"] = "Employees";


            return View(new List<EmployeesModel>());
        }

        public async Task<JsonResult> ListAsync()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            string start = (Request.Form["start"].FirstOrDefault()).ToString();
            int length = Request.Form["length"].FirstOrDefault();
            string sortColumn = (Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault()).ToString();
            string sortColumnDirection = (Request.Form["order[0][dir]"].FirstOrDefault()).ToString();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var dat = await service.List();
            
            var dataQ = dat.AsQueryable();
            
            if (!string.IsNullOrEmpty(searchValue.ToString()) && searchValue.ToString().Length > 2)
            {
                dataQ = dataQ.Where(m => m.LastName.IndexOf(searchValue.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
            }

            recordsTotal = dataQ.Count();
            var data = dataQ.Skip(skip).Take(pageSize).ToList();

            return Json(new
            {
                draw,
                recordsFiltered = recordsTotal,
                recordsTotal,
                data
            }, JsonRequestBehavior.AllowGet);
            
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employees/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase postedFile)
        {
            List<EmployeesModel> employees = new List<EmployeesModel>();
            EmployeesModel employees1 = new EmployeesModel();
            try
            {                
                   string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    string csvData = System.IO.File.ReadAllText(filePath);

                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            employees1.EmployeeID = Convert.ToInt32(row.Split(',')[0]);
                            employees1.LastName = row.Split(',')[1];
                            employees1.FirstName = row.Split(',')[2];
                            employees1.Title = row.Split(',')[3];
                            employees1.TitleOfCourtesy = row.Split(',')[4];
                            employees1.BirthDate = Convert.ToDateTime(row.Split(',')[5]);
                            employees1.HireDate = Convert.ToDateTime(row.Split(',')[6]);
                            employees1.Address = row.Split(',')[7];
                            employees1.City = row.Split(',')[8];
                            employees1.Region = row.Split(',')[9];
                            employees1.PostalCode = Convert.ToInt32(row.Split(',')[10]);
                            employees1.Country = row.Split(',')[11];
                            employees1.HomePhone = Convert.ToInt32(row.Split(',')[12]);
                            employees1.Extension = Convert.ToInt32(row.Split(',')[13]);
                            employees1.Photo = Convert.FromBase64String(row.Split(',')[14]);
                            employees1.Notes = row.Split(',')[15];
                            employees1.ReportsTo = Convert.ToInt32(row.Split(',')[16]);
                            employees.Add(employees1);


                            /*employees.Add(new EmployeesModel
                            {
                                EmployeeID = Convert.ToInt32(row.Split(',')[0]),
                                LastName = row.Split(',')[1],
                                FirstName = row.Split(',')[2],
                                Title = row.Split(',')[3],
                                TitleOfCourtesy = row.Split(',')[4],
                                BirthDate = Convert.ToDateTime(row.Split(',')[5]),
                                HireDate = Convert.ToDateTime(row.Split(',')[6]),
                                Address = row.Split(',')[7],
                                City = row.Split(',')[8],
                                Region = row.Split(',')[9],
                                PostalCode = Convert.ToInt32(row.Split(',')[10]),
                                Country = row.Split(',')[11],
                                HomePhone = Convert.ToInt32(row.Split(',')[12]),
                                Extension = Convert.ToInt32(row.Split(',')[13]),
                                Photo = Convert.FromBase64String(row.Split(',')[14]),
                                Notes = row.Split(',')[15],
                                ReportsTo = Convert.ToInt32(row.Split(',')[16])
                            });*/

                        }
                    }

                }
                return RedirectToAction("Index", employees);
            } 
            catch(Exception ex)
            {
                return RedirectToAction("Index", employees);
            }
            
        }

            // POST: Employees/Create
            /*[HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
