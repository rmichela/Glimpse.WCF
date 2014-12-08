using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Framework;

namespace Glimpse.WCF.Extensibility.Fakes
{
    class FakePersistenceStore : IPersistenceStore
    {
        public GlimpseRequest GetByRequestId(Guid requestId)
        {
            throw new NotImplementedException();
        }

        public TabResult GetByRequestIdAndTabKey(Guid requestId, string tabKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GlimpseRequest> GetByRequestParentId(Guid parentRequestId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GlimpseRequest> GetTop(int count)
        {
            throw new NotImplementedException();
        }

        public GlimpseMetadata GetMetadata()
        {
            throw new NotImplementedException();
        }

        public void Save(GlimpseRequest request)
        {
            throw new NotImplementedException();
        }

        public void Save(GlimpseMetadata metadata)
        {
            throw new NotImplementedException();
        }
    }
}
