using BasicWebServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType,
            Action<Request, Response> preRenderAction = null) 
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            PreRenderAction = preRenderAction;
            Headers.Add(Header.ContentType, contentType);

            Body = content;
        }

        public override string ToString()
        {
            if (Body != null)
            {
                var contentLength = Encoding.UTF8.GetByteCount(Body).ToString();
                Headers.Add(Header.ContentLength, contentLength);
            }

            return base.ToString();
        }
    }
}
