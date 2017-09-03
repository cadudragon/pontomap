using PontoMap.DAOs;
using PontoMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PontoMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Nos adequamos ao seu sistema atual!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contato.";

            return View();
        }
    }
}