// -----------------------------------------------------------------------
// <copyright file="ParanthesisBreaker.cs" company="Microsoft">
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

    public class ParanthesisBreaker : TokenBreaker
    {
        char[] paranthesisCollection = { '{', '}', '(', ')', '[', ']' };

        public void breakInToTokens(ArrayList tokenList)
        {
            for (int i = 0; i < tokenList.Count; i++)
            {
                bool found = false;
                Token token = (Token)tokenList[i];

                if (token.Type == TokenType.UNDEFINED)
                {
                    char[] content = token.Value.ToCharArray();

                    foreach (char p in paranthesisCollection)
                    {
                        if (p == content[0])
                        {
                            found = true;
                            break;
                        }
                    }

                    int lno = token.LineNo;

                    if (found && content.Length == 1)
                    {
                        token.Type = TokenType.PARANTHESIS;
                        continue;
                    }

                    for (int j = 0; j < content.Length; j++)
                    {
                        char p = content[j];

                        for (int z = 0; z < paranthesisCollection.Length; z++)
                        {
                            if (p == paranthesisCollection[z])
                            {
                                if (j == 0)
                                {
                                    Utilities.breakToken(tokenList, i, j, TokenType.PARANTHESIS, TokenType.UNDEFINED, lno);
                                }
                                else if (j == content.Length - 1)
                                {
                                    Utilities.breakToken(tokenList, i, j, TokenType.UNDEFINED, TokenType.PARANTHESIS, lno);
                                }
                                else
                                {
                                    Utilities.breakToken(tokenList, i, j, TokenType.UNDEFINED, TokenType.UNDEFINED, lno);
                                }

                                break;
                            }
                        }
                    }
                    //for (int j = 0; j < content.Length; j++)
                    //{
                    //    char p = content[j];
                    //    foreach (char pt in paranthesisCollection)
                    //    {

                    //        if (p == pt)
                    //        {
                    //            if (found)
                    //            {
                    //                // Utilities.breakToken(tokenList, i, j, TokenType.PARANTHESIS, TokenType.UNDEFINED, lno);

                    //                token.Value = token.Value.Substring(0, j);
                    //                token.Type = TokenType.PARANTHESIS;

                    //                Token token2 = new Token(TokenType.UNDEFINED, token.LineNo, token.Value.Substring(j));
                    //                tokenList.Insert(i + 1, token2);
                    //                break;
                    //            }
                    //            else
                    //            {
                    //                token.Value = token.Value.Substring(0, j);
                    //                token.Type = TokenType.UNDEFINED;

                    //                Token token2 = new Token(TokenType.UNDEFINED, token.LineNo, token.Value.Substring(j));
                    //                tokenList.Insert(i + 1, token2);
                    //                break;
                    //                //Utilities.breakToken(tokenList, i, j, TokenType.UNDEFINED, TokenType.UNDEFINED, lno);
                    //                // break;
                    //            }
                    //        }
                    //    }

                    //if (found)
                    //{
                    //    Utilities.breakToken(tokenList, i, 1, TokenType.PARANTHESIS, TokenType.UNDEFINED, lno);
                    //    break;
                    //}
                    //else
                    //{
                    //    foreach (char pt in paranthesisCollection)
                    //    {
                    //        if (p == pt)
                    //        {
                    //            Utilities.breakToken(tokenList, i, j, TokenType.UNDEFINED, TokenType.UNDEFINED, lno);
                    //            break;
                    //        }
                    //    }
                    //}

                    //}
                }
            }

        }
    }
}
