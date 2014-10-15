using System;
using System.Threading;

namespace TestSite.WCF
{
    public class SimpleService : ISimpleService
    {
        public int DoWork()
        {
            var r = new Random();
            Thread.Sleep(r.Next(2000));
            return r.Next();
        }
    }
}
