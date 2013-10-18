// -----------------------------------------------------------------------
// <copyright file="Tokens.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Oct17T1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>

    public enum TokenType
    {
        UNDEFINED, COMMENT, STRING, SPACE, OPERATOR, KEYWORD, PARANTHESIS
    }
    public class Token
    {
        private TokenType type;

        public TokenType Type
        {
            get { return type; }
            set { type = value; }
        }
        // private Tokens nextToken;
        private int lineNo;

        public int LineNo {
            get { return lineNo;  }
        }

        private string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Token(TokenType ty, int lno, string val)
        {
            type = ty;
            lineNo = lno;
            value = val;
        }

        public override string ToString()
        {
            return type + " " + lineNo + " -> " + value;
        }
    }
}
