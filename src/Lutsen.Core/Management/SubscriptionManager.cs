using Lutsen.Core.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Core.Management
{
    public class SubscriptionManager
    {
        public static List<AzureSubscription> GetSubscriptions(string token)
        {
            var credentials = CredentialManager.GetCredentials(token);

            return GetSubscriptions(credentials);
        }

        public static List<AzureSubscription> GetSubscriptions(SubscriptionCloudCredentials credentials)
        {
            var result = new List<AzureSubscription>();

            SubscriptionClient client = new SubscriptionClient(credentials);

            var subscriptions = client.Subscriptions.List();

            foreach (var subscription in subscriptions)
            {
                result.Add(new AzureSubscription(subscription));
            }

            return result;
        }
    }
}
