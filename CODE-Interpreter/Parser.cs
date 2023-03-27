using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_Interpreter
{
    /// <summary>
    /// Analyzes lists of tokens
    /// </summary>
    internal class Parser
    {
        private List<string> _errorMessages;
        private List<Token> _tokens;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _errorMessages = new List<string>();
        }

        public List<string> ErrorMessages { get => _errorMessages; }

        /// <summary>
        /// Di pa sure unsay return value
        /// Returns pila ka errors, 0 if no errors
        /// </summary>
        public int Parse()
        {
            // empty code
            if (_tokens.Count == 0)
            {
                _errorMessages.Add("Code must start with \"BEGIN CODE\"");
                _errorMessages.Add("Code must end with \"END CODE\"");
                return _errorMessages.Count();

            }

            
            if (_tokens.First().Type != TokenTypes.BEGIN_CODE && _tokens.First().Literal.IndexOf("#") < 0 && _tokens.First().Literal.IndexOf("#") > _tokens.First().Literal.Length - 1)
            {
                // basin inig print sa error mas nice if ma display ang line
                _errorMessages.Add("TMP error->Code must start with \"BEGIN CODE\"");
            }

            // Check if the first token's value contains a "#" symbol and text after the "#" symbol
            /*if (_tokens.First().Literal.IndexOf("#") >= 0 && _tokens.First().Literal.IndexOf("#") < _tokens.First().Literal.Length - 1)
            {
                // Add error message with line number
                int lineNumber = _tokens.First().Line;
                _errorMessages.Add($"TMP error -> Code must start with \"BEGIN CODE\". Error found on line {lineNumber}");
            }*/

            // does not end with END CODE
            if (_tokens.Last().Type != TokenTypes.END_CODE)
            {
                _errorMessages.Add("TMP error->Code must start with \"END CODE\"");
            }
            // ari ang loop
            //
            //
            for (int i = 0; i < _tokens.Count; i++)
            {
                var current = _tokens[i];
                var previous = i > 0 ? _tokens[i - 1] : null;
                var next = i < _tokens.Count - 1 ? _tokens[i + 1] : null;

                if (previous != null)
                {
                    if ((previous.Lexeme == "BEGIN CODE" && IsDataType(current) && IsVariableName(next)) || ((IsVariableName(previous)) && IsDataType(current) && IsVariableName(next)))
                    {
                        break;
                    }
                    else
                    {
                        if ((IsDataType(current) || IsVariableName(current)))
                        {
                            _errorMessages.Add("TMP error -> at line (" + current.Line + ") -> Variable declaration must be found after the \"BEGIN CODE\"");
                        }
                    }
                }
            }

            return _errorMessages.Count();
        }

        /// <summary>
        /// Checks if an input token is of type datatype.
        /// </summary>
        /// <param name="token">Token to be checked.</param>
        /// <returns>Returns true if token is of type datatype.</returns>
        private bool IsDataType(Token token)
        {
            return token.Type == TokenTypes.INT || token.Type == TokenTypes.BOOL ||
                token.Type == TokenTypes.FLOAT || token.Type == TokenTypes.CHAR;
        }

        /// <summary>
        /// Checks if an input token is of type variable.
        /// </summary>
        /// <param name="token">Token to be checked.</param>
        /// <returns>>Returns true if token is of type variable.</returns>
        private bool IsVariableName(Token token)
        {
            return token.Type == TokenTypes.INT_VAR || token.Type == TokenTypes.BOOL_VAR ||
                token.Type == TokenTypes.FLOAT_VAR || token.Type == TokenTypes.CHAR_VAR || token.Type == TokenTypes.IDENTIFIER;
        }
    }
}
