using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PontoMap.CustomValidations;
using PontoMap.DAOs;
using PontoMap.Interfaces;
using PontoMap.Models;

namespace PontoMap.BOs
{
    public class UsuarioBo : ICrud<Usuario>
    {
        public bool Create(Usuario usuario)
        {
            try
            {
                List<string> atributosParaValidar = new List<string>();
                atributosParaValidar.Add(nameof(Usuario.CdCpf));
                atributosParaValidar.Add(nameof(Usuario.DsEmail));
                atributosParaValidar.Add(nameof(Usuario.DsCelular));
                atributosParaValidar.Add(nameof(Usuario.CdPassword));
                atributosParaValidar.Add(nameof(Usuario.DtNascimento));
                atributosParaValidar.Add(nameof(Usuario.NmUsuario));

                if (Util.ValidaAtributos(usuario, atributosParaValidar))
                {
                    return new UsuarioDao().Create(usuario);
                }
                return false;
            }
            catch (Exception ex)
            {
                usuario.Mensagem = ex.ToString();
                return false;
            }
        }

        public bool Delete(Usuario usuario)
        {
            try
            {
                List<string> atributosParaValidar = new List<string>();
                atributosParaValidar.Add(nameof(usuario.IdUsuario));
                atributosParaValidar.Add(nameof(usuario.IdEmpresa));
                if (Util.ValidaAtributos(usuario, atributosParaValidar))
                {
                    return new UsuarioDao().Delete(usuario);
                }
                return false;
            }
            catch (Exception ex)
            {
                usuario.Mensagem = ex.ToString();
                return false;
            }
        }

        public Usuario Login(Usuario usuario)
        {

            try
            {

                List<string> atributosParaValidar = new List<string>();
                atributosParaValidar.Add(nameof(usuario.DsEmail));
                atributosParaValidar.Add(nameof(usuario.CdPassword));
                if (Util.ValidaAtributos(usuario, atributosParaValidar))
                {
                    return new UsuarioDao().Login(usuario);
                }
                return null;
            }
            catch (Exception ex)
            {
                usuario.Mensagem = ex.ToString();
                return null;
            }
        }

        public List<Usuario> Read(Usuario usuario)
        {
            try
            {
                List<string> atributosParaValidar = new List<string>();
                atributosParaValidar.Add(nameof(usuario.IdEmpresa));
                if (Util.ValidaAtributos(usuario, atributosParaValidar))
                    return new UsuarioDao().Read(usuario);
                return null;
            }
            catch (Exception ex)
            {
                usuario.Mensagem = ex.ToString();
                return null;
            }

        }

        public bool Update(Usuario usuario)
        {
            try
            {
                if (Util.ValidaObjeto(usuario))
                    return new UsuarioDao().Update(usuario);

                return false;
            }
            catch (Exception ex)
            {
                usuario.Mensagem = ex.ToString();
                return false;
            }
        }
    }
}