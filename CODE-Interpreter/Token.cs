using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CODE_Interpreter
{
    /// <summary>
    /// Class for token
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Token
    {
        // Temporary, e string si literal
        private readonly TokenTypes _type;
        private readonly string _lexeme;
        private readonly string _literal;
        private readonly int _line;

        public Token(TokenTypes type, string lexeme, string literal, int line)
        {
            _type = type;
            _lexeme = lexeme;
            _literal = literal;
            _line = line;
        }

        public TokenTypes Type { get => _type; }

        public string Lexeme { get => _lexeme; }

        public string Literal { get => _literal; }

        public int Line { get => _line; }

        public override string ToString()
        {
            return $"Token Type: {_type}\n Lexeme: {_lexeme}\n Literal: {_literal}\n Line: {_line}\n";
        }
    }
}
