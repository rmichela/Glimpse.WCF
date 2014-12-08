using System;
using System.Threading;

namespace TestSite.WCF
{
    public class SimpleService : ISimpleService
    {
        public int DoWork()
        {
            var r = new Random();
            return r.Next();
        }
    }
}
