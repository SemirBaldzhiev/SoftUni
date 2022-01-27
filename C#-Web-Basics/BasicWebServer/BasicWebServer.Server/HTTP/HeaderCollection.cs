using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{

    public class HeaderCollection : IEnumerable<Header>
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
        {
            headers = new Dictionary<string, Header>();
        }

        public string this[string name] => headers[name].Value;
        public int Count => this.headers.Count;

        public bool Contains(string name)
        {
            return headers.ContainsKey(name);
        }

        public void Add(string name, string value)
        {
            var header = new Header(name, value);
            headers.Add(name, header);
        }

        public IEnumerator<Header> GetEnumerator()
        {
            return headers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
