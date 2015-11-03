using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Part4.Controls
{
    public class CustomDataGridView : DataGridView
    {
        private bool IsHide;
        public CustomDataGridView()
        {

        }
        public void HideColumn()
        {
            IsHide = !IsHide;
            foreach(var item in Columns)
            {
                if (item.GetType() == typeof(DataGridViewTextBoxColumn2))
                {
                    if (((DataGridViewTextBoxColumn2)item).CanSwitch)
                    {
                        ((DataGridViewTextBoxColumn2)item).Visible = !IsHide;
                    }
                }
            }
        }
    }

    public class DataGridViewTextBoxColumn2 : DataGridViewTextBoxColumn
    {
        public bool CanSwitch { get; set; }
        public DataGridViewTextBoxColumn2()
        {

        }
    }
}
