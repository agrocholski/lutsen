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
            Events = new List<AzureResourceEventData>();
            MetricDefinitions = new List<AzureResourceMetricDefinition>();
            Metrics = new List<AzureResourceMetric>();
            UsageMetrics = new List<AzureResourceUsageMetric>();
        }

        public AzureResource(Resource resource, string subscriptionId, string resourceGroupName)
            : this()
        {
            Id = resource.Id;
            Name = resource.Name;
            Type = resource.Type;
            Uri = string.Format("subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}", subscriptionId, resourceGroupName, resource.Type, resource.Name);
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public List<AzureResourceEventData> Events { get; set; }
        public List<AzureResourceMetricDefinition> MetricDefinitions { get; set; }
        public List<AzureResourceMetric> Metrics { get; set; }
        public List<AzureResourceUsageMetric> UsageMetrics { get; set; }

    }
}
