using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoMap.BOs;
using PontoMap.CustomValidations;
using PontoMap.DAOs;
using PontoMap.Models;
using PontoMap.ViewModel;

namespace PontoMap.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            List<Usuario> usuarioList = new UsuarioBo().Read(new Usuario { IdEmpresa = int.Parse(Session["IdEmpresa"].ToString()) });

            var results = from usuario in usuarioList
                          where usuario.CdIsAdmin == false
                          select usuario;

            return View(results.ToList());
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

            if (usuario.Status == 1)
            {
                TempData["message"] = "Usuário cadastrado com sucesso;";
                return RedirectToAction("Index", "Usuario");
            }

            ModelState.AddModelError(string.Empty, usuario.Mensagem);
            return View(usuario);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? idUsuario)
        {

            if (idUsuario == null)
                return RedirectToAction("Index", "Usuario");

            Usuario usuario = new Usuario { IdEmpresa = int.Parse(Session["IdEmpresa"].ToString()), IdUsuario = (int)idUsuario };

            usuario = new UsuarioBo().Get(usuario);
            return View(usuario);

        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            usuario.IdEmpresa = int.Parse(Session["IdEmpresa"].ToString());
            new UsuarioBo().Update(usuario);

            if (usuario.Status == 1)
            {
                TempData["message"] = "Usuário editado com sucesso.";
                return RedirectToAction("Index", "Usuario");
            }

            ModelState.AddModelError(string.Empty, usuario.Mensagem);
            return View(usuario);


        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int idUsuario)
        {
            new UsuarioBo().Delete(new Usuario { IdUsuario = idUsuario, IdEmpresa = int.Parse(Session["IdEmpresa"].ToString()) });
            return Json(new { success = true, responseText = "Your message successfuly sent!" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "relatorios")]
        public ActionResult Relatorios(int? idUsuario)
        {

            if (idUsuario == null)
                return RedirectToAction("Index", "Usuario");

            Usuario usuario = new Usuario { IdEmpresa = int.Parse(Session["IdEmpresa"].ToString()), IdUsuario = (int)idUsuario };

            usuario = new UsuarioBo().Get(usuario);
            RelatorioPontoViewModel rel =  new RelatorioPontoViewModel();
            rel.Usuario = usuario;
            return View(rel);

        }





    }
}