using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }
    public partial class Form1 : Form , IMainForm
    {
        public Form1()
        {
            InitializeComponent();
            btOpen.Click += new EventHandler(btOpen_Click);
            btSave.Click += new EventHandler(btSave_Click);
            btSelect.Click += new EventHandler(btSelect_Click);
            tbContent.TextChanged += tbContent_TextChanged;
            numFont.ValueChanged += numFont_ValueChanged;
        }

        /// <summary>
        /// Изменение контента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbContent_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null)
            {
                ContentChanged(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Открытие
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOpen_Click(object sender, EventArgs e)
        {
            if(FileOpenClick != null)
            {
                FileOpenClick(this, EventArgs.Empty);
            }
        }

        public string FilePath
        {
            get { return tbFilePath.Text; }
        }
        public string Content
        {
            get { return tbContent.Text; }
            set { tbContent.Text = value; }
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;

        /// <summary>
        /// Выбор файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = dlg.FileName;
                if(FileOpenClick != null)
                {
                    FileOpenClick(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Сохранение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null)
            {
                FileSaveClick(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Шрифт контента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numFont_ValueChanged(object sender, EventArgs e)
        {
            tbContent.Font = new Font("Calibri", (float)numFont.Value);
        }
    }
}
