using Microsoft.Owin.Security.OAuth;
using PontoMap.BOs;
using PontoMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace PontoMap
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Valida as requisições posteriores ao login 
        /// Fonte: https://msdn.microsoft.com/en-us/library/microsoft.owin.security.oauth.oauthauthorizationserverprovider.validateclientauthentication(v=vs.113).aspx
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.FromResult(context.Validated());
        }

        /// <summary>
        /// Metodo que é acionado no login da webApi pela uri/token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            Usuario user = new Usuario { CdPassword = context.Password, DsEmail = context.UserName };
            user = new UsuarioBo().Login(user);

            if (user != null)
            {

                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("credencial", new JavaScriptSerializer().Serialize(user)));
                identity.AddClaim(new Claim(ClaimTypes.Name, "user name"));
                await Task.FromResult(context.Validated(identity));
            }
            else
            {
                context.SetError("Credenciais invalidas", "Combinação de Usuário e senha incorreta.");
                return;
            }
        }
    }
}