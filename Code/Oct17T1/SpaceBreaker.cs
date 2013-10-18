
namespace Oct17T1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    public class SpaceBreaker : TokenBreaker
    {
        public void breakInToTokens(ArrayList tokenList)
        {
            for (int i = 0; i < tokenList.Count; i++ )
            {
                Token token = (Token)tokenList[i];

                if(token.Type != TokenType.UNDEFINED)
                    continue;

                bool space = false;

                char[] strArray = token.Value.ToCharArray();

                if (strArray.Length == 0)
                    continue;

                if (strArray[0] == ' ' || strArray[0] == '\r' || strArray[0] == '\n')
                {
                    space = true;
                }

                int lineNo = token.LineNo;

                for (int j = 0; j < token.Value.Length ; j++ )
                {
                    char c = strArray[j];

                    if(!space && (c == ' ' || c == '\r' || c == '\n'))
                    {
                        Utilities.breakToken(tokenList, i, j, TokenType.UNDEFINED, TokenType.UNDEFINED, lineNo);
                        break;
                    }
                    else if(space && c != ' ' && c != '\r' && c != '\n')
                    {
 
                        Utilities.breakToken(tokenList, i, j, TokenType.SPACE, TokenType.UNDEFINED, lineNo);
                        break;
                    }

                    if (c == '\n') ++lineNo;
                }
            }
        }
    }
}
