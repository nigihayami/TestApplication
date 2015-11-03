using Part2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Part2.Windows
{
    public partial class EditColumnWindow : Form
    {
        private IList<ColumnModel> modelVisible = new List<ColumnModel> { };
        private IList<ColumnModel> modelUnVisible = new List<ColumnModel> { };

        public EditColumnWindow()
        {
            InitializeComponent();

            this.Load += EditColumnWindow_Load;
            this.btnSetVisible.Click += BtnSetVisible_Click;
            this.btnSetUnVisible.Click += BtnSetUnVisible_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnConfirm.Click += BtnConfirm_Click;

            this.listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;
            this.listBox2.SelectedValueChanged += ListBox2_SelectedValueChanged;
            this.btnSaveChanges.Click += BtnSaveChanges_Click;
        }
        /// <summary>
        /// Применить настройку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            foreach(var item in modelUnVisible.Where(a=>a.ColumnName == labelColumnName.Text))
            {
                item.DisplayName = textDisplayName.Text;
                item.ColumnWidth = Convert.ToInt32(textColumnWidth.Text);
            }
            foreach (var item in modelVisible.Where(a => a.ColumnName == labelColumnName.Text))
            {
                item.DisplayName = textDisplayName.Text;
                item.ColumnWidth = Convert.ToInt32(textColumnWidth.Text);
            }
        }

        /// <summary>
        /// При выборе видимой колонки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedValue != null)
            {
                foreach (var item in modelVisible.Where(a => a.ColumnName == listBox2.SelectedValue.ToString()))
                {
                    textDisplayName.Text = item.DisplayName;
                    textColumnWidth.Text = item.ColumnWidth.ToString();
                    labelColumnName.Text = item.ColumnName;
                }
            }
        }

        /// <summary>
        /// При выборе - Отобразим часть информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedValue != null)
            {
                foreach(var item in modelUnVisible.Where(a=>a.ColumnName == listBox1.SelectedValue.ToString()))
                {
                    textDisplayName.Text = item.DisplayName;
                    textColumnWidth.Text = item.ColumnWidth.ToString();
                    labelColumnName.Text = item.ColumnName;
                }
            }
        }

        /// <summary>
        /// Закрыть форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            using (var db = new dbContext())
            {
                //При закрытии формы мы сохраняем наши параметры
                foreach (var item in modelVisible)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //При закрытии формы мы сохраняем наши параметры
                foreach (var item in modelUnVisible)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        /// <summary>
        /// Сделать колонку невидимой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetUnVisible_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedValue != null)
            {
                foreach (var item in modelVisible.Where(a => a.ColumnName == listBox1.SelectedValue.ToString()))
                {
                    item.IsVisible = false;
                    modelUnVisible.Add(item);
                }
                var t = modelVisible.Single(a => a.ColumnName == listBox2.SelectedValue.ToString());
                modelVisible.Remove(t);

                ResetListBox();
            }
        }

        /// <summary>
        /// Перенести колонку в видимую часть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetVisible_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue != null)
            {
                foreach (var item in modelUnVisible.Where(a => a.ColumnName == listBox1.SelectedValue.ToString()))
                {
                    item.IsVisible = true;
                    modelVisible.Add(item);
                }
                var t = modelUnVisible.Single(a => a.ColumnName == listBox1.SelectedValue.ToString());
                modelUnVisible.Remove(t);

                ResetListBox();
            }
        }
        /// <summary>
        /// До загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditColumnWindow_Load(object sender, EventArgs e)
        {
            using (var db = new dbContext())
            {
                var t = from el in db.TColumn
                        where el.UserId.UserName == userName &&
                                el.FrameId.Id == frameId &&
                                el.ComponentGuid.ToString() == componentGuid
                        select el;
                modelVisible = t.Where(a => a.IsVisible).OrderBy(a => a.Position).ToList();
                modelUnVisible = t.Where(a => !a.IsVisible).OrderBy(a => a.Position).ToList();

                ResetListBox();
            }
        }
        /// <summary>
        /// Перезагрузка контекста для списков
        /// </summary>
        private void ResetListBox()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;

            listBox1.DisplayMember = "DisplayName";
            listBox1.ValueMember = "ColumnName";

            listBox2.DisplayMember = "DisplayName";
            listBox2.ValueMember = "ColumnName";

            listBox1.DataSource = modelUnVisible;
            listBox2.DataSource = modelVisible;
        }
    }
}
