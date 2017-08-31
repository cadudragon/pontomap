using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using PontoMap.Interfaces;
using PontoMap.Models;

namespace PontoMap.DAOs
{
    public class PerfilUsuarioDao : BaseDao, ICrud<PerfilUsuario>
    {
        private StringBuilder strSql = new StringBuilder();

        public bool Create(PerfilUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PerfilUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public PerfilUsuario Get(PerfilUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<PerfilUsuario> Read(PerfilUsuario tipoUsuario)
        {
            strSql.Append("SELECT [DsPerfilUsuario]");
            strSql.Append("	FROM [dbo].[PerfilUsuario]");

            return Query<PerfilUsuario>(strSql.ToString());
        }

        public bool Update(PerfilUsuario obj)
        {
            throw new NotImplementedException();
        }
    }
}