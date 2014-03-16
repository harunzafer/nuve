using System;
using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Condition
{
    public class ConditionContainer
    {
        private readonly IList<ConditionBase> conditions;
        private readonly bool flag;

        public ConditionContainer(IList<ConditionBase> conditions, string flag)
        {
            if (String.IsNullOrEmpty(flag) || flag == "Or")
            {
                this.flag = false;
            }
            else if (flag=="And")
            {
                this.flag = true;
            }
            else
            {
                throw new ArgumentException("Geçersiz Flag deðeri, And veya Or olmalý :)");
            }

            this.conditions = conditions;
        }

        public bool IsEmpty
        {
            get { return conditions.Count == 0; }
        }

        public bool IsTrue(Allomorph allomorph)
        {
            if (IsEmpty)
            {
                return true;
            }

            return flag ? AreAllConditionsTrue(allomorph) : IsAnyConditionTrue(allomorph);
        }

        public static ConditionContainer EmptyContainer()
        {
            return new ConditionContainer(new List<ConditionBase>().AsReadOnly(), "");
        }

        private bool AreAllConditionsTrue(Allomorph allomorph)
        {
            foreach (var condition in conditions)
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
            foreach (var condition in conditions)
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