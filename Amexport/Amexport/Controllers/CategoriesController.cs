﻿using AutoMapper;
using BLL.Interfaces;
using ENTITI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Amexport.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService<Categories> service;
        private readonly IMapper Mapper;

        public CategoriesController(ICategoriesService<Categories> service, IMapper mapper)
        {
            this.service = service;
            this.Mapper = mapper;
        }
        // GET: Categories
        public ActionResult Index()
        {
            ViewData["Titulo"] = "Categorias";
            ViewData["Entity"] = "Categories";
            ViewData["Controller"] = "Categories";


            return View();
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
                dataQ = dataQ.Where(m => m.CategoryName.IndexOf(searchValue.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
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

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
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
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categories/Edit/5
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

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
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
