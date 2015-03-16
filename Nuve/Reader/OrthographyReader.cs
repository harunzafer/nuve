﻿using System;
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

        private static OrthographyRule ReadOrthographyRule(XmlNode ruleNode)
        {
            string description = ruleNode["description"].InnerText;
            string id = ruleNode.Attributes["id"].InnerText;
            string type = ruleNode.Attributes["type"].InnerText;
            List<Transformation> transforms = ReadTransforms(ruleNode, type);
            return new OrthographyRule(id, type, transforms);
        }

        private static List<Transformation> ReadTransforms(XmlNode ruleNode, string type)
        {
            XmlNodeList transformNodeList = ruleNode.SelectNodes("transformation");
            var transforms = new List<Transformation>();
            foreach (XmlNode transformNode in transformNodeList)
            {
                transforms.Add(ReadTransform(transformNode, type));
            }
            return transforms;
        }

        private static Transformation ReadTransform(XmlNode transformNode, string type)
        {
            string actionName = transformNode.Attributes["action"].InnerText;
            
            string operandOne = transformNode.Attributes["operandOne"] != null ? 
                transformNode.Attributes["operandOne"].InnerText : "";

            string operandTwo = transformNode.Attributes["operandTwo"] != null ?
                transformNode.Attributes["operandTwo"].InnerText : "";

            string flag = transformNode.Attributes["flag"] != null ?
                transformNode.Attributes["flag"].InnerText : "";

            BaseAction action = ActionFactory.Create(actionName, _alphabet, operandOne, operandTwo, flag);

            ConditionContainer conditions = ConditionContainer.EmptyContainer();

            if (transformNode.HasChildNodes)
            {
                conditions = ReadConditionContainer(transformNode.FirstChild, type);
            }

            string position = "Current";

            if (transformNode.Attributes["position"] != null)
            {
                position = transformNode.Attributes["position"].InnerText;
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

            if (type == "Self")
            {
                Console.WriteLine("");
            }

            return ConditionFactory.Create(name, morphemeLocation, operand, _alphabet);                
        }
    }
}