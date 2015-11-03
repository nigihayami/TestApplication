using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Part2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.customDataGridView1.UserName = "det";
            this.customDataGridView1.FrameId = 1;

            this.customDataGridView1.ReloadColumnView();
        }
    }
}
