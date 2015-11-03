using Part4.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Part4
{
    public partial class Form1 : Form
    {
        private IList<Part4Model> model = new List<Part4Model> { };
        public Form1()
        {
            InitializeComponent();
            customDataGridView1.AutoGenerateColumns = false;
            customDataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "#"
            });
            customDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Column1",
                DataPropertyName = "Column1",
                HeaderText = "Column1"
            });
            customDataGridView1.Columns.Add(new DataGridViewTextBoxColumn2
            {
                Name = "Column2",
                DataPropertyName = "Column2",
                HeaderText = "Column2",
                CanSwitch = true
            });
            customDataGridView1.Columns.Add(new DataGridViewTextBoxColumn2
            {
                Name = "Column3",
                DataPropertyName = "Column3",
                HeaderText = "Column3",
                CanSwitch = false
            });
            InitPart4Model();
            customDataGridView1.DataSource = model;

            this.button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            customDataGridView1.HideColumn();
        }

        private void InitPart4Model()
        {
            model.Add(new Part4Model { Id = 1, Column1 = "1", Column2 = "2", Column3 = "3" });
            model.Add(new Part4Model { Id = 1, Column1 = "1", Column2 = "2", Column3 = "3" });
            model.Add(new Part4Model { Id = 1, Column1 = "1", Column2 = "2", Column3 = "3" });
            model.Add(new Part4Model { Id = 1, Column1 = "1", Column2 = "2", Column3 = "3" });
        }
    }
}
