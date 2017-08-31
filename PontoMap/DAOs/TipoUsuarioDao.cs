using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using PontoMap.Interfaces;
using PontoMap.Models;

namespace PontoMap.DAOs
{
    public class TipoUsuarioDao : BaseDao, ICrud<TipoUsuario>
    {
        private StringBuilder strSql = new StringBuilder();

        public bool Create(TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario Get(TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuario> Read(TipoUsuario tipoUsuario)
        {
            strSql.Append("SELECT [IdTipoUsuario]");
            strSql.Append("		,[DsTipoUsuario]");
            strSql.Append("	FROM [dbo].[TipoUsuario]");

            return Query<TipoUsuario>(strSql.ToString());
        }

        public bool Update(TipoUsuario obj)
        {
            throw new NotImplementedException();
        }
    }
}