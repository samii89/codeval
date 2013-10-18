// -----------------------------------------------------------------------
// <copyright file="CommentBreaker.cs" company="Microsoft">
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
    public class CommentBreaker:TokenBreaker
    {
        public void breakInToTokens(ArrayList tokenList)
        {
            //implentation
            //put the elements to a char array
            //check the elements one by one to see whether a comment exisits
            //obtain the end of line by chaecking \n
            // now hv 3 parts

            int lno = 1;

            for (int i = 0; i < tokenList.Count; i++)
            {
                Token token = (Token)tokenList[i];
                bool over = false;

                if (token.Type == TokenType.UNDEFINED)
                {
                    char[] content = token.Value.ToCharArray();
                    int size = content.Length;

                    for (int j = 0; j < size && !over; j++)
                    {
                        if (content[j] == '/')
                        {
                            int startcomment = j;

                            if (j + 1 < content.Length && content[j + 1] == '/')
                            {
                                for (j = j + 1; j < size; j++)
                                {
                                    if (content[j] == '\n')
                                    {
                                        int endcomment = j + 1;
                                        if (startcomment == 0)
                                        {
                                            // tokenList.Insert(i, (new Token(TokenType.COMMENT, lno, token.Value.Substring(startcomment, (endcomment - startcomment)))));
                                            tokenList.Insert(i + 1, new Token(TokenType.UNDEFINED, lno + 1, token.Value.Substring(endcomment)));
                                            token.Value = token.Value.Substring(0, (endcomment - startcomment));
                                            token.Type = TokenType.COMMENT;
                                        }
                                        else
                                        {
                                            tokenList.Insert(i + 1, (new Token(TokenType.COMMENT, lno, token.Value.Substring(startcomment, (endcomment - startcomment)))));
                                            tokenList.Insert(i + 2, new Token(TokenType.UNDEFINED, lno + 1, token.Value.Substring(endcomment)));
                                            token.Value = token.Value.Substring(0, startcomment);

                                        }
                                        lno++;
                                        over = true;
                                        break;
                                    }


                                }
                            }
                            //check /* */
                            else if (content[j + 1] == '*')
                            {
                                int startline = lno;
                                for (j = j + 1; j < size; j++)
                                {
                                    if (content[j] == '*' && content[j + 1] == '/')
                                    {
                                        int endcomment = j + 2;

                                        tokenList.Insert(i + 1, (new Token(TokenType.COMMENT, startline, token.Value.Substring(startcomment, (endcomment - startcomment)))));
                                        tokenList.Insert(i + 2, new Token(TokenType.UNDEFINED, lno, token.Value.Substring(endcomment)));
                                        token.Value = token.Value.Substring(0, startcomment);
                                        over = true;
                                        break;

                                    }
                                    else if (content[j] == '\n')
                                    {
                                        lno++;
                                    }
                                }
                            }
                        }
                        //check "" 
                        else if (content[j] == '"')
                        {
                            int startcomment = j;

                            for (j = j + 1; j < size; j++)
                            {
                                if (content[j] == '"' && content[j - 1] != '\\')
                                {
                                    int endcomment = j + 1;
                                    if (startcomment == 0)
                                    {

                                        tokenList.Insert(i + 1, new Token(TokenType.UNDEFINED, lno, token.Value.Substring(endcomment)));
                                        token.Value = token.Value.Substring(0, (endcomment - startcomment));
                                        token.Type = TokenType.STRING;

                                    }
                                    else
                                    {
                                        tokenList.Insert(i + 1, (new Token(TokenType.STRING, lno, token.Value.Substring(startcomment, (endcomment - startcomment)))));
                                        tokenList.Insert(i + 2, new Token(TokenType.UNDEFINED, lno, token.Value.Substring(endcomment)));
                                        token.Value = token.Value.Substring(0, startcomment);

                                    }

                                    over = true;
                                    break;
                                }

                            }
                        }
                        else if (content[j] == '\n')
                        {
                            lno++;
                        }
                    }
                }
            }
        }
    }
}
