using System;
using System.Xml;

namespace Nuve.Reader
{
    internal class ExternalDtdUrlResolver : XmlUrlResolver
    {
        private readonly string _path;

        public ExternalDtdUrlResolver(string path)
        {
            _path = path;
        }


        public override Uri ResolveUri(Uri baseUri, string relativeUri)
        {
            if (baseUri != null)
                return base.ResolveUri(baseUri, relativeUri);

            return base.ResolveUri(new Uri(_path), relativeUri);
        }
    }
}