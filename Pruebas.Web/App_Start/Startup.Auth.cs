using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace Pruebas.Web
{
    public partial class Startup
    {
        public static class PruebasAuthentication
        {
            public const String ApplicationCookie = "PruebasAuthenticationType";
        }

        // Para obtener más información para configurar la autenticación, visite http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configurar cookie de inicio de sesión
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = PruebasAuthentication.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider(),
                CookieName = "PruebasCookie",
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromHours(12)
            });
        }
    }
}