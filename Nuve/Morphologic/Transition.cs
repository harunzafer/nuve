using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Condition;

namespace Nuve.Morphologic
{
    class Transition<T>
    {
        public readonly T Source;
        public readonly T Target;
        public readonly ConditionContainer Conditions;

        public Transition(T source, T target, ConditionContainer conditions)
        {
            Source = source;
            Target = target;
            Conditions = conditions;
        }

        public Transition(T source, T target)
        {
            Source = source;
            Target = target;
            Conditions = ConditionContainer.EmptyContainer();
         
        }
        

    }
}
