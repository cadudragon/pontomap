using PontoMap.BOs;
using PontoMap.DAOs;
using PontoMap.Models;
using PontoMap.ViewModel;
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

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

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
            var usuarioLogado = new UsuarioBo().Login(usuario);

            if (usuarioLogado == null)
            {
                //return RedirectToAction("Index", "Home");
                ModelState.AddModelError(string.Empty, "Usuário e/ou senha incorreto(s).");
                return View(usuario);
            }

            FormsAuthentication.SetAuthCookie(usuarioLogado.DsEmail, false);
            Session["Nome"] = usuarioLogado.NmUsuario;
            Session["IdEmpresa"] = usuarioLogado.IdEmpresa;
            Session["IdUsuario"] = usuarioLogado.IdUsuario;

            if (usuarioLogado.Perfis.Select(x => x.DsPerfil).Contains("master"))
            {
                return RedirectToAction("Index", "Empresa");
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrarViewModel registrarObj)
        {
            Empresa empresa = registrarObj.Empresa;
            empresa.UsuarioAdmin = registrarObj.Usuario;
            empresa.UsuarioAdmin.CdPassword = registrarObj.Password;

            new EmpresaBo().Create(empresa);

            if(empresa.Status == 0)
            {
                ModelState.AddModelError(string.Empty, empresa.Mensagem);
                return View(registrarObj);
            }

            
            return RedirectToAction("Login", "Account");
        }
    }
}
