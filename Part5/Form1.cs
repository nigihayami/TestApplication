using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Part5
{
    public partial class Form1 : Form
    {
        private HashSet<Part5Model> model = new HashSet<Part5Model> { };

        private IList<string> modelCombo = new List<string> { "Id",
                "Column1",
                "Column2",
                "Column3",
                "Column4",
                "Column5"
            };

        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();

            InitDataTable();

            this.comboBox1.DataSource = modelCombo;
            comboBox1.SelectedIndex = 0;


            this.button1.Click += Button1_Click;
            this.button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var columnCount = dt.Columns.Count;
            var rowCount = dt.Rows.Count;
            if (rowCount > 0 && rowCount > numericUpDown3.Value)
            {
                var t = dt.Rows[Convert.ToInt32(numericUpDown3.Value)].Field<object>(comboBox1.SelectedValue.ToString());

                MessageBox.Show(t.ToString());
            }
        }

        /// <summary>
        /// Найти значение по строке и колонке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            var columnCount = dt.Columns.Count;
            var rowCount = dt.Rows.Count;
            if (columnCount > 0 && columnCount > numericUpDown1.Value)
            {
                if (rowCount > 0 && rowCount > numericUpDown2.Value)
                {
                    var t = dt.Rows[Convert.ToInt32(numericUpDown2.Value)].Field<object>(Convert.ToInt32(numericUpDown1.Value));

                    MessageBox.Show(t.ToString());
                }
            }
        }

        private void InitDataTable()
        {
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Column1", typeof(string));
            dt.Columns.Add("Column2", typeof(string));
            dt.Columns.Add("Column3", typeof(string));
            dt.Columns.Add("Column4", typeof(string));
            dt.Columns.Add("Column5", typeof(string));
            for (int i = 0; i <= 50; i++)
            {
                model.Add(new Part5Model
                {
                    Id = i,
                    Column1 = i.ToString(),
                    Column2 = i.ToString(),
                    Column3 = i.ToString(),
                    Column4 = i.ToString(),
                    Column5 = i.ToString()
                });
            }
            foreach (var item in model)
            {
                var t = dt.NewRow();

                t["Id"] = item.Id;
                t["Column1"] = item.Column1;
                t["Column2"] = item.Column2;
                t["Column3"] = item.Column3;
                t["Column4"] = item.Column4;
                t["Column5"] = item.Column5;

                dt.Rows.Add(t);
            }
        }
    }
}
