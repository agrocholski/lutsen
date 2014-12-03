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
        public static List<AzureResourceEventData> GetEventData(string token, AzureResource resource, DateTime startTime, DateTime endTime)
        {
            var result = new List<AzureResourceEventData>();

            string filterString = FilterString.Generate<ListEventsForResourceParameters>(eventData => (eventData.EventTimestamp >= startTime) && (eventData.EventTimestamp <= endTime) && (eventData.ResourceUri == resource.Uri));

            var credentials = CredentialManager.GetCredentials(token, resource.SubscriptionId);
            InsightsClient client = new InsightsClient(credentials);

            EventDataListResponse response = client.EventOperations.ListEvents(filterString, selectedProperties: null);

            foreach (var eventEntry in response.EventDataCollection.Value)
            {
                result.Add(new AzureResourceEventData(eventEntry));
            }

            return result;
        }

        public static List<AzureResourceMetricDefinition> GetMetricDefinitions(string token, AzureResource resource)
        {
            var result = new List<AzureResourceMetricDefinition>();

            var credentials = CredentialManager.GetCredentials(token, resource.SubscriptionId);
            InsightsClient client = new InsightsClient(credentials);

            var metricDefinitions = client.MetricDefinitionOperations.GetMetricDefinitionsAsync(resource.Uri, "").Result;

            foreach (var metricDefinition in metricDefinitions.MetricDefinitionCollection.Value)
            {
                result.Add(new AzureResourceMetricDefinition(metricDefinition));
            }

            return result;
        }
    }
}
