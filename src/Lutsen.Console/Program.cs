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
        private static string tenantId = "";
        private static string appId = "";
        private static string appRedirectUri = "";
        private static DateTime startTime = new DateTime(2014, 11, 1, 0, 0, 0);
        private static DateTime endTime = new DateTime(2014, 11, 24, 23, 59, 59);

        static void Main(string[] args)
        {
            /* In order to run this sample application you must have an Azure Active Directory (AAD) tenant,
             * and you must configure an application within the AAD tenant. For instructions on how to do so,
             * please read the following article: http://msdn.microsoft.com/en-us/library/azure/dn790557.aspx
             * */

            try
            {
                if (string.IsNullOrEmpty(tenantId))
                {
                    System.Console.Write("Enter your AAD tenant id: ");
                    tenantId = System.Console.ReadLine();
                }

                if (string.IsNullOrEmpty(appId))
                {
                    System.Console.Write("Enter your AAD application id: ");
                    appId = System.Console.ReadLine();
                }

                if (string.IsNullOrEmpty(appRedirectUri))
                {
                    System.Console.Write("Enter your AAD application redirect Uri: ");
                    appRedirectUri = System.Console.ReadLine();
                }

                var authToken = AuthorizationManager.GetAuthorizationToken(tenantId, appId, appRedirectUri);

                var subscriptions = SubscriptionManager.GetSubscriptions(authToken);

                foreach (var subscription in subscriptions)
                {
                    var resourceGroups = ResourceManager.GetResourceGroups(authToken, subscription.Id);

                    foreach (var resourceGroup in resourceGroups)
                    {
                        foreach (var resource in resourceGroup.Resources)
                        {
                            resource.Telemetry.Events = TelemetryManager.GetEventData(authToken, resource.SubscriptionId, resource.Uri, startTime, endTime);
                            resource.Telemetry.MetricDefinitions = TelemetryManager.GetMetricDefinitions(authToken, resource.SubscriptionId, resource.Uri);
                            resource.Telemetry.Metrics = TelemetryManager.GetMetrics(authToken, resource.SubscriptionId, resource.Uri, "");
                            resource.Telemetry.UsageMetrics = TelemetryManager.GetUsageMetrics(authToken, resource.SubscriptionId, resource.Uri, "");
                        }
                    }

                    subscription.ResourceGroups.AddRange(resourceGroups);
                }

                //todo: do something with the data
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadLine();
        }
    }
}
