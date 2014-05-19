nuve
====
Nuve is a Natural Language Processing Library for Turkish. Currently it supports morphologic analysis and generation. Morphologic Analysis is demonstrated here: http://nuvedemo.apphb.com/

Usage for Morphologic Analysis and Generation:

     
     Language tr = Language.Turkish;
     

     //Analysis
     WordAnalyzer _analyzer = new WordAnalyzer(tr);
     
     IList<Word> solutions = analyzer.Analyze("deneme");
     
     foreach (var solution in solutions)
     {    
          Console.WriteLine("\t{0}\n", solution);
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
