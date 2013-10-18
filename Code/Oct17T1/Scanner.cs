// -----------------------------------------------------------------------
// <copyright file="Scanner.cs" company="Microsoft">
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

    public sealed class Scanner
    {
        private string content;
        private ArrayList tokenList;

        private TokenBreaker[] tokenBreakers = { new CommentBreaker() , new SpaceBreaker(), new OperatorBreaker(), new KeywordBreaker()};

        public Scanner(string myfile)
        {
            content = myfile;
            tokenList = new ArrayList();
            Token startToken = new Token(TokenType.UNDEFINED, 1, content);
            tokenList.Add(startToken);
        }

        public void Strater()
        {
            foreach (TokenBreaker tk in tokenBreakers)
            {
                 tk.breakInToTokens(tokenList);
            }

            foreach (Object o in tokenList)
            {
                Console.WriteLine(o);
            }
        }
    }
}
