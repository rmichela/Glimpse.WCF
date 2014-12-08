using System.Threading.Tasks;
using GlimpseServices.SimpleService;

namespace TestSite.WCF
{
    public class CompositeService : ICompositeService
    {
        public int[] DoWork()
        {
            using (var client = new SimpleServiceClient())
            {
                return (new int[]
                    {
                        client.DoWork(),
                        client.DoWork(),
                        client.DoWork()
                    });
            }
        }

        public async Task<int[]> DoWorkParallel()
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
