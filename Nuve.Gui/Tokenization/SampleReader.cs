using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Nuve.Gui.Tokenization
{
    internal class SampleReader
    {
        private const string SegmentedCorpusDirPath = @"C:\Users\hrzafer\Dropbox\nuve\corpus\tinyCorpusSegmented\";
        private const string RawCorpusDirPath = @"C:\Users\hrzafer\Dropbox\nuve\corpus\tinyCorpusRaw\";

        private static IEnumerable<XElement> ReadParaghraps(string xmlpath)
        {
            XDocument xdoc = XDocument.Load(xmlpath);
            IEnumerable<XElement> sentences = from pElement in xdoc.Descendants("p")
                select pElement;

            foreach (XElement element in sentences)
            {
                IEnumerable<string> ses = element.Descendants("s").Select(s => s.Value);
                string p = "";
                foreach (string s in ses)
                {
                    p += s + "#" + " ";
                }
                Console.WriteLine(p.Trim() + "\n");
            }

            return sentences.ToList();
        }


        public static void deneme()
        {
            string[] files = Directory.GetFiles(SegmentedCorpusDirPath, "*.xml");
            foreach (string file in files)
            {
                ReadParaghraps(file);
            }
            //var query = from file
            //    in Directory.GetFiles(SegmentedCorpusDirPath, "*.xml")
            //    select ReadParaghraps(file);

            ////IList<string> ses = new List<string>();
            ////foreach (IEnumerable<string> sentencesInPar in query)
            ////{
            ////    foreach (string sentence in sentencesInPar)
            ////    {
            ////        if (sentence.Equals("Daha ne kadar dibe batacağız"))
            ////        {
            ////            ;
            ////        }
            ////        if (!sentencesInPar.Last().Equals(sentence))
            ////        {
            ////            ses.AddSequence(sentence);
            ////            Console.WriteLine(sentence);
            ////        }
            ////    }
            ////}

            //foreach (var par in query)
            //{

            //    var ses = from element in par.Descendants("s") select element;
            //    var ses2 = par.Select(s => s.Value);

            //    string p = "";
            //    foreach (string s in ses2)
            //    {
            //        p += s + "#" + " ";
            //    }
            //    Console.WriteLine(p.Trim() + "\n");

            //}


            //var sentences = query.SelectMany(x => x);

            //var chars = sentences.GroupBy(s => s.Last()).Select(grp => grp.First().Last());
            //foreach (char c in chars)
            //{
            //    Console.WriteLine(c);
            //}
        }
    }
}