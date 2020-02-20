﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class OrderSet : Form
    {
        private string  filepath="", language = "china";
     
        public OrderSet()
        {
            InitializeComponent();
        }
        public string filepathset
        {
            set
            {
                filepath = value;
            }
        }

        public string china_L2
        {
            set
            {
                language = value;
                label1.Text = "工单编号";
                label2.Text = "数量";
             
            }
        }

        public string English_L2
        {
            set
            {
                language = value;
                label1.Text = "Work Order";
                label2.Text = "Quantity";

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool nook=false;
            Regex regnum = new Regex("^([0-9]{1,})$");
            string filename="",filename2="";
            FileStream savedata;
            StreamWriter sw3;
            filename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
            if (regnum.IsMatch(textBox2.Text))
            {
                if (textBox1.Text.IndexOf("-") != -1)
                { nook = true; }
                else { MessageBox.Show("格式错误"); }
            }
            else { MessageBox.Show("数量设置错误"); }
            
            if (nook == true)
            {
                if (!File.Exists(filename))
                {
                    savedata = new FileStream(filename, FileMode.Create);
                    sw3 = new StreamWriter(savedata);
                    sw3.Write("No:" + textBox2.Text + "\r\n");
                    sw3.Flush();
                    //关闭流
                    sw3.Close();
                    savedata.Close();
                    filename2 = filepath + "\\" + textBox1.Text.ToUpper() + "_No" + ".txt";
                    savedata = new FileStream(filename2, FileMode.Create);
                    sw3 = new StreamWriter(savedata);
                    sw3.Write("0");
                    sw3.Flush();
                    //关闭流
                    sw3.Close();
                    savedata.Close();
                    this.Close();
                    //  File.SetAttributes(filename2, FileAttributes.ReadOnly); /*File.SetAttributes(filename2, FileAttributes.Hidden); */File.SetAttributes(filename, FileAttributes.ReadOnly); /*File.SetAttributes(filename, FileAttributes.Hidden);*/
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                }
                else
                {
                    MessageBox.Show("工单号重复");
                }
            }

        }

       














    }
}
