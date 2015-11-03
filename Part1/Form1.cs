using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Part1
{
    public partial class Form1 : Form
    {
        private List<string> model = new List<string> { };
        public Form1()
        {
            InitializeComponent();
            model.Add("Hello");
            model.Add("Hello");
            model.Add("Hello");
            model.Add("Hello");

            this.customDataGridView1.DataSource = model;
        }
    }
}
