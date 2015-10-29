using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microphone.Core;
using Microphone.Core.ClusterProviders;
using Microphone.WebApi;
using System.Web.Http;

namespace HelloMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Cluster.Bootstrap(new WebApiProvider(), new ConsulProvider(), "customers", "v1");
            Console.ReadLine();
        }
    }

    public class CustomerController : ApiController
    {
        public Customer Get()
        {
            return new Customer
            {
                CustomerID = 123,
                FirstName = "John",
                LastName = "Doe"
            };
        }

        [Route("status")]
        public string GetStatus()
        {
            Logger.Information("OK");
            return "ok";
        }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
    }
}
