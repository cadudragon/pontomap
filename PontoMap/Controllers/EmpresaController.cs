using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PontoMap.Controllers
{
    public class EmpresaController : Controller
    {

        [Authorize(Roles = "master")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "master")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "master")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "master")]
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

        [Authorize(Roles = "master")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize(Roles = "master")]
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

        [Authorize(Roles = "master")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "master")]
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
