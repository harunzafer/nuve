using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace Nuve.Reader
{
    class ExternalDtdUrlResolver : XmlUrlResolver
    {

        private readonly string _path;

        public ExternalDtdUrlResolver(string path)
        {
            this._path = path;
        }


        public override Uri ResolveUri(Uri baseUri, string relativeUri)
        {
            if (baseUri != null)
                return base.ResolveUri(baseUri, relativeUri);
            
            return base.ResolveUri(new Uri(_path), relativeUri);
        }
    }
}
