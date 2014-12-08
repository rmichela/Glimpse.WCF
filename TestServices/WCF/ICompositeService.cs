using System.ServiceModel;
using System.Threading.Tasks;

namespace TestSite.WCF
{
    [ServiceContract]
    public interface ICompositeService
    {
        [OperationContract]
        int[] DoWork();

        [OperationContract]
        Task<int[]> DoWorkParallel();
    }
}
