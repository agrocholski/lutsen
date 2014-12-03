using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Core.Management
{
    public class CredentialManager
    {
        public static SubscriptionCloudCredentials GetCredentials(string token)
        {
            SubscriptionCloudCredentials credentials = new TokenCloudCredentials(token);

            return credentials;
        }

        public static SubscriptionCloudCredentials GetCredentials(string token, string subscriptionId)
        {
            SubscriptionCloudCredentials credentials = new TokenCloudCredentials(subscriptionId, token);

            return credentials;
        }
    }
}
