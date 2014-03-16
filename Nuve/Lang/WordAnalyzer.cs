using System.Collections.Generic;
using System.Text;
using Nuve.Morphologic.Structure;

namespace Nuve.Lang
{
    public class WordAnalyzer
    {
        private readonly Language lang;
        public WordAnalyzer(Language language) {
            this.lang = language;
        }

        /// <summary>
        /// Bir kelimenin muhtemel tüm çözümlerini döndürür.
        /// </summary>
        /// <param name="token">kelime adayı, analiz edilemezse kelime olarak kabul edilmez.</param>
        /// <param name="checkTransition"> Morfotaktik geçişleri kontrol et. </param>
        /// <param name="checkOrthography"> Ortografik kuralları işlet ve kontrol et.</param>
        /// <param name="checkTransitionConditions">Morfotaktik geçiş koşullarını kontrol et. </param>
        /// <returns></returns>
        public IList<Word> Analyze(string token, bool checkTransition = true, bool checkOrthography = true, bool checkTransitionConditions = true) {

            IList<Word> words = new List<Word>();
            IList<RootSurfacePair> roots = FindPossibleRoots(token);
            foreach (RootSurfacePair pair in roots)
            {
                GetPossibleWords(new Word(pair.Root), token.Remove(0, pair.Surface.Length), words, checkTransition);
            }

            if (checkOrthography)
            {
                EliminateByOrtography(words, token);    
            }

            if (checkTransitionConditions)
            {
                EliminateByMorphotactics(words);    
            }

            return words;
        }

        public bool HasCorrectSurface(Word word, string surface) {
            return word.GetSurface() == surface;
        }

        public void EliminateByOrtography(IList<Word> analyses, string surface) {
            for (int i = analyses.Count - 1; i >= 0; i--) //Reverse for loop to remove element
            {
                if (!HasCorrectSurface(analyses[i], surface)) {
                    analyses.RemoveAt(i);
                }
            }
        }

        public void EliminateByMorphotactics(IList<Word> analyses)
        {
            for (int i = analyses.Count - 1; i >= 0; i--) //Reverse for loop to remove element
            {
                if (!lang.Morphotactics.IsValid(analyses[i]))
                {
                    analyses.RemoveAt(i);
                }
            }
        }


        /// <summary>
        /// Verilen bir kelimenin muhtemel tüm eklerini döndürür.
        /// </summary>
        /// <param name="token">Kökü bulunacak kelime</param>
        /// <returns></returns>
        private List<RootSurfacePair> FindPossibleRoots(string token)
        {
            var rootSurfacePairs = new List<RootSurfacePair>();
            for (int i = 0; i < token.Length; i++)
            {
                string prefix = token.Substring(0, i+1);
                if (lang.Roots.Contains(prefix))
                {
                    foreach (Root root in lang.Roots.Get(prefix)) { 
                        rootSurfacePairs.Add(new RootSurfacePair(root, prefix));
                    }
                }
            }
            return rootSurfacePairs;
        }

        private  void GetPossibleWords(Word word, string restOfWord, IList<Word> words, bool checkTransition)
        {
            if (restOfWord.Length == 0)
            {
                Word newPossibleWord = new Word(word);
                words.Add(newPossibleWord);
                return;
            }

            IList<KeyValuePair<string, Suffix>> possibleFirstSuffixes = GetPossibleFirstSuffixes(restOfWord);
            

            if (possibleFirstSuffixes.Count == 0)
            {
                return;
            }

            foreach (var pair in possibleFirstSuffixes)
            {
                //Burada değişiklik yaptık, şimdilik sorun yok
                if (!lang.Morphotactics.HasTransition(word.Last.Morpheme.Id, pair.Value.Id) && checkTransition)
                {
                    continue;
                }
                word.AddSuffix(pair.Value);
                GetPossibleWords(word, restOfWord.Remove(0, pair.Key.Length), words, checkTransition);
                word.RemoveSuffix();
            }

        }

        private  IList<KeyValuePair<string, Suffix>> GetPossibleFirstSuffixes(string prefix)
        {
            var list = new List<KeyValuePair<string, Suffix>>();
            IList<Suffix> possibleSuffixes;
            var sb = new StringBuilder();
            foreach (char ch in prefix)
            {
                sb.Append(ch);
                if (lang.Suffixes.ContainsSuffixStartsWith(sb.ToString()))
                {
                    possibleSuffixes = lang.Suffixes.GetSuffixes(sb.ToString());
                    foreach (var possibleSuffix in possibleSuffixes)
                    {
                        list.Add(new KeyValuePair<string, Suffix>(sb.ToString(), possibleSuffix));
                    }
                }
                else
                {
                    break;
                }

            }
            return list;
        }
        
    }
}
