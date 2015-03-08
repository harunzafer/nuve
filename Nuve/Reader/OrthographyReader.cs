using System;
using System.Collections.Generic;
using System.Xml;
using Nuve.Condition;
using Nuve.Orthographic;
using Nuve.Orthographic.Action;

namespace Nuve.Reader
{
    internal class OrthographyReader
    {
        private static Alphabet _alphabet;

        public static Orthography Read(XmlDocument xml)
        {
            //var xml = EmbeddedResourceReader.ReadXml(xmlFileName);

            
            
            _alphabet = ReadAlphabet(xml);
            List<OrthographyRule> rules = ReadRules(xml);
            return new Orthography(_alphabet, rules);
        }

        private static Alphabet ReadAlphabet(XmlDocument xml)
        {
            XmlNode consonantsNode = xml.GetElementsByTagName("consonants")[0].FirstChild;
            XmlNode vowelsNode = xml.GetElementsByTagName("vowels")[0].FirstChild;
            var consonants = new List<char>(consonantsNode.Value.ToCharArray());
            var vowels = new List<char>(vowelsNode.Value.ToCharArray());
            return new Alphabet(consonants, vowels);
        }

        private static List<OrthographyRule> ReadRules(XmlDocument xml)
        {
            XmlNodeList ruleNodeList = xml.GetElementsByTagName("rule");
            return RulesAsList(ruleNodeList);
        }


        private static List<OrthographyRule> RulesAsList(XmlNodeList ruleNodeList)
        {
            var rules = new List<OrthographyRule>();
            foreach (XmlNode node in ruleNodeList)
            {
                rules.Add(ReadOrthographyRule(node));
            }
            return rules;
        }

        private static List<char> LettersAsList(XmlNodeList nodeList)
        {
            var list = new List<char>();
            foreach (XmlNode node in nodeList)
            {
                list.Add(node.InnerText.ToCharArray()[0]);
            }
            return list;
        }

        private static OrthographyRule ReadOrthographyRule(XmlNode node)
        {
            string description = node["description"].InnerText; //node.ChildNodes[0].InnerText;
            string id = node.Attributes["id"].InnerText;
            string type = node.Attributes["type"].InnerText;
            List<Transformation> transforms = ReadTransforms(node, type);
            return new OrthographyRule(id, type, transforms);
        }

        private static List<Transformation> ReadTransforms(XmlNode ruleNode, string type)
        {
            XmlNodeList transformNodeList = ruleNode.SelectNodes("transformation");
            var transforms = new List<Transformation>();
            foreach (XmlNode node in transformNodeList)
            {
                transforms.Add(ReadTransform(node, type));
            }
            return transforms;
        }

        private static Transformation ReadTransform(XmlNode node, string type)
        {
            string actionName = node.Attributes["action"].InnerText;
            string operandOne = "";
            string operandTwo = "";
            string flag = "";
            
            try
            {                
                operandOne = node.Attributes["operandOne"].InnerText;
                operandTwo = node.Attributes["operandTwo"].InnerText;
                flag = node.Attributes["flag"].InnerText;
            } 
            catch (Exception) { }

            BaseAction action = ActionFactory.Create(actionName, _alphabet, operandOne, operandTwo, flag);

            ConditionContainer conditions = ConditionContainer.EmptyContainer();

            if (node.HasChildNodes)
            {
                conditions = ReadConditionContainer(node.FirstChild, type);
            }

            string position = "Current";

            if (node.Attributes["position"] != null)
            {
                position = node.Attributes["position"].InnerText;
            }

            return new Transformation(action, position, conditions);
        }

        private static ConditionContainer ReadConditionContainer(XmlNode conditionsNode, string type)
        {
            var conditions = new List<ConditionBase>();
            string flag = conditionsNode.Attributes["flag"].InnerText;

            if (conditionsNode.HasChildNodes)
            {
                conditions = ConditionsAsList(conditionsNode.ChildNodes, type);
            }

            return new ConditionContainer(conditions, flag);
        }

        private static List<ConditionBase> ConditionsAsList(XmlNodeList ruleNodeList, string type)
        {
            var conditions = new List<ConditionBase>();
            foreach (XmlNode node in ruleNodeList)
            {
                conditions.Add(ReadCondition(node, type));
            }
            return conditions;
        }
        
        private static ConditionBase ReadCondition(XmlNode node, string type)
        {
            string name = node.Attributes["operator"].InnerText;
            string morphemeLocation = type;
            if (node.Attributes["morphemeLocation"] != null)
            {
                morphemeLocation = node.Attributes["morphemeLocation"].InnerText;
            }
            else if (type == "First")
            {
                morphemeLocation = "Next";
            }

            string operand = string.Empty;
            if (node.Attributes["operand"] != null)
            {
                operand = node.Attributes["operand"].InnerText;                
            }

            return ConditionFactory.Create(name, morphemeLocation, operand, _alphabet);                
        }
    }
}