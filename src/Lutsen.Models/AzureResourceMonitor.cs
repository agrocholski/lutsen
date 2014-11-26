using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutsen.Models
{
    public class AzureResourceMonitor
    {
        public AzureResourceMonitor()
        {
            Subscriptions = new List<AzureSubscription>();
        }

        public List<AzureSubscription> Subscriptions { get; set; }
    }
}
