using PontoMap.DAOs;
using PontoMap.Interfaces;
using PontoMap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PontoMap.BOs
{
    public class EmpresaBo : ICrud<Empresa>
    {
        public bool Create(Empresa empresa)
        {
            try
            {
               
                return new EmpresaDao().Create(empresa);
            }
            catch (SqlException sqlExc)
            {
                foreach (SqlError error in sqlExc.Errors)
                {
                    empresa.Status = 0;

                    if(error.Number == 50000)
                    {
                        empresa.Mensagem = "Já existe uma empresa e/ou um funcinário com as informações fornecidas no sistema, para dúvidas ou informações entre em contato";
                        return false;
                    }
                    empresa.Mensagem += string.Format("{0}: {1}", error.Number, error.Message);
                }
                return false;
            }
            catch (Exception ex)
            {
                empresa.Status = 0;
                empresa.Mensagem = ex.ToString();
                return false;
            }
        }

        public bool Delete(Empresa empresa)
        {
            try
            {
                if (new EmpresaDao().Delete(empresa))
                {
                    empresa.Status = 1;
                    empresa.Mensagem = "Empresa Excluida com sucesso!";
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                empresa.Mensagem = ex.ToString();
                return false;
            }
        }

        public Empresa Login(Empresa empresa)
        {
            try
            {
                return new EmpresaDao().Login(empresa);
            }
            catch (Exception ex)
            {
                empresa.Mensagem = ex.ToString();
                return null;
            }
        }

        public List<Empresa> Read(Empresa empresa)
        {
            try
            {
                return new EmpresaDao().Read(empresa);
            }
            catch (Exception ex)
            {
                empresa.Mensagem = ex.ToString();
                return null;
            }
        }

        public bool Update(Empresa empresa)
        {
            try
            {
                if (new EmpresaDao().Update(empresa))
                {
                    empresa.Status = 1;
                    empresa.Mensagem = "Empresa Editada com sucesso!";
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                empresa.Mensagem = ex.ToString();
                return false;
            }
        }
    }
}