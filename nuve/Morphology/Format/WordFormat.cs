using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic.Format
{
    public abstract class WordFormat
    {
        internal abstract string Format(Word word);

        public static readonly WordFormat MyFormat = new MyFormat();
    }
}