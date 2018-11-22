using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.ServiciosAD
{
    public interface IAdAuthenticationService
    {
        /// <summary>
        /// Check if username and password matches existing account in AD. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        AuthenticationResult SignIn(String username, String password);
    }
}
