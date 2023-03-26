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

            // does not begin with BEGIN CODE
            if (_tokens.First().Type != TokenTypes.BEGIN_CODE)
            {
                // basin inig print sa error mas nice if ma display ang line
                _errorMessages.Add("TMP error->Code must start with \"BEGIN CODE\"");
            }

            // does not end with END CODE
            if (_tokens.Last().Type != TokenTypes.END_CODE)
            {
                _errorMessages.Add("TMP error->Code must start with \"END CODE\"");
            }
            // ari ang loop
                //
            //

            return _errorMessages.Count();
        }

    }
}
