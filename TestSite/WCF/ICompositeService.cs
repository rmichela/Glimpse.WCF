using System.ServiceModel;

namespace TestSite.WCF
{
    [ServiceContract]
    public interface ICompositeService
    {
        [OperationContract]
        int[] DoWork();
    }
}
