using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nuve.Orthographic
{
    internal class Orthography
    {
        private readonly IDictionary<string, OrthographyRule> _rules = new Dictionary<string, OrthographyRule>();

        private static readonly TraceSource _trace = new TraceSource("Orthography");

        internal Orthography(Alphabet alphabet, IEnumerable<OrthographyRule> rules)
        {
            Alphabet = alphabet;
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
                    _trace.TraceEvent(TraceEventType.Warning, 0, $"Undefined rule id: {id}");
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
    }
}