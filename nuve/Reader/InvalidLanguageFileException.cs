using System;

namespace Nuve.Reader
{
    public enum Type
    {
        Orthograpy,
        Morphotactics,
        Roots,
        Suffixes
    }

    public class InvalidLanguageFileException : Exception
    {
        public readonly Exception OriginalException;
        public readonly Type Type;


        public InvalidLanguageFileException(Exception originalException, Type type, string msg) :
            base(msg + originalException.Message, originalException)
        {
            OriginalException = originalException;
            Type = type;
        }
    }
}