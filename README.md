nuve
===
Nuveis a Natural Language Processing Library for Turkish. Currently it supports:

 - Morphologic analysis
 - Morphologic generation
 - Stemming
 - Sentence (segmentation) boundary detection
 - N-gram extraction

Morphologic Analysis is demonstrated here: http://nuvedemo.apphb.com/
Nuve is used for its morphologic generation ability in this project: http://fiilcek.apphb.com/

Use cases for the above tasks are as follows: 


#### Morphologic Analysis, Stemming and Generation:

```
Language tr = Language.Turkish;

//Analysis
var analyzer = new WordAnalyzer(tr);

//Morphologic Analysis and stemming
IList<Word> solutions = analyzer.Analyze("deneme");
 
foreach (var solution in solutions)
{
    Console.WriteLine("\t{0}\n", solution);
    Console.WriteLine("\toriginal:{0} stem:{1}\n", 
    solution.GetSurface(), 
    solution.GetStem().GetSurface()); //Stemming
}

//Morphologic Generation
Root root = tr.Roots.Get("kitap")[0];
 
word = new Word(root);
word.AddSuffix(tr.Suffixes.GetSuffix("IC_COGUL_lAr"));
word.AddSuffix(tr.Suffixes.GetSuffix("IC_SAHIPLIK_BEN_(U)m"));
word.AddSuffix(tr.Suffixes.GetSuffix("IC_HAL_BULUNMA_DA"));
word.AddSuffix(tr.Suffixes.GetSuffix("IC_AITLIK_ki"));
word.AddSuffix(tr.Suffixes.GetSuffix("IC_COGUL_lAr"));
word.AddSuffix(tr.Suffixes.GetSuffix("IC_HAL_AYRILMA_DAn"));
 
return word.GetSurface();
```
 
####Sentence Segmentation:     

```
 var paragraph = "Prof. Dr. Ahmet Bey 1.6 oranında artış var dedi 2. kez. E-posta adresi ahmet.bilir@prof.dr imiş! Doğru mu?";
 Splitter splitter = new RegexSplitter(RegexSplitter.ClassicPattern);
 var segmenter = new TokenBasedSentenceSegmenter(splitter);
 var sentences = segmenter.GetSentences(paragraph);
 foreach (string sentence in sentences)
 {
	  Console.WriteLine(sentence);
 }     
```

#### N-gram Extraction:     

```
string Text1 = "I am Sam";
string Text2 = "Sam I am";
string Text3 = "I do not like green eggs and ham";
int Unigram = 1;
int Bigram = 2;
int Trigram = 3;

var corpus = new NGramDictionary(new NGramExtractor(Unigram, Trigram));
corpus.AddSequence(Text1.Split(null).ToList());
corpus.AddSequence(Text2.Split(null).ToList());
corpus.AddSequence(Text3.Split(null).ToList());

int freq = corpus.GetFrequency("I", "am");
```
 
### Add to your project

The easiest way to add Nuve in to your project is [NuGet] (http://www.nuget.org/packages/Nuve/)

In Visual Studio open [Package Manager Console] (http://docs.nuget.org/docs/start-here/using-the-package-manager-console) and run the following command:
   
  

    PM> Install-Package Nuve

   

