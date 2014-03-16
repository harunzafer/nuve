using System;
using System.Net;
using System.Reflection;
using System.Xml;

namespace Nuve.Reader
{
    class MyXmlResolver : XmlResolver 
    {
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            var fileName = absoluteUri.Segments[absoluteUri.Segments.Length - 1];
            var resourceName = "Nuve.Resources." + fileName;
            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            return resourceStream;
        }

        public override ICredentials Credentials
        {
            set { throw new NotImplementedException(); }
        }
    }
}
