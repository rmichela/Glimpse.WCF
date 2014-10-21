using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using TestSite.SimpleService;

namespace TestSite.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            using (var client = new SimpleServiceClient())
            {
                return new[] { client.DoWork().ToString() };
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            using (var client = new SimpleServiceClient())
            {
                return client.DoWork().ToString();
            }
        }
    }
}