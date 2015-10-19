using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Nuve.Lang;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Properties;

namespace Nuve.Reader
{
    public class LanguageReader
    {
        private const string Delimiter = "\t";

        public const string DefaultTableName = "sheet";
        private readonly string _dirPath;
        private readonly bool _external;
        private readonly string _seperator;
        private Orthography _orthography;

        public LanguageReader(string dirPath)
        {
            _dirPath = dirPath;
            _external = true;
            _seperator = "/";
        }

        internal LanguageReader(string langCode, bool external)
        {
            _dirPath = langCode;
            _external = external;
            _seperator = external ? "/" : ".";
        }

        public Language Read()
        {
            var sw = new Stopwatch();
            sw.Start();

            _orthography = ReadOrthography();
            Debug.Print($"orthograpy: {sw.ElapsedMilliseconds} ms");
            sw.Restart();

            Morphotactics morphotactics = ReadMorphotactics();
            Debug.Print($"morphotactics: {sw.ElapsedMilliseconds} ms");
            sw.Restart();

            MorphemeSurfaceDictionary<Root> roots = ReadRoots();
            Debug.Print($"roots: {sw.ElapsedMilliseconds} ms");
            sw.Restart();

            Suffixes suffixes = ReadSuffixes();
            Debug.Print($"suffixes: {sw.ElapsedMilliseconds} ms");
            sw.Restart();


            int index = _dirPath.LastIndexOf("\\", StringComparison.Ordinal);

            string langCode = index > -1 ? _dirPath.Substring(index + 1) : _dirPath;

            return new Language(langCode, morphotactics, roots, suffixes);
        }

        private Orthography ReadOrthography()
        {
            try
            {
                string path = _dirPath + _seperator + Resources.OrthographyFileName;

                var xml = new XmlDocument();
                XmlReader reader = GetXmlReader(path);
                xml.Load(reader);

                return OrthographyReader.Read(xml);
            }

            catch (Exception ex)
            {
                throw new InvalidLanguageFileException(ex, Type.Orthograpy, "Invalid language file for orthograpy: ");
            }
        }

        private Morphotactics ReadMorphotactics()
        {
            try
            {
                string path = _dirPath + _seperator + Resources.MorphotacticsFileName;

                if (_external)
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        return MorphotacticsReader.Read(stream, _orthography.Alphabet);
                    }
                }

                Stream xml = EmbeddedResourceReader.Read(path);
                return MorphotacticsReader.Read(xml, _orthography.Alphabet);
            }
            catch (Exception ex)
            {
                throw new InvalidLanguageFileException(ex, Type.Morphotactics,
                    "Invalid language file for Morphotactics: ");
            }
        }

        private MorphemeSurfaceDictionary<Root> ReadRoots()
        {
            try
            {
                var roots = new MorphemeSurfaceDictionary<Root>();
                var reader = new RootLexiconReader(_orthography);


                string rootsPath = _dirPath + _seperator + Resources.InternalMainRootsPath;


                if (_external)
                {
                    using (var stream = new FileStream(rootsPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        reader.AddEntries(TextToDataSet.Convert(stream, DefaultTableName, Delimiter), DefaultTableName,
                            roots);
                    }

                    return roots;
                }


                reader.AddEntries(EmbeddedTextResourceToDataSet(rootsPath), DefaultTableName, roots);


                string namesPath = _dirPath + _seperator + Resources.InternalPersonNamesPath;
                reader.AddEntries(EmbeddedTextResourceToDataSet(namesPath), DefaultTableName, roots);

                string abbreviationPath = _dirPath + _seperator + Resources.InternalAbbreviationsPath;
                reader.AddEntries(EmbeddedTextResourceToDataSet(abbreviationPath), DefaultTableName, roots);

                return roots;
            }
            catch (Exception ex)
            {
                throw new InvalidLanguageFileException(ex, Type.Roots, "Invalid language file for roots: ");
            }
        }

        private Suffixes ReadSuffixes()
        {
            try
            {
                Dictionary<string, Suffix> suffixesById;
                MorphemeSurfaceDictionary<Suffix> suffixesBySurface;

                string path = _dirPath + _seperator + Resources.InternalSuffixesPath;
                var reader = new SuffixLexiconReader(_orthography);

                if (_external)
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        reader.Read(TextToDataSet.Convert(stream, DefaultTableName, Delimiter), DefaultTableName,
                            out suffixesById, out suffixesBySurface);
                    }

                    return new Suffixes(suffixesById, suffixesBySurface);
                }

                DataSet dataSet = EmbeddedTextResourceToDataSet(path);

                reader.Read(dataSet, DefaultTableName, out suffixesById, out suffixesBySurface);

                return new Suffixes(suffixesById, suffixesBySurface);
            }
            catch (Exception ex)
            {
                throw new InvalidLanguageFileException(ex, Type.Suffixes, "Invalid language file for suffixes: ");
            }
        }


        private DataSet EmbeddedTextResourceToDataSet(string path)
        {
            Stream textStream = EmbeddedResourceReader.Read(path);
            return TextToDataSet.Convert(textStream, DefaultTableName, Delimiter);
        }


        private XmlReader GetXmlReader(string path)
        {
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.DTD,
                DtdProcessing = DtdProcessing.Parse,
            };
            settings.ValidationEventHandler += OnValidationEvent;

            XmlReader reader;
            if (!_external)
            {
                settings.XmlResolver = new EmbeddedXmlResolver();
                Stream stream = EmbeddedResourceReader.Read(path);
                reader = XmlReader.Create(stream, settings);
            }

            else
            {
                var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                settings.XmlResolver = new ExternalDtdUrlResolver(path);
                reader = XmlReader.Create(stream, settings);
            }

            return reader;
        }

        private void OnValidationEvent(Object o, ValidationEventArgs args)
        {
            throw new XmlException("Invalid Orthography XML: " + args.Message, args.Exception);
        }
    }
}