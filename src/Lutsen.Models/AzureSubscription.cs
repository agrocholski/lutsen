using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Models
{
    public class AzureSubscription
    {
        public AzureSubscription()
        {
            ResourceGroups = new List<AzureResourceGroup>();
        }

        public AzureSubscription(Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse.Subscription subscription)
            : this()
        {
            AccountAdminLiveEmailId = subscription.AccountAdminLiveEmailId;
            ActiveDirectoryTenantId = subscription.ActiveDirectoryTenantId;
            Created = subscription.Created;
            CurrentCoreCount = subscription.CurrentCoreCount;
            CurrentHostedServices = subscription.CurrentHostedServices;
            CurrentStorageAccounts = subscription.CurrentStorageAccounts;
            MaximumCoreCount = subscription.MaximumCoreCount;
            MaximumDnsServers = subscription.MaximumDnsServers;
            MaximumExtraVirtualIPCount = subscription.MaximumExtraVirtualIPCount;
            MaximumHostedServices = subscription.MaximumHostedServices;
            MaximumStorageAccounts = subscription.MaximumStorageAccounts;
            MaximumVirtualNetworkSites = subscription.MaximumVirtualNetworkSites;
            ServiceAdminLiveEmailId = subscription.ServiceAdminLiveEmailId;
            Name = subscription.SubscriptionName;
            Status = subscription.SubscriptionStatus.ToString();
            Id = subscription.SubscriptionId;
        }

        public string AccountAdminLiveEmailId { get; set; }
        public string ActiveDirectoryTenantId { get; set; }
        public DateTime Created { get; set; }
        public int CurrentCoreCount { get; set; }
        public int CurrentHostedServices { get; set; }
        public int CurrentStorageAccounts { get; set; }
        public int MaximumCoreCount { get; set; }
        public int MaximumDnsServers { get; set; }
        public int MaximumExtraVirtualIPCount { get; set; }
        public int MaximumHostedServices { get; set; }
        public int MaximumStorageAccounts { get; set; }
        public int MaximumVirtualNetworkSites { get; set; }
        public string ServiceAdminLiveEmailId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public List<AzureResourceGroup> ResourceGroups { get; set; }
    }
}
