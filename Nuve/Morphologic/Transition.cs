using Nuve.Condition;

namespace Nuve.Morphologic
{
    internal class Transition<T>
    {
        public readonly ConditionContainer Conditions;
        public readonly T Source;
        public readonly T Target;

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