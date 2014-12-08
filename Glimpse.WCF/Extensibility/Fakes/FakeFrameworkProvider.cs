using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;

namespace Glimpse.WCF.Extensibility.Fakes
{
    class FakeFrameworkProvider : IFrameworkProvider
    {
        public void SetHttpResponseHeader(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void SetHttpResponseStatusCode(int statusCode)
        {
            throw new NotImplementedException();
        }

        public void SetCookie(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void InjectHttpResponseBody(string htmlSnippet)
        {
            throw new NotImplementedException();
        }

        public void WriteHttpResponse(byte[] content)
        {
            throw new NotImplementedException();
        }

        public void WriteHttpResponse(string content)
        {
            throw new NotImplementedException();
        }

        public IDataStore HttpRequestStore { get; private set; }
        public IDataStore HttpServerStore { get; private set; }
        public object RuntimeContext { get; private set; }
        public IRequestMetadata RequestMetadata { get; private set; }
    }
}
