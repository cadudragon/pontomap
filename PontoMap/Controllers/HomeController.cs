﻿using PontoMap.DAOs;
using PontoMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PontoMap.BOs;
using PontoMap.ViewModel;

namespace PontoMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
    }
}