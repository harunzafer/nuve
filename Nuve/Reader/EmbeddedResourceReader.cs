using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Nuve.Reader
{
    /// <summary>
    /// Nuve.Resources klasörünün altındaki dosyaları okur.
    /// </summary>
    static class EmbeddedResourceReader
    {
        private const string AssemblyFolder = "Nuve.Resources.";
        private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

        public static Stream Read(string filename)
        {
            Stream stream = null;
            try
            {
                stream = Assembly.GetManifestResourceStream(AssemblyFolder + filename);
            }
            catch (Exception)
            {
                throw new Exception("Xml dosyası bulunamadı: " + filename);
            }
            if (stream == null)
            {
                throw new Exception("Xml dosyası bulunamadı: " + filename);
            }
            return stream;
        }

        public static XmlDocument ReadXml(string filename)
        {
            Stream stream = Read(filename);
            var doc = new XmlDocument {XmlResolver = new MyXmlResolver()};
            doc.Load(stream);
            return doc;
        }


    }
}
