using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontoMap.Models
{
    public class Empresa : BaseModel
    {
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "CNPJ obrigatório")]
        [Display(Name = "CNPJ")]
        public string DsCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string DsRazaoSocial { get; set; }


        [Required(ErrorMessage = "Nome Fantasia obrigatório")]
        [Display(Name = "Nome Fantasia")]
        public string NmFantasia { get; set; }

        public bool CdAtivo { get; set; }
    }
}