using System.Collections.Generic;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;

namespace Glimpse.WCF.Extensibility
{
    public static class GlimpseWcfConfigShim
    {
        public static void Register()
        {
            if (GlimpseConfiguration.GetConfiguredMessageBroker() == null)
            {
                // initialize a fake config
                var config = new GlimpseConfiguration(null, null, null, new NullLogger(), RuntimePolicy.On, null, null, null, null,
                                                      null, null, null, null, null, null, new GlimpseWcfMessageBroker(),
                                                      null, () => GlimpseWcfContext.Current.SessionTimer, null);
            }
        }

        private class ShimServiceLocator : IServiceLocator
        {
            public T GetInstance<T>() where T : class
            {
                if (typeof (T) == typeof (IMessageBroker))
                {
                    return new GlimpseWcfMessageBroker() as T;
                }
                return null;
            }

            public ICollection<T> GetAllInstances<T>() where T : class
            {
                return new List<T> {GetInstance<T>()};
            }
        }
    }
}
