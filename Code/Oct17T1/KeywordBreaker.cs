
namespace Oct17T1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    public class KeywordBreaker : TokenBreaker
    {
        private string[] keywords = {"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
                                        "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", 
                                        "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", 
                                        "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object",
                                        "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte",
                                        "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try",
                                        "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"};

        public void breakInToTokens(ArrayList tokenList)
        {
            for (int i = 0; i < tokenList.Count; i++)
            {
                Token token = (Token)tokenList[i];

                if (token.Type != TokenType.UNDEFINED)
                    continue;

                string val = token.Value;

                if (keywords.Contains(val))
                    token.Type = TokenType.KEYWORD;
            }
        }
    }
}
