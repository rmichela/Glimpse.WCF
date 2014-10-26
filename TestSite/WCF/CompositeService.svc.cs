using System;
using System.Threading;
using TestSite.SimpleService;

namespace TestSite.WCF
{
    public class CompositeService : ICompositeService
    {
        public int[] DoWork()
        {
            using (var client = new SimpleServiceClient())
            {
                return new int[]
                    {
                        client.DoWork(),
                        client.DoWork(),
                        client.DoWork()
                    };
            }
        }
    }
}
