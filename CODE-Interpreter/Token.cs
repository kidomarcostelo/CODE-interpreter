using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_Interpreter
{
    /// <summary>
    /// Class for token
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Token <T>
    {
        private TokenTypes _type;
        private string _lexeme;
        private T _literal;
        private int _line;

        public Token(TokenTypes type, string lexeme, T literal, int line)
        {
            type = _type;
            lexeme = _lexeme;
            literal = _literal;
            line = _line;
        }

        public TokenTypes Type { get; }

        public string Lexeme { get; }

        public T Literal { get; }

        public int Line { get; }
    }
}
