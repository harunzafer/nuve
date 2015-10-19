nuve
===
Nuve is a Natural Language Processing Library for Turkish. Currently it supports:

 - Morphologic analysis (33K word per second on a i5 2.8 GHz 64 bit machine)
 - Morphologic generation
 - Stemming
 - Sentence (segmentation) boundary detection
 - N-gram extraction
 
Morphologic Analysis is demonstrated here: http://nuvedemo.apphb.com

Morphologic Generation is demonstrated here: http://fiilcek.apphb.com

Use cases for the above tasks are as follows: 


#### Morphologic Analysis and Stemming

```c#
Language tr = Language.Turkish;

//Analysis
var analyzer = new WordAnalyzer(tr);

//Morphologic Analysis and stemming
IList<Word> solutions = analyzer.Analyze("deneme");

foreach (var solution in solutions)
{
    Console.WriteLine("\t{0}", solution);
    Console.WriteLine("\toriginal:{0} stem:{1}\n",
    solution.GetSurface(),
    solution.GetStem().GetSurface()); //Stemming
}
```
Output:

```
	de/FIIL Ul/FY_EDILGEN_Ul_(U)n yAmA/FC_YF_YETERSIZLIK_(y)AmA
	original:deneme stem:deneme
	
	dene/FIIL mA/FIILIMSI_ISIM_mA
	original:deneme stem:deneme

	dene/FIIL mA/FY_OLUMSUZLUK_mA
	original:deneme stem:deneme
```

####Morphologic Generation

```c#
Root root = tr.GetRootsHavingSurface("kitap").First();

var word = new Word(root);
word.AddSuffix(tr.GetSuffix("IC_COGUL_lAr"));
word.AddSuffix(tr.GetSuffix("IC_SAHIPLIK_BEN_(U)m"));
word.AddSuffix(tr.GetSuffix("IC_HAL_BULUNMA_DA"));
word.AddSuffix(tr.GetSuffix("IC_AITLIK_ki"));
word.AddSuffix(tr.GetSuffix("IC_COGUL_lAr"));
word.AddSuffix(tr.GetSuffix("IC_HAL_AYRILMA_DAn"));

Console.WriteLine(word.GetSurface()); //prints "kitabımdakilerden"
```

Use the `public bool AddSuffix(Suffix suffix, Language language)` in order to make sure that the word is still valid after adding the suffix

```c#
Root root = tr.GetRootsHavingSurface("gel").First(); //A Turkish verb root 

var word = new Word(root);

//In Turkish the plural suffix "IC_COGUL_lAr" can not be appended to verbs!
if(!word.AddSuffix(tr.GetSuffix("IC_COGUL_lAr"), tr))
{
    Console.WriteLine("Adding the suffix IC_COGUL_lAr after a verb is not valid!");
    Console.WriteLine(word.GetSurface()); //prints "gel"
}

```

Output:
```
	kitaplarımdakilerden
```

####Sentence Segmentation:     

```c#
var paragraph = "Prof. Dr. Ahmet Bey 1.6 oranında artış var dedi 2. kez. E-posta adresi ahmet.bilir@prof.dr imiş! Doğru mu?";
ITokenizer tokenizer = new ClassicTokenizer(true);
SentenceSegmenter segmenter = new TokenBasedSentenceSegmenter(tokenizer);
var sentences = segmenter.GetSentences(paragraph);
foreach (string sentence in sentences)
{
	Console.WriteLine(sentence);
}
```

#### N-gram Extraction:     

```c#
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



