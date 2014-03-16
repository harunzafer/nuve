using System;
using Nuve.Condition;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic.Action;

namespace Nuve.Orthographic
{
    public class Transformation
    {
        private readonly BaseAction _action;
        private readonly Position _location;
        private readonly ConditionContainer _conditionContainer;

        public Transformation(BaseAction action, String location, ConditionContainer conditionContainer)
        {
            _action = action;
            _conditionContainer = conditionContainer;
            if (!Enum.TryParse(location, out _location))
            {
                throw new ArgumentException("Invalid Morpheme Location: " + location);
            }
        }

        public ConditionContainer Condition
        {
            get { return _conditionContainer; }
        }

        public void Transform(Allomorph allomorph)
        {
            _action.Do(allomorph, _location);
        }

        public override string ToString()
        {
            return string.Format("Transform: {0} Condition: {1}", _action, _conditionContainer);
        }
    }
}