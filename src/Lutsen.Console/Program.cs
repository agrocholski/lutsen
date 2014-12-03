using Lutsen.Core.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /* In order to run this sample application you must have an Azure Active Directory (AAD) tenant,
             * and you must configure an application within the AAD tenant. For instructions on how to do so,
             * please read the following article: http://msdn.microsoft.com/en-us/library/azure/dn790557.aspx
             * */

            System.Console.Write("Enter your AAD tenant id: ");
            var tenantId = System.Console.ReadLine();

            System.Console.Write("Enter your AAD application id: ");
            var appId = System.Console.ReadLine();

            System.Console.Write("Enter your AAD application redirect Uri: ");
            var appRedirectUri = System.Console.ReadLine();

            var authToken = AuthorizationManager.GetAuthorizationToken(tenantId, appId, appRedirectUri);

            var subscriptions = SubscriptionManager.GetSubscriptions(authToken);

            foreach(var subscription in subscriptions)
            {


                //todo: make magic happen
            }

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadLine();
        }
    }
}
