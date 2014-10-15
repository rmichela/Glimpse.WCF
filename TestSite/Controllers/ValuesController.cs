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
            var r = new Random();
            Thread.Sleep(r.Next(2000));

            using (var client = new SimpleServiceClient())
            {
                return new[] { client.DoWork().ToString() };
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            var r = new Random(id);
            Thread.Sleep(r.Next(2000));
            using (var client = new SimpleServiceClient())
            {
                return client.DoWork().ToString();
            }
        }
    }
}