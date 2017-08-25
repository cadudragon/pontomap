using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontoMap.Models
{
    public class Contato : BaseModel
    {
        public int IdContato { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome")]
        public string NmNome { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [Display(Name = "Email")]
        public string DsEmail { get; set; }

        [Required(ErrorMessage = "Assunto é obrigatório")]
        [Display(Name = "Assunto")]
        public string DsAssunto { get; set; }

        [Required(ErrorMessage = "Mensagem é obrigatório")]
        [Display(Name = "Mensagem")]
        public string DsMensagem { get; set; }
    }
}