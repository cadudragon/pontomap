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
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            try
            {
                Usuario testeUser;
                testeUser = new UsuarioDao().Get(usuario);

                if (testeUser == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                FormsAuthentication.SetAuthCookie(testeUser.DsEmail, false);
                Session["Nome"] = testeUser.NmUsuario;
                return RedirectToAction("About", "Home");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
