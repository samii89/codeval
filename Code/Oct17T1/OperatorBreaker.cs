
namespace Oct17T1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    public class OperatorBreaker : TokenBreaker
    {
        
        private static char[,] threeOperators = {{'<','<','='}, {'>','>','='}};

        private static  char[] singleOpertors = {'!', '%', '&', '*', '+', '-', '/', ':',';', '<', '=', '>', '?', '^', '|', '~'};

        private static  char[,] doubleOperators = { { '+', '+' }, { '-', '-' }, { '-', '>' }, { '<', '<' }, { '>', '>' }, 
                                                       {'<','='},{'>','='},{'=','='},{'!','='},{'&','&'},{'|','|'},{'?','?'},{'+','='},
                                                       {'-','='},{'*','='},{'/','='},{'%','='},{'&','='},{'|','='}, {'^','='}, {'=','>'}};

        public void breakInToTokens(ArrayList tokenList)
        {

            Console.WriteLine(doubleOperators[2,1]);

            for (int i = 0; i < tokenList.Count; i++)
            {
                Token t = (Token)tokenList[i];

                if (t.Type != TokenType.UNDEFINED)
                    continue;

                char[] charArray = t.Value.ToCharArray();
                bool over = false;

                for (int j = 0; j < charArray.Length && !over; j++)
                {

                    char c = charArray[j];
                    //Search in three array
                    for (int y = 0; y < threeOperators.GetLength(0); y++)
                    {

                        if (j + 2 < charArray.Length && c == threeOperators[y, 0] && charArray[j + 1] == threeOperators[y, 1] && charArray[j + 2] == threeOperators[y, 2])
                        {
                            int tokenLineNo = t.LineNo;

                            if (j > 0 && charArray[j - 1] == '\n')
                                ++tokenLineNo;//If there is a /n before operator // \n+

                            int nextLineNo = t.LineNo;

                            if (((j + 3) < charArray.Length) && charArray[j + 3] == '\n')
                                nextLineNo++;//if there is a new line after operator

                            Utilities.breakToken(tokenList, i, j, 3, TokenType.OPERATOR, TokenType.UNDEFINED, tokenLineNo, nextLineNo);
                            over = true;
                            break;
                        }
                    }

                    //search in doubvle arrar
                    for (int y = 0; y < doubleOperators.GetLength(0); y++)
                    { 
                        if (j + 1 < charArray.Length && c == doubleOperators[y ,0] && charArray[j + 1] == doubleOperators[y, 1])
                        {
                            int tokenLineNo = t.LineNo;

                            if (j > 0 && charArray[j - 1] == '\n')
                                ++tokenLineNo;//If there is a /n before operator // \n+

                            int nextLineNo = t.LineNo;

                            if (((j+2) < charArray.Length) && charArray[j + 2] == '\n')
                                nextLineNo++;//if there is a new line after operator

                            Utilities.breakToken(tokenList, i, j, 2, TokenType.OPERATOR, TokenType.UNDEFINED, tokenLineNo, nextLineNo);
                            over = true;
                            break;
                        }
                    }

                    if (!over && Array.BinarySearch(singleOpertors, c) > 0)
                    {
                        int tokenLineNo = t.LineNo;

                        if(j > 0 && charArray[j-1] == '\n')
                            ++tokenLineNo;//If there is a /n before operator // \n+

                        int nextLineNo = t.LineNo;

                        if(j + 1 < charArray.Length && charArray[j+1] == '\n')
                            nextLineNo++;//if there is a new line after operator

                        Utilities.breakToken(tokenList, i, j, 1, TokenType.OPERATOR, TokenType.UNDEFINED, tokenLineNo, nextLineNo);
                        break;
                    }


                }
            }
        }
    }
}
