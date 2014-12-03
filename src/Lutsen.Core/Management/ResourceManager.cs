using Lutsen.Core.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Core.Management
{
    public class ResourceManager
    {
        public static List<AzureResourceGroup> GetResourceGroups(string token, string subscriptionId)
        {
            var credentials = CredentialManager.GetCredentials(token, subscriptionId);
            
            return GetResourceGroups(credentials);
        }

        public static List<AzureResourceGroup> GetResourceGroups(SubscriptionCloudCredentials credentials)
        {
            var result = new List<AzureResourceGroup>();

            ResourceManagementClient client = new ResourceManagementClient(credentials);

            var resourceGroupParams = new ResourceGroupListParameters();

            var groupResult = client.ResourceGroups.List(resourceGroupParams);

            foreach (var resourceGroup in groupResult.ResourceGroups)
            {
                var azureResourceGroup = new AzureResourceGroup(resourceGroup);

                var resourceParams = new ResourceListParameters();
                resourceParams.ResourceGroupName = resourceGroup.Name;

                var resourceResult = client.Resources.List(resourceParams);

                foreach (var resource in resourceResult.Resources)
                {
                    azureResourceGroup.Resources.Add(new Models.AzureResource(resource, credentials.SubscriptionId, resourceGroup.Name));
                }

                result.Add(azureResourceGroup);
            }

            return result;
        }
    }
}
