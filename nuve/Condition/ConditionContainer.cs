using System;
using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Condition
{
    public class ConditionContainer
    {
        private readonly IList<ConditionBase> _conditions;
        private readonly bool _flag;

        public ConditionContainer(IList<ConditionBase> conditions, string flag)
        {
            if (String.IsNullOrEmpty(flag) || flag == "Or")
            {
                _flag = false;
            }
            else if (flag == "And")
            {
                _flag = true;
            }
            else
            {
                throw new ArgumentException("Ge�ersiz Flag de�eri, And veya Or olmal� :)");
            }

            _conditions = conditions;
        }

        public bool IsEmpty
        {
            get { return _conditions.Count == 0; }
        }

        public bool IsTrue(Allomorph allomorph)
        {
            if (IsEmpty)
            {
                return true;
            }

            return _flag ? AreAllConditionsTrue(allomorph) : IsAnyConditionTrue(allomorph);
        }

        public static ConditionContainer EmptyContainer()
        {
            return new ConditionContainer(new List<ConditionBase>().AsReadOnly(), "");
        }

        private bool AreAllConditionsTrue(Allomorph allomorph)
        {
            foreach (ConditionBase condition in _conditions)
            {
                if (!condition.IsTrueFor(allomorph))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsAnyConditionTrue(Allomorph allomorph)
        {
            foreach (ConditionBase condition in _conditions)
            {
                if (condition.IsTrueFor(allomorph))
                {
                    return true;
                }
            }
            return false;
        }
    }
}