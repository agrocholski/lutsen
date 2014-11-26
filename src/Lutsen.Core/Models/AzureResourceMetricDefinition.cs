using Microsoft.Azure.Insights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Core.Models
{
    public class AzureResourceMetricDefinition
    {
        public AzureResourceMetricDefinition() { }

        public AzureResourceMetricDefinition(MetricDefinition metricDefinition)
        {
            MetricAvailabilities = new List<MetricAvailability>();
            MetricAvailabilities.AddRange(metricDefinition.MetricAvailabilities);

            Name = metricDefinition.Name.Value;
            PrimaryAggregationType = metricDefinition.PrimaryAggregationType.ToString();

            Properties = new Dictionary<string, string>();
            foreach (var prop in metricDefinition.Properties)
                Properties.Add(prop.Key, prop.Value);

            ResourceUri = metricDefinition.ResourceUri;
            Unit = metricDefinition.Unit.ToString();
        }

        public List<MetricAvailability> MetricAvailabilities { get; set; }
        public string Name { get; set; }
        public string PrimaryAggregationType { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public string ResourceUri { get; set; }
        public string Unit { get; set; }
    }
}
