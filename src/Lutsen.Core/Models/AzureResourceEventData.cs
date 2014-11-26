using Microsoft.Azure.Insights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Core.Models
{
    public class AzureResourceEventData
    {
        public AzureResourceEventData() { }

        public AzureResourceEventData(EventData data)
        {
            Description = data.Description;
            EventName = data.EventName.Value;
            EventSource = data.EventSource.Value;
            EventTimeStamp = data.EventTimestamp;
            Level = data.Level.ToString();
            OperationId = data.OperationId;
            OperationName = data.OperationName.Value;

            Properties = new Dictionary<string, string>();
            foreach (var prop in data.Properties)
                Properties.Add(prop.Key, prop.Value);

            ResourceUri = data.ResourceUri;
            Status = data.Status.Value;
            SubmissionTimeStamp = data.SubmissionTimestamp;
            SubscritpionId = data.SubscriptionId;
            SubStatus = data.SubStatus.Value;
        }

        public string Description { get; set; }
        public string EventName { get; set; }
        public string EventSource { get; set; }
        public DateTime EventTimeStamp { get; set; }
        public string Level { get; set; }
        public string OperationId { get; set; }
        public string OperationName { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public string ResourceUri { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionTimeStamp { get; set; }
        public string SubscritpionId { get; set; }
        public string SubStatus { get; set; }

    }
}
