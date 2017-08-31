using Dapper;
using PontoMap.Interfaces;
using PontoMap.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace PontoMap.DAOs
{
    public class UsuarioDao : BaseDao, ICrud<Usuario>
    {
        private StringBuilder strSql = new StringBuilder();

        public bool Create(Usuario usuario)
        {
            strSql.Append("INSERT INTO [dbo].[Usuario]");
            strSql.Append("		 [IdEmpresa]");
            strSql.Append("		,[IdTipoUsuario]");
            strSql.Append("		,[CdCpf]");
            strSql.Append("		,[DsEmail]");
            strSql.Append("		,[DsCelular]");
            strSql.Append("		,[CdPassword]");
            strSql.Append("		,[DtNascimento]");
            strSql.Append("		,[NmUsuario])");
            strSql.Append("	VALUES");
            strSql.Append("	    (@IdEmpresa");
            strSql.Append("		,@IdTipoUsuario");
            strSql.Append("		,@CdCpf");
            strSql.Append("		,@DsEmail");
            strSql.Append("		,@DsCelular");
            strSql.Append("		,@CdPassword");
            strSql.Append("		,@DtNascimento");
            strSql.Append("		,@NmUsuario)");


            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@IdTipoUsuario", usuario.IdTipoUsuario, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@CdCpf", usuario.CdCpf, DbType.String, ParameterDirection.Input);
            parametros.Add("@DsEmail", usuario.DsEmail, DbType.String, ParameterDirection.Input);
            parametros.Add("@DsCelular", usuario.DsCelular, DbType.String, ParameterDirection.Input);
            parametros.Add("@CdPassword", usuario.CdPassword, DbType.String, ParameterDirection.Input);
            parametros.Add("@DtNascimento", usuario.DtNascimento, DbType.String, ParameterDirection.Input);
            parametros.Add("@NmUsuario", usuario.NmUsuario, DbType.String, ParameterDirection.Input);

            int ret = Execute(strSql.ToString(), parametros);
            return true;
        }

        public Usuario Get(Usuario usuario)
        {
            strSql.Append("SELECT [Idusuario]");
            strSql.Append("		,[IdEmpresa]");
            strSql.Append("		,[IdTipoUsuario]");
            strSql.Append("		,[CdCpf]");
            strSql.Append("		,[DsEmail]");
            strSql.Append("		,[DsCelular]");
            strSql.Append("		,[CdPassword]");
            strSql.Append("		,[DtNascimento]");
            strSql.Append("		,[NmUsuario]");
            strSql.Append("		,[CdAtivo]");
            strSql.Append("	FROM [dbo].[Usuario]");
            strSql.Append("  WHERE DsEmail = @DsEmail AND CdPassword = @CdPassword");

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@DsEmail", usuario.DsEmail, DbType.String, ParameterDirection.Input);
            parametros.Add("@CdPassword", usuario.CdPassword, DbType.String, ParameterDirection.Input);

            return QueryFirstOrDefault<Usuario>(strSql.ToString(), parametros);
        }

        public List<Usuario> Read(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}