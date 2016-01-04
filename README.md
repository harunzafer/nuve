nuve
===
Nuve is a Natural Language Processing Library for Turkish. Currently it supports:

 - Morphologic analysis (35K word per second on a i5 2.8 GHz 64 bit machine)
 - Morphologic generation
 - Stemming
 - Sentence (segmentation) boundary detection
 - N-gram extraction
 
Morphologic Analysis is demonstrated here: http://nuvedemo.apphb.com

Morphologic Generation is demonstrated here: http://fiilcek.apphb.com

Use cases for the above tasks are as follows: 


#### Morphologic Analysis and Stemming

```c#
Language tr = LanguageFactory.Create(LanguageType.Turkish);

IList<Word> solutions = tr.Analyze("yolsuzu");

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
	yol/ISIM IY_SIFAT_sUz IC_SAHIPLIK_O_(s)U
	original:yolsuzu stem:yolsuz root:yol/ISIM

	yol/ISIM IY_SIFAT_sUz IC_HAL_BELIRTME_(y)U
	original:yolsuzu stem:yolsuz root:yol/ISIM
```

####Morphologic Generation

```c#

//Method 1: Specify the ids of the morphemes that constitute the word
var word1 = tr.Generate("kitap/ISIM", "IC_COGUL_lAr", "IC_SAHIPLIK_BEN_(U)m",
"IC_HAL_BULUNMA_DA","IC_AITLIK_ki", "IC_COGUL_lAr", "IC_HAL_AYRILMA_DAn");

//Method 2: Specify the string representation of the analysis of the word.
string analysis = "kitap/ISIM IC_COGUL_lAr IC_SAHIPLIK_BEN_(U)m";
var word2 = tr.GetWord(analysis);

Console.WriteLine(word1.GetSurface());
Console.WriteLine(word2.GetSurface());
```
Output:
```
	kitaplarımdakilerden
	kitaplarım
```

Use the `public bool AddSuffix(Suffix suffix, Language language)` method in order to make sure that the word is still valid (for Turkish) after adding the suffix.

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
