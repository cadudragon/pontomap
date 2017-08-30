using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PontoMap.Interfaces;
using PontoMap.Models;
using System.Text;

namespace PontoMap.DAOs
{
    public class EmpresaDao : BaseDao, ICrud<Empresa>
    {

        public bool Create(Empresa empresa)
        {
            strSql.Append("INSERT INTO [dbo].[Empresa]");
            strSql.Append("		([IdEmpresa]");
            strSql.Append("		,[DsCnpj]");
            strSql.Append("		,[DsRazaoSocial]");
            strSql.Append("		,[NmFantasia]");
            strSql.Append("		,[CdAtivo])");
            strSql.Append("	VALUES");
            strSql.Append("		(<IdEmpresa, int>");
            strSql.Append("		,<DsCnpj, varchar(50)>");
            strSql.Append("		,<DsRazaoSocial, varchar(50)>");
            strSql.Append("		,<NmFantasia, varchar(50)>");
            strSql.Append("		,<CdAtivo, bit>)");

            int ret = Execute(strSql.ToString());
            return true;
        }

        public Empresa Get(Empresa empresa)
        {
            return QueryFirstOrDefault<Empresa>("SELECT * FROM Accounts WHERE Id = @Id", new { empresa.IdEmpresa });
        }

        public List<Empresa> Read(Empresa empresa)
        {
            strSql.Append("SELECT [IdEmpresa]");
            strSql.Append("		,[DsCnpj]");
            strSql.Append("		,[DsRazaoSocial]");
            strSql.Append("		,[NmFantasia]");
            strSql.Append("		,[CdAtivo]");
            strSql.Append("	FROM [dbo].[Empresa]");

            return Query<Empresa>(strSql.ToString());
        }

        public bool Update(Empresa empresa)
        {
            strSql.Append("UPDATE [dbo].[Empresa]");
            strSql.Append("	SET [IdEmpresa] = <IdEmpresa, int>");
            strSql.Append("		,[DsCnpj] = <DsCnpj, varchar(50)>");
            strSql.Append("		,[DsRazaoSocial] = <DsRazaoSocial, varchar(50)>");
            strSql.Append("		,[NmFantasia] = <NmFantasia, varchar(50)>");
            strSql.Append("		,[CdAtivo] = <CdAtivo, bit>");
            strSql.Append("	WHERE <Search Conditions>");


            int ret = Execute(strSql.ToString());
            return true;
        }

        public bool Delete(Empresa empresa)
        {
            strSql.Append("DELETE FROM [dbo].[Empresa]");
            strSql.Append("		WHERE <Search Conditions>");

            int ret = Execute(strSql.ToString());
            return true;
        }
        
    }
}