using System.Collections.Generic;
using System.Linq;
using Nuve.Morphologic.Structure;

namespace Nuve.Lang
{
    public class WordAnalyzer
    {
        private readonly Language _lang;

        public WordAnalyzer(Language language)
        {
            _lang = language;
        }

        /// <summary>
        ///     Bir kelimenin muhtemel tüm çözümlerini döndürür.
        /// </summary>
        /// <param name="token">kelime adayı, analiz edilemezse kelime olarak kabul edilmez.</param>
        /// <param name="checkTransition"> Morfotaktik geçişleri kontrol et. </param>
        /// <param name="checkOrthography"> Ortografik kuralları işlet ve kontrol et.</param>
        /// <param name="checkTransitionConditions">Morfotaktik geçiş koşullarını kontrol et. </param>
        /// <returns></returns>
        public IList<Word> Analyze(string token, bool checkTransition = true,
            bool checkOrthography = true, bool checkTransitionConditions = true)
        {
            var words = new List<Word>();
            IEnumerable<KeyValuePair<string, Root>> roots = FindPossibleRoots(token);
            foreach (var pair in roots)
            {
                GetPossibleWords(new Word(pair.Value), token.Remove(0, pair.Key.Length), words, checkTransition);
                
            }

            if (checkTransitionConditions)
            {
                EliminateByMorphotactics(words);
            }

            if (checkOrthography)
            {
                EliminateByOrtography(words, token);
            }

            return words.Distinct().ToList();
        }

        private void EliminateByOrtography(IList<Word> analyses, string surface)
        {
            for (int i = analyses.Count - 1; i >= 0; i--) //Reverse for loop to remove element
            {
                if (!HasCorrectSurface(analyses[i], surface))
                {
                    
                    analyses.RemoveAt(i);
                }
            }
        }

        private bool HasCorrectSurface(Word word, string surface)
        {
            return word.GetSurface() == surface;
        }

        private void EliminateByMorphotactics(IList<Word> analyses)
        {
            for (int i = analyses.Count - 1; i >= 0; i--) //Reverse for loop to remove element
            {
                if (!_lang.Morphotactics.IsValid(analyses[i]))
                {
                    analyses.RemoveAt(i);
                }
            }
        }


        private void GetPossibleWords(Word word, string restOfWord, IList<Word> words, bool checkTransition)
        {
            if (restOfWord.Length == 0)
            {
                var newPossibleWord = new Word(word);
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
                if (!_lang.Morphotactics.HasTransition(word.Last.Morpheme.Id, pair.Value.Id) && checkTransition)
                {
                    continue;
                }
                word.AddSuffix(pair.Value);
                GetPossibleWords(word, restOfWord.Remove(0, pair.Key.Length), words, checkTransition);
                word.RemoveLastSuffix();
            }
        }

        /// <summary>
        ///     Verilen bir kelimenin muhtemel tüm eklerini döndürür.
        /// </summary>
        /// <param name="token">Kökü bulunacak kelime</param>
        /// <returns></returns>
        private IEnumerable<KeyValuePair<string, Root>> FindPossibleRoots(string token)
        {
            var pairs = new List<KeyValuePair<string, Root>>();
            for (int i = 0; i < token.Length; i++)
            {
                string prefix = token.Substring(0, i + 1);

                IEnumerable<Root> roots = _lang.GetRootsHavingSurface(prefix);

                foreach (Root root in roots)
                {
                    pairs.Add(new KeyValuePair<string, Root>(prefix, root));
                }
            }
            return pairs;
        }

        private IList<KeyValuePair<string, Suffix>> GetPossibleFirstSuffixes(string token)
        {
            var pairs = new List<KeyValuePair<string, Suffix>>();

            for (int i = 0; i < token.Length; i++)
            {
                string prefix = token.Substring(0, i + 1);

                IEnumerable<Suffix> suffixes = _lang.GetSuffixesHavingSurface(prefix);

                foreach (Suffix suffix in suffixes)
                {
                    pairs.Add(new KeyValuePair<string, Suffix>(prefix, suffix));
                }
            }

            return pairs;
        }
    }
}