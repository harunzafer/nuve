using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Orthographic
{
    internal class Orthography
    {
        private readonly Alphabet _alphabet;
        private readonly IDictionary<string, OrthographyRule> _rules = new Dictionary<string, OrthographyRule>();

        public Orthography(Alphabet alphabet, IEnumerable<OrthographyRule> rules)
        {
            _alphabet = alphabet;
            foreach (OrthographyRule rule in rules)
            {
                _rules.Add(rule.Id, rule);
            }
        }

        public Alphabet Alphabet {get {return _alphabet; } }

        public OrthographyRule GetRule(string id)
        {
            OrthographyRule ortographyRule;
            return _rules.TryGetValue(id, out ortographyRule) ? ortographyRule : null;
        }

        public List<OrthographyRule> GetRules(IEnumerable<string> ids)
        {
            var orthographyRules = new List<OrthographyRule>();
            foreach (var id in ids)
            {
                //int id = Convert.ToInt32(rule.Value);
                if (GetRule(id)==null)
                {
                    //Console.WriteLine("Warning: Undefined orthograpy rule:" + id);
                }
                else
                {
                    orthographyRules.Add(GetRule(id));    
                }
                
            }
            return orthographyRules;
        }

        public string GetRuleNames()
        {
            var sb = new StringBuilder();
            foreach (var rule in _rules)
            {
                sb.Append(rule.Value.ToString());
            }
            return sb.ToString();
        }
    }
}