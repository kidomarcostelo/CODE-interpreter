using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CODE_Interpreter
{
    /// <summary>
    /// Kani na class kay serves as the interpreter pipepline, ari e process tanab processes
    /// </summary>
    internal class Interpreter
    {
        private string _code;
        private Lexer _lexer;
        private Parser _parser;

        private  List<string> _errorMessages;
        public Interpreter(string code)
        { 
            _code = code;
            _lexer = new Lexer(code);
        }

        public List<string> ErrorMessages { get => _errorMessages; }
        // temporary name
        public bool Interpret()
        {
            int error;
            _parser = new Parser(_lexer.Tokenize());
            error =  _parser.Parse();

            if (error == 0)
            {
                return true;
            }

            else
            {
                _errorMessages = _parser.ErrorMessages;
                return false;
            }
        }
    }
}
