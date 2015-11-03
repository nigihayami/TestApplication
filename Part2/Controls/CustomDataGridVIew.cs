using Part2.Models;
using Part2.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Part2.Controls
{
    public class CustomDataGridView : DataGridView
    {
        public int FrameId { get; set; }
        public string UserName { get; set; }
        public string ComponentGuid
        {
            get
            {
                return "85222392-2D0C-4851-94AC-078A7D5DE9A0";
            }
        }

        private ContextMenuStrip subMenu = new ContextMenuStrip();

        public CustomDataGridView()
        {
            InitSubMenu();

            ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            ContextMenuStrip = subMenu;
        }

        /// <summary>
        /// Настраиваем Наше меню
        /// </summary>
        private void InitSubMenu()
        {
            subMenu.Items.Add("Колонки");

            subMenu.Items[0].Click += EditColumn;
        }
        /// <summary>
        /// Настроить колонки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditColumn(object sender, EventArgs e)
        {
            var t = new EditColumnWindow(FrameId, UserName, ComponentGuid);
            if (t.ShowDialog() == DialogResult.OK)
            {
                ReloadColumnView();
            }
        }
        /// <summary>
        /// Очередность и видимость колонок
        /// </summary>
        public void ReloadColumnView()
        {
            this.Columns.Clear();
            
            using (var db = new dbContext())
            {
                var t = from e in db.TColumn
                        where e.FrameId.Id == FrameId &&
                                e.UserId.UserName == UserName &&
                                e.ComponentGuid.ToString() == ComponentGuid
                        orderby e.Position
                        select e;
                foreach (var item in t)
                {
                    Columns.Add(new DataGridViewTextBoxColumn { Name = item.ColumnName,
                        HeaderText = item.DisplayName,
                        Width = item.ColumnWidth,
                        Visible = item.IsVisible });
                }
            }
        }
    }
}
