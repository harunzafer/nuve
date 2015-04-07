using System;
using System.Collections.Generic;
using Nuve.Morphologic.Structure;
using Nuve.Properties;

namespace Nuve.Orthographic
{
    //public enum Phase { One=1, Two=2, Three=3, Four=4, Fife } ;


    public class OrthographyRule
    {
        public static readonly int MaxPhaseNum = Int32.Parse(Resources.MaxPhaseNum);

        public readonly string Id;
        public readonly int Phase;
        private readonly List<Transformation> _transformations;

        public OrthographyRule(string id, int order, List<Transformation> transformations)
        {
            Phase = order;
            Id = id;
            this._transformations = transformations;
        }

        public void Process(Allomorph allomorph)
        {
            foreach (Transformation transformation in _transformations)
            {
                if (transformation.Condition.IsTrue(allomorph))
                {
                    transformation.Transform(allomorph);
                    break;
                }
            }
        }

        public bool IsLeftRule
        {
            get { return Phase == 2; }
        }

        public bool IsRightRule
        {
            get { return Phase == 3; }
        }

        public bool IsSelfRule
        {
            get { return Phase == 4; }
        }

        public bool IsDefaultRule
        {
            get { return Phase == 5; }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}