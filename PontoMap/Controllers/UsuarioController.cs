using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoMap.BOs;
using PontoMap.DAOs;
using PontoMap.Models;

namespace PontoMap.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            List<Usuario> usuarioList = new UsuarioBo().Read(new Usuario{IdEmpresa = int.Parse(Session["IdEmpresa"].ToString()) });

            if (usuarioList != null)
                return View(usuarioList);

            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            usuario.CdPassword = usuario.CdCpf;
            usuario.IdEmpresa = int.Parse(Session["IdEmpresa"].ToString());
            new UsuarioBo().Create(usuario);

            if(usuario.Status == 1)
                return RedirectToAction("Index", "Usuario");

            ModelState.AddModelError(string.Empty, usuario.Mensagem);
            return View(usuario);
        }
    }
}