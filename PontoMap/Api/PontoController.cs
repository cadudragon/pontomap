using PontoMap.CustomValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        [HttpGet]
        [Route("api/data/autenticado")]
        public IHttpActionResult autenticado()
        {
            return Ok("Krai de asa, Now server time is: " + Util.HrBrasilia());
        }
    }
}
