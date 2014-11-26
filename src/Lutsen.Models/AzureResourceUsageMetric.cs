using Microsoft.Azure.Insights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Models
{
    public class AzureResourceUsageMetric
    {
        public AzureResourceUsageMetric() { }

        public AzureResourceUsageMetric(UsageMetric metric)
        {
            CurrentValue = metric.CurrentValue;
            Limit = metric.Limit;
            Name = metric.Name.Value;
            NextResetTime = metric.NextResetTime;
            QuotaPeriod = metric.QuotaPeriod;
            Unit = metric.Unit;
        }

        public double CurrentValue { get; set; }
        public double Limit { get; set; }
        public string Name { get; set; }
        public string NextResetTime { get; set; }
        public TimeSpan? QuotaPeriod { get; set; }
        public string Unit { get; set; }
    }
}
