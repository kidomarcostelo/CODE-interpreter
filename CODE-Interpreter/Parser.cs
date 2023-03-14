using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_Interpreter
{
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
        /// for now bool
        /// </summary>
        public int Parse()
        {
            if (_tokens.Count == 0)
            {
                return 0;
            }

            // not efficient?
            if (_tokens.First().Type != TokenTypes.BEGIN_CODE)
            {
                _errorMessages.Add("Code must begin with START CODE");
            }

            if (_tokens.Last().Type != TokenTypes.END_CODE)
            {

                _errorMessages.Add("Code must end with END CODE");
            }

            // ari ang loop
            return _errorMessages.Count();
        }

    }
}
