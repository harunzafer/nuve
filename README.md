nuve
====
Simple Usage:

     WordAnalyzer _analyzer = new WordAnalyzer(Language.Turkish);
     
     IList<Word> solutions = analyzer.Analyze("deneme");
     
     foreach (var solution in solutions)
     {    
          Console.WriteLine("\t{0}\n", solution);
     }
