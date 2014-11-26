using Microsoft.Azure.Insights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Core.Models
{
    public class AzureResourceMetric
    {
        public AzureResourceMetric() { }

        public AzureResourceMetric(Metric metric)
        {
            EndTime = metric.EndTime;

            Values = new List<MetricValue>();
            Values.AddRange(metric.MetricValues);

            Name = metric.Name.Value;

            Properties = new Dictionary<string, string>();

            foreach (var prop in metric.Properties)
                Properties.Add(prop.Key, prop.Value);

            ResourceId = metric.ResourceId;

            StartTime = metric.StartTime;

            TimeGrain = metric.TimeGrain;

            Unit = metric.Unit.ToString();
        }

        public DateTime EndTime { get; set; }
        public List<MetricValue> Values { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public string ResourceId { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan TimeGrain { get; set; }
        public string Unit { get; set; }
    }
}
