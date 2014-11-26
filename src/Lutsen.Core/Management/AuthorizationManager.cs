using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lutsen.Core.Management
{
    public class AuthorizationManager
    {
        public static string GetAuthorizationToken(string tenantId, string clientId, string redirectUri)
        {
            AuthenticationResult result = null;

            var context = new AuthenticationContext(string.Format("https://login.windows.net/{0}", tenantId));

            var thread = new Thread(() =>
            {
                result = context.AcquireToken(
                  "https://management.core.windows.net/",
                  clientId,
                  new Uri(redirectUri));
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Name = "AquireTokenThread";
            thread.Start();
            thread.Join();

            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }

            string token = result.AccessToken;

            return token;
        }
    }
}
