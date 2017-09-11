using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontoMap.Models
{
    public class Ponto : BaseModel
    {
        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage = "Informe a empresa do Funcionário")]
        public int IdUsuario { get; set; }

        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage = "Informe a empresa do Funcionário")]
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "Data de Nascimento obrigatória")]
        [Display(Name = "Ponto")]
        public DateTime DtRegistro { get; set; }


        [Required(ErrorMessage = "Latitude Obrigatória")]
        public decimal CdLat { get; set; }

        [Required(ErrorMessage = "Latitude Obrigatória")]
        public decimal CdLng { get; set; }

    }
}