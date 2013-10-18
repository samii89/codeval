
namespace Oct17T1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    public class Utilities
    {
        public static void breakToken(ArrayList tokenList, int tokenNo, int breakPosition, TokenType leftType, TokenType rightType, int lineNo)
        {
            Token token = (Token)tokenList[tokenNo];
            string val = token.Value;
            token.Value = val.Substring(0, breakPosition);
            token.Type = leftType;

            Token token2 = new Token(rightType, lineNo, val.Substring(breakPosition));
            tokenList.Insert(tokenNo + 1, token2);
        }

        public static void breakToken(ArrayList tokenList, int tokenNo, int breakPoistion, int newTokenLength
            , TokenType middleTokenType, TokenType rightTokenType, int middleTokenLineNo, int rightTokenLineNo)
        {
            Token token = (Token)tokenList[tokenNo];
            string value = token.Value;

            token.Value = value.Substring(0, breakPoistion);
            Token middleToken = new Token(middleTokenType, middleTokenLineNo, value.Substring(breakPoistion, newTokenLength));

            Token rightToken = new Token(rightTokenType, rightTokenLineNo, value.Substring(breakPoistion + newTokenLength));

            tokenList.Insert(tokenNo + 1, middleToken);
            tokenList.Insert(tokenNo + 2, rightToken);
        }
    }
}
