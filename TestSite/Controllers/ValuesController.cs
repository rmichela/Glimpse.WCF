using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http;

namespace TestSite.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var r = new Random();
            Thread.Sleep(r.Next(3000));
            return new[] { r.Next().ToString(), r.Next().ToString(), r.Next().ToString() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            var r = new Random(id);
            Thread.Sleep(r.Next(3000));
            return r.Next().ToString();
        }
    }
}