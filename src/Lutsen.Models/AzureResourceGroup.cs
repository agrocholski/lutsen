using Microsoft.Azure.Management.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Models
{
    public class AzureResourceGroup
    {
        public AzureResourceGroup()
        {
            Resources = new List<AzureResource>();
        }

        public AzureResourceGroup(ResourceGroup resourceGroup)
            : this()
        {
            Id = resourceGroup.Id;
            Name = resourceGroup.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public List<AzureResource> Resources { get; set; }
    }
}
