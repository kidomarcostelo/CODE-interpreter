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
        /// Returns pila ka errors, 0 if no errors
        /// </summary>
        public int Parse()
        {
            /*if (_tokens.Count == 0)
            {
                _errorMessages.Add("Code must start with \"BEGIN CODE\"");
                _errorMessages.Add("Code must end with \"END CODE\"");
                //return _errorMessages.Count();

            }*/

            // not efficient?
            // di ko sure if ari mag butang ug error message, or sa interpreter
            // feel nako ang parser kay purely parse, so no matter unsa na dira dili siya dapat mo care kung unsa iyahang gi parse
            // kay ang interpreter class ra mo verify sa unsa iyaha gi parse?

            // ay joke parser man diay ni so siya diay mo verify sa mga tokens
            // ang interpreter class kay siya ra mag compile tanan, mura adto ang pipeline
            if (_tokens.FirstOrDefault() == null)
            {
                // basin inig print sa error mas nice if ma display ang line
                _errorMessages.Add("TMP error->Code must start with \"BEGIN CODE\"");
                _errorMessages.Add("TMP error->Code must end with \"END CODE\"");
            }


            // ari ang loop
                //
            //

            return _errorMessages.Count();
        }

    }
}
