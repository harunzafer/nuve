using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Nuve.Orthographic.SearchReplace;

namespace Nuve.Orthographic
{
    internal class Orthography
    {
        private readonly IDictionary<string, OrthographyRule> _rules = new Dictionary<string, OrthographyRule>();
        private readonly IEnumerable<SearchReplaceRule> _searchReplaces = new List<SearchReplaceRule>();

        private static readonly TraceSource Trace = new TraceSource("Orthography");

        internal Orthography(Alphabet alphabet, IEnumerable<OrthographyRule> rules, IEnumerable<SearchReplaceRule> searchReplaces)
        {
            Alphabet = alphabet;
            this._searchReplaces = searchReplaces;
            foreach (OrthographyRule rule in rules)
            {
                _rules.Add(rule.Id, rule);
            }
        }

        public Alphabet Alphabet { get; }

        public List<OrthographyRule> GetRules(IEnumerable<string> ids)
        {
            var orthographyRules = new List<OrthographyRule>();
            foreach (string id in ids.Distinct())
            {
                if (GetRule(id) == null)
                {
                    Trace.TraceEvent(TraceEventType.Warning, 0, $"Undefined rule id: {id}");
                }
                else
                {
                    orthographyRules.Add(GetRule(id));
                }
            }
            return orthographyRules;
        }

        public OrthographyRule GetRule(string id)
        {
            OrthographyRule ortographyRule;
            return _rules.TryGetValue(id, out ortographyRule) ? ortographyRule : null;
        }

        public string GetRuleNames()
        {
            var sb = new StringBuilder();
            foreach (var rule in _rules)
            {
                sb.Append(rule.Value);
            }
            return sb.ToString();
        }

        public string ProcessSearchReplaceRules(string surface)
        {
            return _searchReplaces.Aggregate(surface, (current, rule) => rule.Replace(current));
        }
    }
}