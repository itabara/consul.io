using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microphone.Core;
using Microphone.Core.ClusterProviders;

namespace StandAloneClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Cluster.BootstrapClient(new ConsulProvider(false));

            var instance = Cluster.FindServiceInstanceAsync("customers");            
            Console.WriteLine("Found Address:{0} Port:{1} Status:{2}", instance.Result.Address, instance.Result.Port, instance.Status);

            while (true)
            {               
                var res = Cluster.FindServiceInstancesAsync("customers");
                foreach(ServiceInformation serviceInstance in res.Result)
                {                    
                    Console.WriteLine("Found Address:{0} Port:{1}", serviceInstance.Address, serviceInstance.Port);
                }
                Console.ReadLine();                
            }
        }
    }
}
