using System.ServiceModel;
using System.Threading.Tasks;

namespace TestSite.WCF
{
    [ServiceContract]
    public interface ICompositeService
    {
        [OperationContract]
        Task<int[]> DoWork();
    }
}
