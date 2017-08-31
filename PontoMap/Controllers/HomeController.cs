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


        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario, string returnUrl)
        {
            Usuario testeUser;
            testeUser = new UsuarioDao().Get(usuario);

            if (testeUser == null)
            {
                return RedirectToAction("Index");
            }


            FormsAuthentication.SetAuthCookie(testeUser.DsEmail, false);
            Session["Nome"] = testeUser.NmUsuario;
            return RedirectToAction("About", "Home");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [Authorize (Roles = "master")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}