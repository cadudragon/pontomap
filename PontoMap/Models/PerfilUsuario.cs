using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontoMap.Models
{
    public class PerfilUsuario : BaseModel
    {

        [Required(ErrorMessage = "Descrição do Perfil de usuário obrigatória")]
        [Display(Name = "Descrição do Perfil de usuário")]
        public string DsPerfilUsuario { get; set; }

    }
}