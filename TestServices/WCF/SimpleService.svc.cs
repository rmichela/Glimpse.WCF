using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;

namespace TestSite.WCF
{
    public class SimpleService : ISimpleService
    {
        public int DoWork()
        {
            var r = new Random();
            var v = Enumerable.Range(1, 10000).Select(x => r.Next()).ToArray();
            var s = JsonConvert.SerializeObject(v);
            var a = JsonConvert.DeserializeObject<int[]>(s);

            return s.Length + a[0];
        }
    }
}
