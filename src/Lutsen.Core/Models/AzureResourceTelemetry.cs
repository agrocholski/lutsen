using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Core.Models
{
    public class AzureResourceTelemetry
    {
        public AzureResourceTelemetry()
        {
            Events = new List<AzureResourceEventData>();
            MetricDefinitions = new List<AzureResourceMetricDefinition>();
            Metrics = new List<AzureResourceMetric>();
            UsageMetrics = new List<AzureResourceUsageMetric>();
        }

        public List<AzureResourceEventData> Events { get; set; }
        public List<AzureResourceMetricDefinition> MetricDefinitions { get; set; }
        public List<AzureResourceMetric> Metrics { get; set; }
        public List<AzureResourceUsageMetric> UsageMetrics { get; set; }
    }
}
