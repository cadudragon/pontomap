using PontoMap.CustomValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PontoMap.BOs;
using PontoMap.Models;

namespace PontoMap.Api
{
    public class PontoController : ApiController
    {

        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/time")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is: " + DateTime.Now);
        }

        [Authorize]
        [HttpPost]
        [Route("api/ponto/RegistrarPonto")]
        public IHttpActionResult RegistrarPonto()
        {
            Ponto ponto = new Ponto();

            if (string.IsNullOrWhiteSpace(HttpContext.Current.Request.Params["lat"]) ||
                string.IsNullOrWhiteSpace(HttpContext.Current.Request.Params["lng"]))
            {
                ponto.Mensagem = "lat e lng obrigatórios";
                return Content(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(ponto));
            }


            var identity = (ClaimsIdentity)User.Identity;
            dynamic obj = new JavaScriptSerializer().DeserializeObject(identity.FindFirst("credencial").Value);

            ponto = new Ponto
            {
                CdLat = decimal.Parse(HttpContext.Current.Request.Params["lat"]),
                CdLng = decimal.Parse(HttpContext.Current.Request.Params["lng"]),
                IdEmpresa = int.Parse(obj["IdEmpresa"].ToString()),
                IdUsuario = int.Parse(obj["IdUsuario"].ToString()),
                DtRegistro = Util.HrBrasilia()
            };

            new PontoBo().Create(ponto);

            if (ponto.Status == 1)
            {
                return Ok(JsonConvert.SerializeObject(ponto));
            }
            return BadRequest(JsonConvert.SerializeObject(ponto));
        }

        [Authorize]
        [HttpGet]
        [Route("api/data/autenticado")]
        public IHttpActionResult GetPontoList()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            Usuario user = new Usuario { IdUsuario = int.Parse(identity.FindFirst("IdUsuario").Value) };

            return Ok("Krai de asa, Now server time is: " + Util.HrBrasilia());
        }


    }
}
