using Newtonsoft.Json;
using PontoMap.BOs;
using PontoMap.CustomValidations;
using PontoMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PontoMap.Controllers
{
    public class RelatorioController : Controller
    {

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult GetRel(DateTime dtInicial, DateTime dtFinal, string tipoRel, string idUsuario)
        {
            Ponto ponto = new Ponto
            {
                IdEmpresa = Util.ValidaInteiro(Session["IdEmpresa"].ToString(), 0),
                IdUsuario = Util.ValidaInteiro(idUsuario, 0)
            };
            List<Ponto> pontos = new PontoBo().RelatorioPonto(ponto, dtInicial, dtFinal);

            if (ponto.Status != 1)
                return Content(JsonConvert.SerializeObject(ponto));

            switch (tipoRel)
            {
                case "grid":
                    return View("Grid", pontos);
                default:
                    return Content(JsonConvert.SerializeObject(ponto));
            }
        }
    }
}