using System;
using System.Threading;
using System.Threading.Tasks;
using TestSite.SimpleService;

namespace TestSite.WCF
{
    public class CompositeService : ICompositeService
    {
        public async Task<int[]> DoWork()
        {
            using (var client = new SimpleServiceClient())
            {
                return (new int[]
                    {
                        await client.DoWorkAsync(),
                        await client.DoWorkAsync(),
                        await client.DoWorkAsync()
                    });
            }
        }
    }
}
