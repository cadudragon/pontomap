using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontoMap.Models
{
    public class TipoUsuario : BaseModel
    {

        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage = "Informe o Id do TipoUsuário")]
        public int IdTipoUsuario { get; set; }


        [Required(ErrorMessage = "Descrição do tipo de usuário obrigatória obrigatório")]
        [Display(Name = "Descrição do tipo de usuário")]
        public string DsTipoUsuario { get; set; }

    }
}