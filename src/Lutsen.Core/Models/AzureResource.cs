using Microsoft.Azure.Management.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Core.Models
{
    public class AzureResource
    {
        public AzureResource()
        {
            Telemetry = new AzureResourceTelemetry();
        }

        public AzureResource(Resource resource, string subscriptionId, string resourceGroupName)
            : this()
        {
            Id = resource.Id;
            Name = resource.Name;
            Type = resource.Type;
            SubscriptionId = subscriptionId;
            Uri = string.Format("subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}", subscriptionId, resourceGroupName, resource.Type, resource.Name);
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string SubscriptionId { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public AzureResourceTelemetry Telemetry { get; set; }

    }
}
