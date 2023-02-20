using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;

namespace Nuve.Reader
{
    internal class EmbeddedXmlResolver : XmlResolver
    {
        public override ICredentials Credentials
        {
            set { throw new NotImplementedException(); }
        }

        public override object GetEntity(Uri absoluteUri, string role, System.Type ofObjectToReturn)
        {
            string fileName = absoluteUri.Segments[absoluteUri.Segments.Length - 1];
            string resourceName = "Nuve.Resources." + fileName;
            Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            return resourceStream;
        }
    }
}