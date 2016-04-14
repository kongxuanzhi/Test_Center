using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


    public partial class InfoForm : Form
    {

        string msg = "";

        public InfoForm()
        {
            InitializeComponent();
        }

        public InfoForm(string str)
        {
            InitializeComponent();
            this.msg = str;
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            label1.Text = msg;
        }

        public void setMsg(string msg)
        {
            label1.Text = msg;
        }

    }