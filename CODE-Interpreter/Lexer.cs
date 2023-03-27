using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace CODE_Interpreter
{
    /// <summary>
    /// Breaking the input strings into tokesn
    /// </summary>
    internal class Lexer
    {
        private readonly List<Token> _tokens;
        private readonly string[] _lines;
        private List<string> errorMessage;
        private static int lineNum;
        private readonly string[] code;
        private string currString;
        private int currStringLength;
        private int charCtr;

        public List<Token> Tokens { get { return _tokens; } set { Tokens = _tokens; } }
        
        /// <summary>
        /// Receives the whole code 
        /// </summary>
        /// <param name="code"></param>
        public Lexer(string code)
        {
            _tokens = new List<Token>();
            _lines = SplitByLine(code);
            foreach (var line in _lines)
            {
                // Ignore comments
                if (line.StartsWith("#"))
                {
                    continue;
                }
                lineNum = 0;
            }
        }

        public int Analyze()
        {
            int i = 0;
            while (i < code.Length)
            {
                AnalyzeLine();
                lineNum++;
                i++;
                charCtr = 0;
            }
            return errorMessage.Count != 0 ? 1 : 0;
        }

        private void AnalyzeLine()
        {
            int tokenCtr = 0;
            currString = code[lineNum];
            currStringLength = currString.Length;

            while (charCtr < currStringLength)
            {
                char x = currString[charCtr];
                switch (x)
                {
                    case '=':
                        if (getNextChar() == '=')
                        {
                            string temp = "" + x + getNextChar();
                            _tokens.Add(new Token(TokenTypes.EQUAL, "==", null, lineNum));
                            charCtr += 2;
                        }
                        else
                        {
                            _tokens.Add(new Token(TokenTypes.EQUALS, x.ToString(), null, lineNum));
                            charCtr++;
                        }
                        break;
                    case ',':
                        _tokens.Add(new Token(TokenTypes.COMMA, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case ':':
                        _tokens.Add(new Token(TokenTypes.COLON, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case '"':
                        _tokens.Add(new Token(TokenTypes.DOUBLE_QUOTE, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case ' ':
                        charCtr++;
                        break;
                    case '+':
                        _tokens.Add(new Token(TokenTypes.ADD, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case '-':
                        _tokens.Add(new Token(TokenTypes.SUBT, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case '/':
                        _tokens.Add(new Token(TokenTypes.DIV, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case '*':
                        tokenCtr = _tokens.Count;
                        if (charCtr == 0 || _tokens[tokenCtr - 1].Line != lineNum)
                        {
                            while (charCtr != currStringLength) { charCtr++; }
                        }
                        else
                        {
                            _tokens.Add(new Token(TokenTypes.MULT, x.ToString(), null, lineNum));
                            charCtr++;
                        }
                        break;
                    case '(':
                        _tokens.Add(new Token(TokenTypes.LEFT_PAREN, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case ')':
                        _tokens.Add(new Token(TokenTypes.RIGHT_PAREN, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case '>':
                        if (getNextChar() == '=')
                        {
                            string temp = "" + x + getNextChar();
                            _tokens.Add(new Token(TokenTypes.GREATER_EQUAL, temp, null, lineNum));
                            charCtr += 2;
                        }
                        else
                        {
                            _tokens.Add(new Token(TokenTypes.GREATER, x.ToString(), null, lineNum));
                            charCtr++;
                        }
                        break;
                    case '<':
                        if (getNextChar() == '=')
                        {
                            string temp = "" + x + getNextChar();
                            _tokens.Add(new Token(TokenTypes.LESSER_EQUAL, temp, null, lineNum));
                            charCtr += 2;
                        }
                        else if (getNextChar() == '>')
                        {
                            _tokens.Add(new Token(TokenTypes.NOT_EQUAL, "<>", null, lineNum));
                            charCtr += 2;
                        }
                        else
                        {
                            _tokens.Add(new Token(TokenTypes.LESSER, x.ToString(), null, lineNum));
                            charCtr++;
                        }
                        break;
                    case '%':
                        _tokens.Add(new Token(TokenTypes.MOD, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case '&':
                        _tokens.Add(new Token(TokenTypes.AMPERSAND, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case '#':
                        _tokens.Add(new Token(TokenTypes.SHARP, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case '[':
                        _tokens.Add(new Token(TokenTypes.LEFT_BRACE, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                    case ']':
                        _tokens.Add(new Token(TokenTypes.RIGHT_BRACE, x.ToString(), null, lineNum));
                        charCtr++;
                        break;
                        //default here
                }
            }
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
                /*if (_lines[lineNumber] == "#")
                {
                    _tokens.Add(new Token(TokenTypes.BEGIN_CODE, _lines[lineNumber], null, lineNumber + 1));
                    continue;
                }*/

                // if line ==  BEGIN CODE
                if (_lines[lineNumber].TrimEnd().StartsWith("BEGIN CODE") || _lines[lineNumber].TrimEnd().Length > "BEGIN CODE".Length && _lines[lineNumber].TrimEnd()[_lines[lineNumber].TrimEnd().Length - 1] == '#')
                {
                    _tokens.Add(new Token(TokenTypes.BEGIN_CODE, "BEGIN CODE", null, lineNumber + 1));
                    continue;
                }
                
                // if lines == END CODE
                else if (_lines[lineNumber].TrimEnd().StartsWith("END CODE") || _lines[lineNumber].TrimEnd().Length > "END CODE".Length && _lines[lineNumber].TrimEnd()[_lines[lineNumber].TrimEnd().Length - 1] == '#')
                {
                    _tokens.Add(new Token(TokenTypes.END_CODE, "END CODE", null, lineNumber + 1));
                    continue;
                }

                words = _lines[lineNumber].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                /*for (int i = 0; i < words.Length; i++)
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
                }*/
                // -- DATATYPES -- 
                if (words.ElementAt(0) == "INT")
                {
                    _tokens.Add(new Token(TokenTypes.INT, words.ElementAt(0), null, lineNumber + 1));
                    if (IsValidVarName(words.ElementAt(1)) && !(VarNameAlreadyExists(_tokens, words.ElementAt(1))))
                    {
                        _tokens.Add(new Token(TokenTypes.INT_VAR, words.ElementAt(1), null, lineNumber + 1));
                        lineNumber++;
                    }
                    continue;
                }

                if (words.ElementAt(0) == "CHAR")
                {
                    _tokens.Add(new Token(TokenTypes.CHAR, words.ElementAt(0), null, lineNumber + 1));
                    if (IsValidVarName(words.ElementAt(1)) && !(VarNameAlreadyExists(_tokens, words.ElementAt(1))))
                    {
                        _tokens.Add(new Token(TokenTypes.CHAR_VAR, words.ElementAt(1), null, lineNumber + 1));
                        lineNumber++;
                    }
                    continue;
                }

                if (words.ElementAt(0) == "BOOL")
                {
                    _tokens.Add(new Token(TokenTypes.BOOL, words.ElementAt(0), null, lineNumber + 1));
                    if (IsValidVarName(words.ElementAt(1)) && !(VarNameAlreadyExists(_tokens, words.ElementAt(1))))
                    {
                        _tokens.Add(new Token(TokenTypes.BOOL_VAR, words.ElementAt(1), null, lineNumber + 1));
                        lineNumber++;
                    }
                    continue;
                }

                if (words.ElementAt(0) == "FLOAT")
                {
                    _tokens.Add(new Token(TokenTypes.FLOAT, words.ElementAt(0), null, lineNumber + 1));
                    if (IsValidVarName(words.ElementAt(1)) && !(VarNameAlreadyExists(_tokens, words.ElementAt(1))))
                    {
                        _tokens.Add(new Token(TokenTypes.FLOAT_VAR, words.ElementAt(1), null, lineNumber + 1));
                        lineNumber++;
                    }
                    continue;
                }
                // -- DATATYPES -- END
            }
            return _tokens;
        }

        /// <summary>
        /// Checks if a given variable name iwas tokenized.
        /// </summary>
        /// <param name="tokens">List of tokens to be checked.</param>
        /// <param name="temp">Variable name to be checked.</param>
        /// <returns>Returns true if a string is already tokenized as a variable.</returns>
        private bool VarNameAlreadyExists(List<Token> tokens, String temp)
        {
            foreach (Token token in tokens)
            {
                if (token.Lexeme == temp)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if a given string is a valid variable name.
        /// </summary>
        /// <param name="word">The string to check whether it is valid variable name or not.</param>
        /// <returns>Returns true if the given string is valid variable name.</returns>
        private bool IsValidVarName(string word)
        {
            if (isDigit(word.First()))
            {
                return false;
            }

            switch (word)
            {
                case "BEGIN CODE":
                    return false;
                case "END CODE":
                    return false;
                case "CHAR":
                    return false;
                case "INT":
                    return false;
                case "FLOAT":
                    return false;
                case "BOOL":
                    return false;
                case "SCAN":
                    return false;
                case "DISPLAY":
                    return false;
                case "IF":
                    return false;
                case "WHILE":
                    return false;
                case "ELSE":
                    return false;
                case "AND":
                    return false;
                case "OR":
                    return false;
                case "NOT":
                    return false;
                case "TRUE":
                    return false;
                case "FALSE":
                    return false;
            }

            return true;
        }

        //Skips the reserved words at the same time mucheck if identifier/variable name sya
        private void isIdentifier(char x)
        {
            string temp = "";
            while (isAlpha(x) || isDigit(x))
            {
                temp += x;
                x = getNextChar();
                charCtr++;
            }
            switch (temp)
            {
                case "BEGIN CODE":
                    _tokens.Add(new Token(TokenTypes.BEGIN_CODE, temp, null, lineNum));
                    break;
                case "END CODE":
                    _tokens.Add(new Token(TokenTypes.END_CODE, temp, null, lineNum));
                    break;
                case "CHAR":
                    _tokens.Add(new Token(TokenTypes.CHAR, temp, null, lineNum));
                    //error condtn here
                    break;
                case "INT":
                    _tokens.Add(new Token(TokenTypes.INT, temp, null, lineNum));
                    //error condtn here
                    break;
                case "FLOAT":
                    _tokens.Add(new Token(TokenTypes.FLOAT, temp, null, lineNum));
                    //error condtn here
                    break;
                case "BOOL":
                    _tokens.Add(new Token(TokenTypes.BOOL, temp, null, lineNum));
                    break;
                case "SCAN":
                    _tokens.Add(new Token(TokenTypes.SCAN, temp, null, lineNum));
                    break;
                case "DISPLAY":
                    _tokens.Add(new Token(TokenTypes.DISPLAY, temp, null, lineNum));
                    break;
                case "IF":
                    _tokens.Add(new Token(TokenTypes.IF, temp, null, lineNum));
                    break;
                case "WHILE":
                    _tokens.Add(new Token(TokenTypes.WHILE, temp, null, lineNum));
                    break;
                case "ELSE":
                    _tokens.Add(new Token(TokenTypes.ELSE, temp, null, lineNum));
                    break;
                case "AND":
                    _tokens.Add(new Token(TokenTypes.AND, temp, null, lineNum));
                    break;
                case "OR":
                    _tokens.Add(new Token(TokenTypes.OR, temp, null, lineNum));
                    break;
                case "NOT":
                    _tokens.Add(new Token(TokenTypes.NOT, temp, null, lineNum));
                    break;
                case "TRUE":
                    temp = "True";
                    _tokens.Add(new Token(TokenTypes.BOOL_VAR, temp, null, lineNum));
                    break;
                case "FALSE":
                    temp = "False";
                    _tokens.Add(new Token(TokenTypes.BOOL_VAR, temp, null, lineNum));
                    break;
                default: //IDENTIFIER PART
                    _tokens.Add(new Token(TokenTypes.IDENTIFIER, temp, null, lineNum));
                    break;
            }
        }

        private bool isAlpha(char x)
        {
            return ((x == '_') || (x >= 'a' && x <= 'z') || (x >= 'A' && x <= 'Z'));
        }

        private bool isDigit(char x)
        {
            return x >= '0' && x <= '9';
        }

        public char getNextChar()
        {
            return charCtr + 1 < currStringLength ? currString[charCtr + 1] : '|';
        }
    }
}
