using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_Interpreter
{
    public enum TokenTypes
    {
        //Character tokens
        DOUBLE_QUOTE, SINGLE_QUOTE, // " '
        COMMA, EQUALS, COLON,  // , =  :

        //Comment
        SHARP, //#

        //Escape character
        SPACE, DOLLAR, AMPERSAND, LEFT_BRACE, RIGHT_BRACE, //  $ & []

        //Arithmetic Operators
        LEFT_PAREN, RIGHT_PAREN, //()
        MULT, ADD, SUBT, DIV, MOD, //* + - / %
        GREATER, LESSER, // > <
        GREATER_EQUAL, LESSER_EQUAL, // >= <=
        EQUAL, NOT_EQUAL, // == <>

        //Logical
        AND, OR, NOT,

        //Variables
        IDENTIFIER, 
        CHAR_VAR, 
        INT_VAR, 
        FLOAT_VAR, 
        BOOL_VAR,

        //Reserved Words
        BEGIN, END, CODE,
        SCAN, DISPLAY,
        IF, ELSE, WHILE, 
        INT, BOOL, FLOAT, CHAR,
        TRUE, FALSE,
    }
}
