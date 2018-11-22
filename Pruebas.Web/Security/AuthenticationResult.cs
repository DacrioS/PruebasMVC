using System;

namespace Pruebas.Web.Security
{
    public class AuthenticationResult
    {
        public AuthenticationResult(string errorMessage = null)
        {
            ErrorMessage = errorMessage;
        }

        public String ErrorMessage { get; private set; }
        public Boolean IsSuccess => String.IsNullOrEmpty(ErrorMessage);
    }
}