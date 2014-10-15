using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestSite.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var r = new Random();
            return new[] { r.Next().ToString(), r.Next().ToString(), r.Next().ToString() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            var r = new Random(id);
            return r.Next().ToString();
        }
    }
}