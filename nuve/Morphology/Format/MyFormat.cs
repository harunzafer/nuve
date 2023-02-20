using System.Text;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic.Format
{
    public class MyFormat : WordFormat
    {
        internal override string Format(Word word)
        {
            var sb = new StringBuilder();
            foreach (var allomorph in word)
            {
                sb.Append(allomorph.Surface)
                    .Append("/")
                    .Append(allomorph.Morpheme.SequenceId)
                    .Append(" ");
            }
            return sb.ToString().TrimEnd();
        }
    }
}