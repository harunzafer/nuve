namespace Nuve.Lexers
{
    internal class Token
    {
        public readonly string Type;
        public readonly string Value;

        public Token(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}