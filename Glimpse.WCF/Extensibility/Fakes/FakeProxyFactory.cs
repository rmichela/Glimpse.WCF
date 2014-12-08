using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;

namespace Glimpse.WCF.Extensibility.Fakes
{
    class FakeProxyFactory : IProxyFactory
    {
        public bool IsWrapInterfaceEligible<TToWrap>(Type type)
        {
            throw new NotImplementedException();
        }

        public T WrapInterface<T>(T instance, IEnumerable<IAlternateMethod> methodImplementations) where T : class
        {
            throw new NotImplementedException();
        }

        public T WrapInterface<T>(T instance, IEnumerable<IAlternateMethod> methodImplementations, IEnumerable<object> mixins) where T : class
        {
            throw new NotImplementedException();
        }

        public bool IsWrapClassEligible(Type type)
        {
            throw new NotImplementedException();
        }

        public T WrapClass<T>(T instance, IEnumerable<IAlternateMethod> methodImplementations) where T : class
        {
            throw new NotImplementedException();
        }

        public T WrapClass<T>(T instance, IEnumerable<IAlternateMethod> methodImplementations, IEnumerable<object> mixins) where T : class
        {
            throw new NotImplementedException();
        }

        public T WrapClass<T>(T instance, IEnumerable<IAlternateMethod> methodImplementations, IEnumerable<object> mixins, IEnumerable<object> constructorArguments) where T : class
        {
            throw new NotImplementedException();
        }

        public bool IsExtendClassEligible(Type type)
        {
            throw new NotImplementedException();
        }

        public T ExtendClass<T>(IEnumerable<IAlternateMethod> methodImplementations) where T : class
        {
            throw new NotImplementedException();
        }

        public T ExtendClass<T>(IEnumerable<IAlternateMethod> methodImplementations, IEnumerable<object> mixins) where T : class
        {
            throw new NotImplementedException();
        }

        public T ExtendClass<T>(IEnumerable<IAlternateMethod> methodImplementations, IEnumerable<object> mixins, IEnumerable<object> constructorArguments) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
