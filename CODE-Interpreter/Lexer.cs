using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_Interpreter
{
    /// <summary>
    /// Tokenize the code into strings of tokens??
    /// ari kay simply make codes into tokens
    /// </summary>
    internal class Lexer
    {
        private readonly List<Token> _tokens;
        private readonly string[] _lines;
        private string[] errorMessage;

        public List<Token> Tokens { get { return _tokens; } set { Tokens = _tokens; } }
        
        /// <summary>
        /// Receives the whole code 
        /// </summary>
        /// <param name="code"></param>
        public Lexer(string code)
        {
            _tokens = new List<Token>();
            _lines = SplitByLine(code);
        }

        /// <summary>
        /// Reads the entire code and separate them per line
        /// </summary>
        private string[] SplitByLine(string code)
        {
            // separate the code line by line
            string[] lineIdentifier = { "\r\n" };

            // the lines are used to index, for error handling 
            return code.Split(lineIdentifier, StringSplitOptions.RemoveEmptyEntries);

            //return lines;
        }

        /// <summary>
        /// E analyze ang line unya ari kay e make najud each word into token
        /// </summary>
        public List<Token> Tokenize()
        {
            string[] words;
            // temporary pani siya 
            for (int lineNumber = 0; lineNumber < _lines.Length; lineNumber++)
            {
                // use lineNumber for marking a line 

                if (_lines[lineNumber] == "#")
                {
                    _tokens.Add(new Token(TokenTypes.BEGIN_CODE, _lines[lineNumber], null, lineNumber + 1));
                    continue;
                }
                
                if (_lines[lineNumber] == "BEGIN CODE")
                {
                    _tokens.Add(new Token(TokenTypes.BEGIN_CODE, "BEGIN CODE", null, lineNumber + 1));
                    continue;
                }
                else if (_lines[lineNumber] == "END CODE")
                {
                    _tokens.Add(new Token(TokenTypes.END_CODE, "END CODE", null, lineNumber + 1));
                    continue;
                }

                words = _lines[lineNumber].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    switch (words[i])
                    {
                        //case "BEGIN":
                        //    // ERROR if BEGIN lang ang naa sa sentences
                        //    if (words[i + 1] == "CODE")
                        //    {
                        //        _tokens.Add(new Token(TokenTypes.BEGIN_CODE, "BEGIN CODE", null, line + 1));
                        //        _tokenCount++;
                        //    }
                        //    break;
                        //case "END":
                        //    if (words[i + 1] == "CODE")
                        //    {
                        //        _tokens.Add(new Token(TokenTypes.END_CODE, "END CODE", null, line + 1));
                        //        _tokenCount++;
                        //    }
                        //    break;
                    }
                }
            }
            return _tokens;
        }
    }
}
