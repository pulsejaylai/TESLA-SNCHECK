﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void Password_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 1;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string checkword;
            FileStream wordtext, checktext;
            if (textBox1.Text=="ftp2019")
            {
                checktext = new FileStream("d:\\dcheck.txt", FileMode.Create);
                StreamWriter checkok = new StreamWriter(checktext); checkok.Write("FTPPASS"); checkok.Flush(); checkok.Close(); checktext.Close();
                this.Close();
            }
            if (textBox1.Text!="ftp2019")
            {
                MessageBox.Show("PassWord Err");
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                e.Handled = true;   //将Handled设置为true，指示已经处理过KeyPress事件
                                    // button1.PerformClick();////执行单击confirm1的动作
                button1_Click(button1, EventArgs.Empty);
            }
        }

    }
}
