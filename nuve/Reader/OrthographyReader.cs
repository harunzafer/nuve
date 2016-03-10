using System;
using System.Collections.Generic;
using System.Xml;
using Nuve.Condition;
using Nuve.Orthographic;
using Nuve.Orthographic.Action;
using Nuve.Orthographic.SearchReplace;

namespace Nuve.Reader
{
    internal class OrthographyReader
    {
        private readonly Alphabet _alphabet;
        private readonly IEnumerable<OrthographyRule> _rules;
        private readonly XmlDocument _xml;
        private readonly List<SearchReplaceRule> _srrules = new List<SearchReplaceRule>();

        private OrthographyReader(XmlDocument xml)
        {
            _xml = xml;
            _alphabet = ReadAlphabet();
            _rules = ReadRules();
            ReadSearchReplaceRules();
        }

        public static Orthography Read(XmlDocument xml)
        {
            var reader = new OrthographyReader(xml);
            return reader.Get();
        }

        private Orthography Get()
        {
            return new Orthography(_alphabet, _rules, _srrules);
        }

        private void ReadSearchReplaceRules()
        {
            var nodes =  _xml.GetElementsByTagName("srrule");
            foreach (XmlNode node in nodes)
            {
                var old = node.Attributes?["old"].InnerText;
                var @new = node.Attributes?["new"].InnerText;
                _srrules.Add(new SearchReplaceRule(old, @new));
            }
        }

        private Alphabet ReadAlphabet()
        {
            var consonantsNode = _xml.GetElementsByTagName("consonants")[0].FirstChild;
            var vowelsNode = _xml.GetElementsByTagName("vowels")[0].FirstChild;
            var consonants = consonantsNode.Value;
            var vowels = vowelsNode.Value;
            return new Alphabet(consonants, vowels);
        }

        private IEnumerable<OrthographyRule> ReadRules()
        {
            var ruleNodeList = _xml.GetElementsByTagName("rule");
            return RulesAsList(ruleNodeList);
        }


        private IEnumerable<OrthographyRule> RulesAsList(XmlNodeList ruleNodeList)
        {
            var rules = new List<OrthographyRule>();
            foreach (XmlNode node in ruleNodeList)
            {
                rules.Add(ReadOrthographyRule(node));
            }
            return rules;
        }

        private List<char> LettersAsList(XmlNodeList nodeList)
        {
            var list = new List<char>();
            foreach (XmlNode node in nodeList)
            {
                list.Add(node.InnerText.ToCharArray()[0]);
            }
            return list;
        }

        private OrthographyRule ReadOrthographyRule(XmlNode ruleNode)
        {
            //string description = ruleNode["description"].InnerText;
            var id = ruleNode.Attributes["id"].InnerText;
            var level = ruleNode.Attributes["phase"].InnerText;
            var transforms = ReadTransformations(ruleNode);
            return new OrthographyRule(id, int.Parse(level), transforms);
        }

        private List<Transformation> ReadTransformations(XmlNode ruleNode)
        {
            var transformNodeList = ruleNode.SelectNodes("transformation");
            var transforms = new List<Transformation>();
            foreach (XmlNode transformNode in transformNodeList)
            {
                transforms.Add(ReadTransform(transformNode));
            }
            return transforms;
        }

        private Transformation ReadTransform(XmlNode transformNode)
        {
            var morpheme = transformNode.Attributes["morpheme"].InnerText;

            var actionName = transformNode.Attributes["action"].InnerText;

            var operandOne = transformNode.Attributes["operandOne"]?.InnerText ?? "";

            var operandTwo = transformNode.Attributes["operandTwo"]?.InnerText ?? "";

            var flag = transformNode.Attributes["flag"]?.InnerText ?? "";

            var action = ActionFactory.Create(actionName, _alphabet, operandOne, operandTwo, flag);

            var conditions = ConditionContainer.EmptyContainer();

            if (transformNode.HasChildNodes)
            {
                conditions = ReadConditionContainer(transformNode.FirstChild);
            }

            return new Transformation(action, morpheme, conditions);
        }

        private ConditionContainer ReadConditionContainer(XmlNode conditionsNode)
        {
            var conditions = new List<ConditionBase>();
            var flag = conditionsNode.Attributes["flag"].InnerText;

            if (conditionsNode.HasChildNodes)
            {
                conditions = ConditionsAsList(conditionsNode.ChildNodes);
            }

            return new ConditionContainer(conditions, flag);
        }

        private List<ConditionBase> ConditionsAsList(XmlNodeList ruleNodeList)
        {
            var conditions = new List<ConditionBase>();
            foreach (XmlNode node in ruleNodeList)
            {
                conditions.Add(ReadCondition(node));
            }
            return conditions;
        }

        private ConditionBase ReadCondition(XmlNode node)
        {
            var name = node.Attributes["operator"].InnerText;

            var morpheme = node.Attributes["morpheme"].InnerText;

            var operand = string.Empty;

            if (node.Attributes["operand"] != null)
            {
                operand = node.Attributes["operand"].InnerText;
            }

            return ConditionFactory.Create(name, morpheme, operand, _alphabet);
        }
    }
}