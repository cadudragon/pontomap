using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoMap.Models;

namespace PontoMap.ViewModel
{
    public class RelatorioPontoViewModel
    {
        public Usuario Usuario { get; set; }


        public TipoRelatorio TipoRelatorio;


    }

    public enum TipoRelatorio
    {
        Mapa = 10,
        Pdf = 20,
        Grid = 30
    };

}