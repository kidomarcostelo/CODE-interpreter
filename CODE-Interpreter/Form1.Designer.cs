namespace CODE_Interpreter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.terminal = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 336);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 387);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Terminal";
            // 
            // terminal
            // 
            this.terminal.Location = new System.Drawing.Point(41, 410);
            this.terminal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.terminal.Name = "terminal";
            this.terminal.Size = new System.Drawing.Size(628, 137);
            this.terminal.TabIndex = 7;
            this.terminal.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.textBox1.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.textBox1.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.textBox1.BackBrush = null;
            this.textBox1.CharHeight = 14;
            this.textBox1.CharWidth = 8;
            this.textBox1.CurrentPenSize = 3;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBox1.DocumentPath = null;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.textBox1.IsReplaceMode = false;
            this.textBox1.Location = new System.Drawing.Point(42, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.textBox1.SelectionChangedDelayedEnabled = false;
            this.textBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textBox1.ServiceColors")));
            this.textBox1.Size = new System.Drawing.Size(627, 286);
            this.textBox1.TabIndex = 8;
            this.textBox1.Zoom = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 574);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.terminal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox terminal;
        private FastColoredTextBoxNS.FastColoredTextBox textBox1;
    }
}

