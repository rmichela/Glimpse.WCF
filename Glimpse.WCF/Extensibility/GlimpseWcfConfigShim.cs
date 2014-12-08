using System.Collections.Generic;
using System.Collections.ObjectModel;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;
using Glimpse.WCF.Extensibility.Fakes;

namespace Glimpse.WCF.Extensibility
{
    internal static class GlimpseWcfConfigShim
    {
        public static void Register()
        {
            if (GlimpseConfiguration.GetConfiguredMessageBroker() == null)
            {
                // initialize a fake config
                var config = new GlimpseConfiguration(
                    new FakeFrameworkProvider(), 
                    new FakeResourceEndpointConfiguration(), 
                    new Collection<IClientScript>(), 
                    new FakeLogger(), 
                    RuntimePolicy.On, 
                    new FakeHtmlEncoder(), 
                    new FakePersistenceStore(), 
                    new Collection<IInspector>(), 
                    new Collection<IResource>(), 
                    new FakeSerializer(), 
                    new Collection<ITab>(), 
                    new Collection<IDisplay>(), 
                    new Collection<IRuntimePolicy>(), 
                    new FakeResource(), 
                    new FakeProxyFactory(), 
                    new GlimpseWcfMessageBroker(),
                    string.Empty, 
                    GetSessionTimer, 
                    () => RuntimePolicy.On);
            }
        }

        public static IExecutionTimer GetSessionTimer()
        {
            if (GlimpseConfiguration.GetLogger() is FakeLogger)
            {
                return GlimpseWcfContext.Current.SessionTimer;
            }
            return GlimpseConfiguration.GetConfiguredTimerStrategy()();
        }

        public static IMessageBroker GetBroker()
        {
            if (GlimpseConfiguration.GetLogger() is FakeLogger)
            {
                return new GlimpseWcfMessageBroker();
            }
            return GlimpseConfiguration.GetConfiguredMessageBroker();
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
