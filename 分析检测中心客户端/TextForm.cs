using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
        }


        public void appendText(string str)
        {
            textBox1.AppendText(str);
            textBox1.AppendText("\n");
        }

        public void append(string str)
        {
            textBox1.AppendText(str);
        }

    }
