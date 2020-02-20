using System;
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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        string savepath="",model="";
        int tabsel = 0;
        SNInput sninput = new SNInput();
        QCheck qc = new QCheck();
        private void m1876ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1817ToolStripMenuItem.Checked = false;
            m1817ToolStripMenuItem.Enabled = false;
            m1818ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Enabled = false;
            m1829ToolStripMenuItem.Checked = false;
            m1829ToolStripMenuItem.Enabled = false;
            m1876ToolStripMenuItem.Checked = true;           
            m0077ToolStripMenuItem.Checked = false;
            m0077ToolStripMenuItem.Enabled = false;
            m0075ToolStripMenuItem.Checked = false;
            m0075ToolStripMenuItem.Enabled = false;
            cToolStripMenuItem.Enabled = false;
            c0079ToolStripMenuItem.Enabled = false;
            model = "M1876";
            savepath = "d:\\TelasSNCheck\\M1876";
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);

            }
            setToolStripMenuItem.Enabled = true;
            langeToolStripMenuItem.Enabled = true;
          //  SNInput sninput = new SNInput();
            this.tabPage1.Controls.Clear();
            sninput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sninput.TopLevel = false; sninput.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(sninput);
            sninput.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
            sninput.filepathset2 = savepath;
            sninput.Modset = model;
            sninput.Show();
          


        }

        private void m1829ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1817ToolStripMenuItem.Checked = false;
            m1817ToolStripMenuItem.Enabled = false;
            m1818ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Enabled = false;
            m1829ToolStripMenuItem.Checked = true;
            m1876ToolStripMenuItem.Checked = false;
            m1876ToolStripMenuItem.Enabled = false;
            m0077ToolStripMenuItem.Checked = false;
            m0077ToolStripMenuItem.Enabled = false;
            m0075ToolStripMenuItem.Checked = false;
            m0075ToolStripMenuItem.Enabled = false;
            cToolStripMenuItem.Enabled = false;
            c0079ToolStripMenuItem.Enabled = false;
            model = "M1829";
            savepath = "d:\\TelasSNCheck\\M1829";
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);

            }
            setToolStripMenuItem.Enabled = true;
            langeToolStripMenuItem.Enabled = true;
            // SNInput sninput = new SNInput();
            this.tabPage1.Controls.Clear();
            sninput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sninput.TopLevel = false; sninput.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(sninput);
            sninput.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
            sninput.filepathset2 = savepath;
            sninput.Modset = model;
            sninput.Show();
        }

        private void m0075ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1817ToolStripMenuItem.Checked = false;
            m1817ToolStripMenuItem.Enabled = false;
            m1818ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Enabled = false;
            m1829ToolStripMenuItem.Checked = false;
            m1829ToolStripMenuItem.Enabled = false;
            m1876ToolStripMenuItem.Checked = false;
            m1876ToolStripMenuItem.Enabled = false;
            m0077ToolStripMenuItem.Checked = false;
            m0077ToolStripMenuItem.Enabled = false;
            m0075ToolStripMenuItem.Checked = true;
            cToolStripMenuItem.Enabled = false;
            c0079ToolStripMenuItem.Enabled = false;
            model = "M0075";
            savepath = "d:\\TelasSNCheck\\M0075";
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);

            }
            setToolStripMenuItem.Enabled = true;
            langeToolStripMenuItem.Enabled = true;
            // SNInput sninput = new SNInput();
            this.tabPage1.Controls.Clear();
            sninput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sninput.TopLevel = false; sninput.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(sninput);
            sninput.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
            sninput.filepathset2 = savepath;
            sninput.Modset = model;
            sninput.Show();
        }

        private void m1818ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1817ToolStripMenuItem.Checked = false;
            m1817ToolStripMenuItem.Enabled = false;
            m1818ToolStripMenuItem.Checked = true;
            m1829ToolStripMenuItem.Checked = false;
            m1829ToolStripMenuItem.Enabled = false;
            m1876ToolStripMenuItem.Checked = false;
            m1876ToolStripMenuItem.Enabled = false;
            m0077ToolStripMenuItem.Checked = false;
            m0077ToolStripMenuItem.Enabled = false;
            m0075ToolStripMenuItem.Checked = false;
            m0075ToolStripMenuItem.Enabled = false;
            cToolStripMenuItem.Enabled = false;
            c0079ToolStripMenuItem.Enabled = false;
            model = "M1818";
            savepath = "d:\\TelasSNCheck\\M1818";
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);

            }
            setToolStripMenuItem.Enabled = true;
            langeToolStripMenuItem.Enabled = true;
            // SNInput sninput = new SNInput();
            this.tabPage1.Controls.Clear();
            sninput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sninput.TopLevel = false; sninput.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(sninput);
            sninput.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
            sninput.filepathset2 = savepath;
            sninput.Modset = model;
            sninput.Show();
        }

        private void m0077ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1817ToolStripMenuItem.Checked = false;
            m1817ToolStripMenuItem.Enabled = false;
            m1818ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Enabled = false;
            m1829ToolStripMenuItem.Checked = false;
            m1829ToolStripMenuItem.Enabled = false;
            m1876ToolStripMenuItem.Checked = false;
            m1876ToolStripMenuItem.Enabled = false;
            m0077ToolStripMenuItem.Checked = true;
            m0075ToolStripMenuItem.Checked = false;
            m0075ToolStripMenuItem.Enabled = false;
            cToolStripMenuItem.Enabled = false;
            c0079ToolStripMenuItem.Enabled = false;
            model = "M0077";
            savepath = "d:\\TelasSNCheck\\M0077";
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);

            }
            setToolStripMenuItem.Enabled = true;
            langeToolStripMenuItem.Enabled = true;
            //SNInput sninput = new SNInput();
            this.tabPage1.Controls.Clear();
            sninput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sninput.TopLevel = false; sninput.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(sninput);
            sninput.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
            sninput.filepathset2 = savepath;
            sninput.Modset = model;
            sninput.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region //判断系统是否已启动

            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("WindowsFormsApp1");//获取指定的进程名   
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                MessageBox.Show("程序已启动！");
                Application.Exit();              //关闭系统
            }


            #endregion
            FileStream passcheck;
            string checkp;
            if (!File.Exists("D:\\dcheck.txt"))
            {
                passcheck = new FileStream("D:\\dcheck.txt", FileMode.Create);
                StreamWriter checkok = new StreamWriter(passcheck); checkok.Write("FTPPASS"); checkok.Flush(); checkok.Close(); passcheck.Close();
            }
            else
            {
                passcheck = new FileStream("D:\\dcheck.txt", FileMode.Open);
                StreamReader sr3 = new StreamReader(passcheck); checkp = sr3.ReadLine(); passcheck.Close();
                if (checkp.IndexOf("FAIL") != -1) { Password pwprd = new Password(); DialogResult ddr = pwprd.ShowDialog(); }

            }
            setToolStripMenuItem.Enabled = false;
        }

        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* OrderSet order = new OrderSet();
            order.filepathset = savepath;
            if (englishToolStripMenuItem.Checked == true)
            {
             
                order.English_L2 = "english";
            }
            else { order.china_L2 = "CHINA"; }
            DialogResult ddr = order.ShowDialog();*/
        }

        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabControl1.SelectedIndex==1)&&(setToolStripMenuItem.Enabled==true) && (tabsel == 0))
            {
                
                
                // this.tabPage2.Select();
                this.tabPage2.Controls.Clear();
                qc.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                qc.TopLevel = false; qc.Dock = DockStyle.Fill;
                this.tabPage2.Controls.Add(qc);
                qc.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
                qc.filepathset3 = savepath;                                           // sninput.filepathset2 = savepath;
                qc.Show();
                if(cHINAToolStripMenuItem.Checked == true) { qc.china_L3 = "CHINA"; }
                if (englishToolStripMenuItem.Checked == true) { qc.english_L3 = "english"; }
                tabsel = 1;
            }
           // if ((tabControl1.SelectedIndex == 2) && (setToolStripMenuItem.Enabled == true) && (tabsel == 1))
           // { MessageBox.Show("001"); }



        }

        private void cHINAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cHINAToolStripMenuItem.Checked = true;
            englishToolStripMenuItem.Checked = false;
            cHINAToolStripMenuItem.Text = "中文";
            englishToolStripMenuItem.Text = "英文";
            sninput.china_L = "CHINA";
            if (tabsel != 0) { qc.china_L3 = "CHINA"; }
            modelToolStripMenuItem.Text = "机种";
            setToolStripMenuItem.Text = "工单设置";
            langeToolStripMenuItem.Text = "语言";
            tabPage1.Text = "序号输入";
            tabPage2.Text = "数量核对";
            //sninput.china_L
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cHINAToolStripMenuItem.Checked = false;
            englishToolStripMenuItem.Checked = true;
            cHINAToolStripMenuItem.Text = "Simplified Chinese";
            englishToolStripMenuItem.Text = "English";
            sninput.English_L = "english";
            if (tabsel != 0) { qc.english_L3 = "english"; }
            modelToolStripMenuItem.Text = "Model";
            setToolStripMenuItem.Text = "Order Set";
            langeToolStripMenuItem.Text = "Language";
            tabPage1.Text = "SN Input";
            tabPage2.Text = "Quantity Check";
        }

        private void greatorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderSet order = new OrderSet();
            order.filepathset = savepath;
            if (englishToolStripMenuItem.Checked == true)
            {

                order.English_L2 = "english";
            }
            else { order.china_L2 = "CHINA"; }
            DialogResult ddr = order.ShowDialog();
        }

        private void delorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delorder dd = new Delorder();
            dd.filepathset4= savepath; DialogResult ddr = dd.ShowDialog();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("001");
            // if ((tabControl1.SelectedIndex == 2) && (setToolStripMenuItem.Enabled == true) && (tabsel == 1))
            //{ MessageBox.Show("001"); }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
    
             if ((tabControl1.SelectedIndex == 1)&&(setToolStripMenuItem.Enabled == true) && (tabsel == 1))
            { qc.Reflash();qc.Reflash2(); }
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1817ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Enabled = false;
            m1829ToolStripMenuItem.Checked = false;
            m1829ToolStripMenuItem.Enabled = false;
            m1876ToolStripMenuItem.Checked = false;
            m1876ToolStripMenuItem.Enabled = false;
            m0077ToolStripMenuItem.Checked = false;
            m0077ToolStripMenuItem.Enabled = false;
            m0075ToolStripMenuItem.Checked = false;
            m0075ToolStripMenuItem.Enabled = false;
            cToolStripMenuItem.Enabled = true;
            c0079ToolStripMenuItem.Enabled = false;
            model = "0080C";
            savepath = "d:\\TelasSNCheck\\0080C";
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);

            }
            setToolStripMenuItem.Enabled = true;
            langeToolStripMenuItem.Enabled = true;
            //  SNInput sninput = new SNInput();
            this.tabPage1.Controls.Clear();
            sninput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sninput.TopLevel = false; sninput.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(sninput);
            sninput.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
            sninput.filepathset2 = savepath;
            sninput.Modset = model;
            sninput.Show();

        }

        private void c0079ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1817ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Enabled = false;
            m1829ToolStripMenuItem.Checked = false;
            m1829ToolStripMenuItem.Enabled = false;
            m1876ToolStripMenuItem.Checked = false;
            m1876ToolStripMenuItem.Enabled = false;
            m0077ToolStripMenuItem.Checked = false;
            m0077ToolStripMenuItem.Enabled = false;
            m0075ToolStripMenuItem.Checked = false;
            m0075ToolStripMenuItem.Enabled = false;
            cToolStripMenuItem.Enabled = false;
            c0079ToolStripMenuItem.Enabled = true;
            model = "0079C";
            savepath = "d:\\TelasSNCheck\\0079C";
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);

            }
            setToolStripMenuItem.Enabled = true;
            langeToolStripMenuItem.Enabled = true;
            //  SNInput sninput = new SNInput();
            this.tabPage1.Controls.Clear();
            sninput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sninput.TopLevel = false; sninput.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(sninput);
            sninput.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
            sninput.filepathset2 = savepath;
            sninput.Modset = model;
            sninput.Show();
        }

        private void cToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            m1817ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Enabled = false;
            m1829ToolStripMenuItem.Checked = false;
            m1829ToolStripMenuItem.Enabled = false;
            m1876ToolStripMenuItem.Checked = false;
            m1876ToolStripMenuItem.Enabled = false;
            m0077ToolStripMenuItem.Checked = false;
            m0077ToolStripMenuItem.Enabled = false;
            m0075ToolStripMenuItem.Checked = false;
            m0075ToolStripMenuItem.Enabled = false;
            cToolStripMenuItem.Enabled = false;
            c0079ToolStripMenuItem.Enabled = false;
            cToolStripMenuItem1.Checked = true;
            model = "M0078";
            savepath = "d:\\TelasSNCheck\\M0078";
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);

            }
            setToolStripMenuItem.Enabled = true;
            langeToolStripMenuItem.Enabled = true;
            //  SNInput sninput = new SNInput();
            this.tabPage1.Controls.Clear();
            sninput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sninput.TopLevel = false; sninput.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(sninput);
            sninput.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
            sninput.filepathset2 = savepath;
            sninput.Modset = model;
            sninput.Show();
        }

        private void m1817ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1817ToolStripMenuItem.Checked = true;
            m1818ToolStripMenuItem.Checked = false;
            m1818ToolStripMenuItem.Enabled = false;
            m1829ToolStripMenuItem.Checked = false;
            m1829ToolStripMenuItem.Enabled = false;
            m1876ToolStripMenuItem.Checked = false;
            m1876ToolStripMenuItem.Enabled = false;
            m0077ToolStripMenuItem.Checked = false;
            m0077ToolStripMenuItem.Enabled = false;
            m0075ToolStripMenuItem.Checked = false;
            m0075ToolStripMenuItem.Enabled = false;
            cToolStripMenuItem.Enabled = false;
            c0079ToolStripMenuItem.Enabled = false;
            model = "M1817";
            savepath = "d:\\TelasSNCheck\\M1817";
            if (!Directory.Exists(savepath))
            {
Directory.CreateDirectory(savepath);

            }
            setToolStripMenuItem.Enabled = true;
            langeToolStripMenuItem.Enabled = true;
            //  SNInput sninput = new SNInput();
            this.tabPage1.Controls.Clear();
            sninput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sninput.TopLevel = false; sninput.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(sninput);
            sninput.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来                frm.Show();
            sninput.filepathset2 = savepath;
            sninput.Modset = model;
            sninput.Show();
        }













    }
}
