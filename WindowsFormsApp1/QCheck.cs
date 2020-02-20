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
    public partial class QCheck : Form
    {

        public QCheck()
        {
            InitializeComponent();
        }
        private string filepath = "", language = "CHINA",rootpath="";
        int total, done = 0, usercount = 0;
        public void Reflash()
        {
            if (textBox1.Text != "")
            {
                string filename = "", filename2 = "", ordertotal;
                string[] lines, order2;
                order2 = textBox1.Text.Split('-');
                ordertotal = order2[0];
                // MessageBox.Show(order2[0]);
                filename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
                filename2 = filepath + "\\" + textBox1.Text.ToUpper() + "_No" + ".txt";
                int done22 = 0;
                string[] lines2;
                lines = File.ReadAllLines(filename2); label3.Text = "卡板已刷数量" + ":" + lines[0]; total = int.Parse(lines[0]); textBox1.ReadOnly = true; textBox2.ReadOnly = false; textBox3.ReadOnly = false; button1.Enabled = true;
                rootpath = Path.GetDirectoryName(filepath + "\\" + textBox1.Text + ".txt");
                DirectoryInfo theFolder = new DirectoryInfo(rootpath);
                FileInfo[] fileInfo = theFolder.GetFiles();
                //  MessageBox.Show(Path.GetDirectoryName(filepath + "\\" + textBox1.Text + ".txt"));
                foreach (FileInfo NextFile in fileInfo)
                {
                    //  MessageBox.Show(NextFile.Name);
                    if ((NextFile.Name.IndexOf(order2[0].ToUpper()) != -1) && (NextFile.Name.IndexOf("_No") != -1))
                    { lines2 = File.ReadAllLines(filepath + "\\" + NextFile.Name); done22 = done22 + int.Parse(lines2[0]); }
                }

                label8.Text = "总工单已刷数量" + ":" + done22.ToString();
            }
        }
        public void Reflash2()
        {
            int rw2 = 0;
            rw2 = dataGridView2.Rows.Count;
            if (rw2 >= 2)
            {
                textBox3.Text = "";
                for (int rw = dataGridView2.Rows.Count; rw > 1; rw--)
                {
                    if (rw >= 2)
                    {
                        DataGridViewRow row = dataGridView2.Rows[rw - 2];
                        dataGridView2.Rows.Remove(row);
                    }
                }
                string[] lines, seq;
                int ff;
                string filename;
                filename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
                lines = File.ReadAllLines(filename);
                
                for (int t = 1; t <= total; t++)
                {
                    seq = lines[t].Split(',');
                    ff = this.dataGridView2.Rows.Add();
                    this.dataGridView2.Rows[ff].Cells[0].Value = seq[0];
                    this.dataGridView2.Rows[ff].Cells[1].Value = seq[1];
                    this.dataGridView2.Rows[ff].Cells[2].Value = seq[2];
                    dataGridView2.CurrentCell = this.dataGridView2.Rows[ff].Cells[0];
                    this.dataGridView2.Rows[ff].Selected = true;
                }
            }

        }




        public string filepathset3
        {
            set
            {
                filepath = value;
            }
        }

        public string china_L3
        {
            set
            {
                language = value;
                label1.Text = "工单号";
                label2.Text = "外箱Label数量";
                label3.Text = "卡板已刷数量";
                label4.Text = "外箱Label";
                label5.Text = "产品序号";
                dataGridView1.Columns[0].HeaderText = "外箱序号";
                dataGridView2.Columns[0].HeaderText = "产品序号";
                dataGridView2.Columns[1].HeaderText = "时间";
                dataGridView2.Columns[2].HeaderText = "检查者";
                groupBox1.Text = "外箱Label检查";
                groupBox2.Text = "产品序号查询";
            }
        }

        public string english_L3
        {
            set
            {
                language = value;
                label1.Text = "Work Order";
                label2.Text = "Label Quantity";
                label3.Text = "Act Quantity";
                label4.Text = "Label Number";
                label5.Text = "SN";
                dataGridView1.Columns[0].HeaderText = "Label";
                dataGridView2.Columns[0].HeaderText = "SN";
                dataGridView2.Columns[1].HeaderText = "Time";
                dataGridView2.Columns[2].HeaderText = "Operator";
                groupBox1.Text = "Label Check";
                groupBox2.Text = "SN Query";
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string filename = "", filename2 = "",ordertotal;
            string[] lines,order2;
           
            if (e.KeyCode == Keys.Enter)
            {
                order2 = textBox1.Text.Split('-');
                ordertotal = order2[0];
               // MessageBox.Show(order2[0]);
                filename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
                filename2 = filepath + "\\" + textBox1.Text.ToUpper() + "_No" + ".txt";
                if (!File.Exists(filename))
                {
                    if (language == "CHINA") { MessageBox.Show("工单不存在"); }
                    if (language == "english") { MessageBox.Show("Order don't exit"); }
                    textBox1.Text = "";
                }
                else
                {
                    int done22 = 0;
                    string[] lines2;
                    lines = File.ReadAllLines(filename2);label3.Text = label3.Text + ":" + lines[0];total = int.Parse(lines[0]); textBox1.ReadOnly = true; textBox2.ReadOnly = false; textBox3.ReadOnly = false; button1.Enabled = true; textBox4.ReadOnly = false;
                    rootpath = Path.GetDirectoryName(filepath + "\\" + textBox1.Text + ".txt");
                    DirectoryInfo theFolder = new DirectoryInfo(rootpath);
                    FileInfo[] fileInfo = theFolder.GetFiles();
                    //  MessageBox.Show(Path.GetDirectoryName(filepath + "\\" + textBox1.Text + ".txt"));
                    foreach (FileInfo NextFile in fileInfo)
                    {
                      //  MessageBox.Show(NextFile.Name);
                        if ((NextFile.Name.IndexOf(order2[0].ToUpper())!=-1)&&(NextFile.Name.IndexOf("_No")!=-1))
                        {  lines2 = File.ReadAllLines(filepath + "\\"+NextFile.Name); done22 = done22 + int.Parse(lines2[0]); }
                                }

                    label8.Text = label8.Text + ":" + done22.ToString();


                }


            }




        }

        private void QCheck_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].HeaderText = "外箱序号";
            dataGridView1.Columns[0].Width = 350;
            dataGridView2.ColumnCount = 3;
            dataGridView2.Columns[0].HeaderText = "产品序号";
            dataGridView2.Columns[0].Width = 116;
            dataGridView2.Columns[1].HeaderText = "时间";
            dataGridView2.Columns[1].Width = 116;
            dataGridView2.Columns[2].HeaderText = "检查者";
            dataGridView2.Columns[2].Width = 117;
            this.label6.Font = new Font("隶书", 18, FontStyle.Bold); //第一个是字体，第二个大小，第三个是样式，
            button1.Enabled = false;
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rootpath = Path.GetDirectoryName(filepath + "\\" + textBox3.Text + ".txt");
                DirectoryInfo theFolder = new DirectoryInfo(rootpath);
                FileInfo[] fileInfo = theFolder.GetFiles();
                //  MessageBox.Show(Path.GetDirectoryName(filepath + "\\" + textBox3.Text + ".txt"));
               // foreach (FileInfo NextFile in fileInfo)
             //   { if(NextFile.Name.IndexOf(order2) }
                        
                        
                        }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines, seq;
            string filename = "", filename2 = "";
            int doqity;
            FileStream savefile;
            StreamWriter sw3;
            filename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
            filename2 = filepath + "\\" + textBox1.Text.ToUpper() + "_No" + ".txt";
            File.SetAttributes(filename2, FileAttributes.Normal); File.SetAttributes(filename, FileAttributes.Normal);
            int i = dataGridView2.CurrentRow.Index;
            List<string> lines2 = new List<string>(File.ReadAllLines(filename));
            lines2.RemoveAt(i+1);
            File.WriteAllLines(filename, lines2.ToArray());
            lines = File.ReadAllLines(filename2);
            doqity= int.Parse(lines[0]) - 1;
            savefile = new FileStream(filename2, FileMode.Truncate);
            sw3 = new StreamWriter(savefile);
            sw3.Write(doqity.ToString()); sw3.Flush(); sw3.Close(); savefile.Close();
           /* for (int x = 0; x < dataGridView1.Rows.Count; x++)
                 {
                
                        DataGridViewRow row = dataGridView1.Rows[x];
                        dataGridView2.Rows.Remove(row);
                        x--; //这句是关键。。
                
                 }*/

            dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
            FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
            FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;

            string[] lines3,order2;
            string ordertotal;
            int done22 = 0;
            order2 = textBox1.Text.Split('-');
            ordertotal = order2[0];
            lines = File.ReadAllLines(filename2); label3.Text = "卡板已刷数量" + ":" + lines[0];
            rootpath = Path.GetDirectoryName(filepath + "\\" + textBox1.Text + ".txt");
            DirectoryInfo theFolder = new DirectoryInfo(rootpath);
            FileInfo[] finfo = theFolder.GetFiles();
            //  MessageBox.Show(Path.GetDirectoryName(filepath + "\\" + textBox1.Text + ".txt"));
            foreach (FileInfo NextFile in finfo)
            {
                //  MessageBox.Show(NextFile.Name);
                if ((NextFile.Name.IndexOf(order2[0].ToUpper()) != -1) && (NextFile.Name.IndexOf("_No") != -1))
                { lines3 = File.ReadAllLines(filepath + "\\" + NextFile.Name); done22 = done22 + int.Parse(lines3[0]); }
            }

            label8.Text = "总工单已刷数量" + ":" + done22.ToString();






        }

        private void textBox4_KeyDown_1(object sender, KeyEventArgs e)
        {
        
            if (e.KeyCode == Keys.Enter)
            {
                string[] lines, seq,lines2;
                string filename = "", filename2 = "";
                usercount = 0;
                for (int rw = dataGridView2.Rows.Count; rw > 1; rw--)
                {
                    if (rw >= 2)
                    {
                        DataGridViewRow row = dataGridView2.Rows[rw - 2];
                        dataGridView2.Rows.Remove(row);
                    }
                }
               
                int ff;
                filename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
                filename2 = filepath + "\\" + textBox1.Text.ToUpper() + "_No" + ".txt";
                lines2 = File.ReadAllLines(filename2);
                total = int.Parse(lines2[0]);
                if (textBox4.Text == "") { MessageBox.Show("请输入员工代码"); }
else
                {
                    lines = File.ReadAllLines(filename);
                    for (int t = 1; t <= total; t++)
                    {
                        seq = lines[t].Split(',');
                        if (seq[2] == textBox4.Text)
                        {
                            ff = this.dataGridView2.Rows.Add(); this.dataGridView2.Rows[ff].Cells[0].Value = seq[0];
                            this.dataGridView2.Rows[ff].Cells[1].Value = seq[1];
                            this.dataGridView2.Rows[ff].Cells[2].Value = seq[2];
                            usercount = usercount + 1; 
                        }


                    }
                    label9.Text = "检查者数量："+usercount.ToString();
                }


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (done < total) { if (language == "CHINA") {label6.Text = "数量不足";} if (language == "english") { label6.Text = "Label Quantity<Finish Quantity"; } label6.ForeColor = Color.Red;label6.Visible = true;textBox2.ReadOnly = true; }
            if (done > total) { if (language == "CHINA") { label6.Text = "外围数量>已刷数量";} if (language == "english") { label6.Text = "Label Quantity>Finish Quantity"; } label6.ForeColor = Color.Red; label6.Visible = true; textBox2.ReadOnly = true; }
            if (done == total) { if (language == "CHINA") { label6.Text = "验证通过"; } if (language == "english") { label6.Text = "PASS"; } label6.ForeColor = Color.Green; label6.Visible = true; textBox2.ReadOnly = true; }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.Enter)
            {
                string[] lines, seq,lines2;
                string filename = "", filename2 = "";
              //  MessageBox.Show(dataGridView2.Rows.Count.ToString());
                for (int rw = dataGridView2.Rows.Count; rw > 1; rw--)
                {
                    if (rw >= 2)
                    {
                        DataGridViewRow row = dataGridView2.Rows[rw - 2];
                        dataGridView2.Rows.Remove(row);
                    }
                }
                //  MessageBox.Show(dataGridView2.Rows.Count.ToString());
               
                int ff;
                filename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
                filename2 = filepath + "\\" + textBox1.Text.ToUpper() + "_No" + ".txt";
                lines2 = File.ReadAllLines(filename2);
                total = int.Parse(lines2[0]);
                if (textBox3.Text == "")
                {

                    lines = File.ReadAllLines(filename);
                    for (int t=1;t<=total;t++)
                    {
                        //MessageBox.Show(total.ToString());
                        seq = lines[t].Split(',');              
                        ff = this.dataGridView2.Rows.Add();                    
                        this.dataGridView2.Rows[ff].Cells[0].Value = seq[0];                    
                        this.dataGridView2.Rows[ff].Cells[1].Value = seq[1];
                        this.dataGridView2.Rows[ff].Cells[2].Value = seq[2];
                        dataGridView2.CurrentCell = this.dataGridView2.Rows[ff].Cells[0];
                        this.dataGridView2.Rows[ff].Selected = true;
                    }
                }
                if (textBox3.Text != "")
                {
                    lines = File.ReadAllLines(filename);
                    int p = 0;
                    for (int t = 1; t <= total; t++)
                    {
                        seq = lines[t].Split(',');
                        ff = this.dataGridView2.Rows.Add();
                        this.dataGridView2.Rows[ff].Cells[0].Value = seq[0];
                        this.dataGridView2.Rows[ff].Cells[1].Value = seq[1];
                        this.dataGridView2.Rows[ff].Cells[2].Value = seq[2];
                        if (seq[0]== textBox3.Text)
                        {
                            dataGridView2.CurrentCell = this.dataGridView2.Rows[ff].Cells[0];
                            this.dataGridView2.Rows[ff].Selected = true;p = 1;
                        }
                        }
                    if (p == 0) { if (language == "CHINA") { MessageBox.Show("序号不存在"); } if (language == "english") { MessageBox.Show("SN Don't exit"); } }

                }


            }

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            int rowCount = dataGridView1.Rows.Count,x=0;
            string[] seq;
            if (e.KeyCode == Keys.Enter)
            {
                string snpass = "ok";
                int ff;
                if ((rowCount == 1)&&(textBox2.Text!=""))
                {

                    ff = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[ff].Cells[0].Value = textBox2.Text;
                    dataGridView1.CurrentCell = this.dataGridView1.Rows[ff].Cells[0];
                    this.dataGridView1.Rows[ff].Selected = true;
                    seq = textBox2.Text.ToString().Split('#');
                    //  MessageBox.Show(seq[6]);
                    done = done + int.Parse(seq[6]);
                    if (language == "CHINA") { label2.Text = "外箱Label数量" + ":" + done.ToString(); }
                    if (language == "english") { label2.Text = "Label Quantity" + ":" + done.ToString(); }
                    textBox2.Text = "";
                }
                if ((rowCount > 1)&& (textBox2.Text != ""))
                {
                    do
                    {
                        //  MessageBox.Show(x.ToString());
                        //  MessageBox.Show(dataGridView1.Rows[x].Cells[0].Value.ToString());

                        //   MessageBox.Show(dataGridView1.Rows[x].Cells[0].Value.ToString());
                        if (dataGridView1.Rows[x].Cells[0].Value.ToString().IndexOf(textBox2.Text) != -1)
                        {

                            dataGridView1.CurrentCell = this.dataGridView1.Rows[x].Cells[0];
                            this.dataGridView1.Rows[x].Selected = true;
                            snpass = "ng";
                            if (language == "CHINA") { MessageBox.Show("SN 重复"); }
                            if (language == "english") { MessageBox.Show("SN Duplication"); }
                        }

                        x++;
                    } while ((x + 1 < rowCount) && (textBox2.Text != dataGridView1.Rows[x - 1].Cells[0].Value.ToString()));
                    if (snpass == "ng")
                    {
                        textBox2.Text = "";
                        textBox2.Focus();
                    }
else
                    {
                        ff = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[ff].Cells[0].Value = textBox2.Text;
                        dataGridView1.CurrentCell = this.dataGridView1.Rows[ff].Cells[0];
                        this.dataGridView1.Rows[ff].Selected = true;
                        seq = textBox2.Text.ToString().Split('#');
                        //  MessageBox.Show(seq[6]);
                        done = done + int.Parse(seq[6]);
                        if (language == "CHINA") { label2.Text = "外箱Label数量" + ":" + done.ToString(); }
                        if (language == "english") { label2.Text = "Label Quantity" + ":" + done.ToString(); }
                        textBox2.Text = "";
                        if (done > total) { if (language == "CHINA") { label6.Text = "外围数量>已刷数量"; } if (language == "english") { label6.Text = "Label Quantity>Finish Quantity"; } label6.ForeColor = Color.Red; label6.Visible = true; textBox2.ReadOnly = true; }
                    }

                }

               
                //MessageBox.Show(dataGridView1.Rows[0].Cells[0].Value.ToString());
            }


        }






    }
}
