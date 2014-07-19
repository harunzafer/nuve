nuve
====
Nuve is a Natural Language Processing Library for Turkish. Currently it supports morphologic analysis and generation. 
Morphologic Analysis is demonstrated here: http://nuvedemo.apphb.com/
Nuve is used for its morphologic generation ability in this project: http://fiilcek.apphb.com/

### Usage for Morphologic Analysis, Stemming and Generation:
     
     Language tr = Language.Turkish;

     //Analysis
     var analyzer = new WordAnalyzer(tr);
     
     IList<Word> solutions = analyzer.Analyze("deneme");
     
     foreach (var solution in solutions)
     {
      Console.WriteLine("\t{0}\n", solution);//Morphologic Analysis
      Console.WriteLine("\toriginal:{0} stem:{1}\n", solution.GetSurface(), solution.GetStem().GetSurface());//Stemming
     }

     //Generation
     Root root = tr.Roots.Get("kitap")[0];
     
     word = new Word(root);
     word.AddSuffix(tr.Suffixes.GetSuffix("IC_COGUL_lAr"));
     word.AddSuffix(tr.Suffixes.GetSuffix("IC_SAHIPLIK_BEN_(U)m"));
     word.AddSuffix(tr.Suffixes.GetSuffix("IC_HAL_BULUNMA_DA"));
     word.AddSuffix(tr.Suffixes.GetSuffix("IC_AITLIK_ki"));
     word.AddSuffix(tr.Suffixes.GetSuffix("IC_COGUL_lAr"));
     word.AddSuffix(tr.Suffixes.GetSuffix("IC_HAL_AYRILMA_DAn"));
     
     return word.GetSurface();
     
### Usage for Sentence Segmentation:     
     
     var paragraph = "Prof. Dr. Ahmet Bey 1.6 oranında artış var dedi 2. kez. E-posta adresi ahmet.bilir@prof.dr imiş! Doğru mu?";
     Splitter splitter = new RegexSplitter(RegexSplitter.ClassicPattern);
     var segmenter = new TokenBasedSentenceSegmenter(splitter);
     var sentences = segmenter.GetSentences(paragraph);
     foreach (string sentence in sentences)
     {
          Console.WriteLine(sentence);
     }     
     
### Add to your project

The easiest way to add Nuve in to your project is [NuGet] (http://www.nuget.org/packages/Nuve/)

In Visual Studio open [Package Manager Console] (http://docs.nuget.org/docs/start-here/using-the-package-manager-console) and run the following command:
     
     PM> Install-Package Nuve

