using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontoMap.Models
{
    public class Usuario : BaseModel
    {
        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage = "Informe o Id do usuário")]
        public int IdUsuario { get; set; }

        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage = "Informe a empresa do Funcionário")]
        public int IdEmpresa { get; set; }

        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage = "Informe a empresa do Funcionário")]
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        [Display(Name = "CPF")]
        public string CdCpf { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [Display(Name = "Email")]
        public string DsEmail { get; set; }

        [Required(ErrorMessage = "Celular obrigatório")]
        [Display(Name = "Celular")]
        public string DsCelular { get; set; }

        [Required(ErrorMessage = "Senha obrigatório")]
        [Display(Name = "Celular")]
        public string CdPassword { get; set; }


        [Required(ErrorMessage = "Data de Nascimento obrigatória")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DtNascimento { get; set; }

        [Required(ErrorMessage = "Nome do Funcionário obrigatório")]
        [Display(Name = "Nome Funcionário")]
        public string NmUsuario { get; set; }
    }
}