using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;

namespace Glimpse.WCF.Extensibility.Fakes
{
    class FakeResource : IResource
    {
        public IResourceResult Execute(IResourceContext context)
        {
            throw new NotImplementedException();
        }

        public string Name { get; private set; }
        public IEnumerable<ResourceParameterMetadata> Parameters { get; private set; }
    }
}
