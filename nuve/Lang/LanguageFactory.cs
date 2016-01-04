using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Orthographic.Action;
using Nuve.Reader;

namespace Nuve.Lang
{
    class LanguageFactory
    {
        public static Language Create(LanguageType type)
        {
            switch (type)
            {
                case LanguageType.Turkish:
                    return new LanguageReader("Tr", false).Read();
                default:
                    throw new ArgumentException($"Language is not supported: {type}");
            }
        }
    }
}
