using Lutsen.Core.Models;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Common.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Core.Management
{
    public class TelemetryManager
    {
        public static List<AzureResourceEventData> GetEventData(string token, string subscriptionId, string resourceUri, DateTime startTime, DateTime endTime)
        {
            var result = new List<AzureResourceEventData>();

            string filterString = FilterString.Generate<ListEventsForResourceParameters>(eventData => (eventData.EventTimestamp >= startTime) && (eventData.EventTimestamp <= endTime) && (eventData.ResourceUri == resourceUri));

            var credentials = CredentialManager.GetCredentials(token, subscriptionId);
            InsightsClient client = new InsightsClient(credentials);

            EventDataListResponse response = client.EventOperations.ListEvents(filterString, selectedProperties: null);

            foreach (var eventEntry in response.EventDataCollection.Value)
            {
                result.Add(new AzureResourceEventData(eventEntry));
            }

            return result;
        }

        public static List<AzureResourceMetricDefinition> GetMetricDefinitions(string token, string subscriptionId, string resourceUri)
        {
            var result = new List<AzureResourceMetricDefinition>();

            var credentials = CredentialManager.GetCredentials(token, subscriptionId);
            InsightsClient client = new InsightsClient(credentials);

            var metricDefinitions = client.MetricDefinitionOperations.GetMetricDefinitionsAsync(resourceUri, "").Result;

            foreach (var metricDefinition in metricDefinitions.MetricDefinitionCollection.Value)
            {
                result.Add(new AzureResourceMetricDefinition(metricDefinition));
            }

            return result;
        }

        public static List<AzureResourceMetric> GetMetrics(string token, string subscriptionId, string resourceUri, string filter)
        {
            var result = new List<AzureResourceMetric>();

            var credentials = CredentialManager.GetCredentials(token, subscriptionId);
            InsightsClient client = new InsightsClient(credentials);

            var metrics = client.MetricOperations.GetMetrics(resourceUri, filter);

            foreach (var metric in metrics.MetricCollection.Value)
                result.Add(new AzureResourceMetric(metric));

            return result;
        }
    }
}
