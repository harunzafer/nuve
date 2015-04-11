using System;

namespace Nuve.Sentence
{
    internal class SimpleEvaluation
    {
        private readonly int _eosCandidateCount;

        public SimpleEvaluation(int hit, int missed, int falseAlarm, int eosCandidateCount)
        {
            if (eosCandidateCount <= 0)
            {
                throw new ArgumentException(
                    "There must be at least one possible end of sentence character (EOS candidate) !");
            }

            Hit = hit;
            Missed = missed;
            FalseAlarm = falseAlarm;
            _eosCandidateCount = eosCandidateCount;
        }

        public int EosCount
        {
            get { return _eosCandidateCount; }
        }

        public int Missed { get; private set; }

        public int Hit { get; private set; }

        public int FalseAlarm { get; private set; }

        public double Error
        {
            get { return (Missed + FalseAlarm)/(double) _eosCandidateCount; }
        }

        public double Accuracy
        {
            get { return 1 - Error; }
        }

        public override string ToString()
        {
            return
                "EOS Candidates:\t" + _eosCandidateCount + "\n" +
                "Hits:\t" + Hit + "\n" +
                "Missed:\t" + Missed + "\n" +
                "False alarm\t: " + FalseAlarm + "\n" +
                "\nAccuracy:\t" + String.Format("{0:0.00}%", Accuracy*100)
                ;
        }

        private bool Equals(SimpleEvaluation other)
        {
            return Missed == other.Missed && _eosCandidateCount == other._eosCandidateCount && Hit == other.Hit &&
                   FalseAlarm == other.FalseAlarm;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SimpleEvaluation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Missed;
                hashCode = (hashCode*397) ^ _eosCandidateCount;
                hashCode = (hashCode*397) ^ Hit;
                hashCode = (hashCode*397) ^ FalseAlarm;
                return hashCode;
            }
        }
    }
}