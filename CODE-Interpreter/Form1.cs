using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace CODE_Interpreter
{
    public partial class Form1 : Form
    {
        //test implement
        private Interpreter _interpreter;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _interpreter = new Interpreter(textBox1.Text);

             bool isSuccessful = _interpreter.Interpret();

            if (isSuccessful)
            {
                terminal.Text = "TEMP msg -> Program running successfully";
            }
            else
            {
                terminal.Text = string.Join("\n", _interpreter.ErrorMessages);
            }


        }
    }
}
