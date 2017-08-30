using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontoMap.Models
{
    public class Ponto
    {
        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage = "Informe a empresa do Funcionário")]
        public int Idusuario { get; set; }

        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage = "Informe a empresa do Funcionário")]
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "Data de Nascimento obrigatória")]
        [Display(Name = "Ponto")]
        public DateTime DtRegistro { get; set; }


        [Range(1.0, Double.MaxValue)]
        [Required(ErrorMessage = "Latitude Obrigatória")]
        public decimal CdLat { get; set; }

        [Range(1.0, Double.MaxValue)]
        [Required(ErrorMessage = "Latitude Obrigatória")]
        public decimal CdLng { get; set; }

    }
}