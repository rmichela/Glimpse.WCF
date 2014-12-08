using System.ServiceModel;

namespace TestSite.WCF
{
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract]
        int DoWork();
    }
}
