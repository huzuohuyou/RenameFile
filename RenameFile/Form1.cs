using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace RenameFile
{
    public partial class Form1 : Form
    {
        private FileInfo[] fiarray = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            fbd_file.ShowDialog();
            DirectoryInfo di = new DirectoryInfo(fbd_file.SelectedPath);
            fiarray = di.GetFiles();
            foreach (FileInfo item in fiarray)
            {
                richTextBox1.Text += item.Name + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(null, "确定重命名所有文件", "确定", MessageBoxButtons.OKCancel))
            {
                try
                {
                    RenameFile(fbd_file.SelectedPath);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

            }
        }

        public void RenameFile(string p_strFileDir)
        {
            richTextBox1.Text = "";
            foreach (FileInfo item in fiarray)
            {
                Computer c = new Computer();
                string s = Guid.NewGuid().ToString();
                c.FileSystem.RenameFile(item.FullName, s+"."+item.Extension);
                richTextBox1.Text += s + "." + item.Extension + "\n";
            }
        }
    }
}
