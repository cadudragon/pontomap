using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontoMap.Models
{
    public class Empresa : BaseModel
    {

        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage = "Informe a empresa")]
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "CNPJ obrigatório")]
        [Display(Name = "CNPJ")]
        public string DsCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string DsRazaoSocial { get; set; }


        [Required(ErrorMessage = "Nome Fantasia obrigatório")]
        [Display(Name = "Nome Fantasia")]
        public string NmFantasia { get; set; }
        
    }
}