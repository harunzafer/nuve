using System;
using System.IO;
using System.Reflection;

namespace Nuve.Reader
{
    /// <summary>
    ///     Nuve.Resources klasörünün altındaki dosyaları okur.
    /// </summary>
    internal static class EmbeddedResourceReader
    {
        private const string AssemblyFolder = "nuve.Resources";
        private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

        public static Stream Read(string filename)
        {
            Stream stream;
            try
            {
                stream = Assembly.GetManifestResourceStream($"{AssemblyFolder}.{filename}");
            }
            catch (Exception e)
            {
                throw new Exception("Xml dosyası bulunamadı: " + filename);
            }
            if (stream == null)
            {
                throw new Exception("Xml dosyası bulunamadı: " + filename);
            }
            return stream;
        }
    }
}