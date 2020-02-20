using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
namespace WindowsFormsApp1
{
    public partial class SNInput : Form
    {
        delegate void mydelegate();
        public SNInput()
        {
            InitializeComponent();
        }
        string FTPAddress = "ftp://172.17.11.65"; //ftp服务器地址
        string FTPUsername = "LarryYang";   //用户名
        string FTPPwd = "Welcome@123";        //密码
        int ftpcheck = 0;
        private void UpFile(string localfilepath, string ftpfilepath)
        {
            string LocalPath = localfilepath; //待上传文件
            FileInfo f = new FileInfo(LocalPath);
            string FileName = f.Name;
            string ftpRemotePath = ftpfilepath;
            string FTPPath = FTPAddress + ftpRemotePath + FileName;
            FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(FTPPath));
            reqFtp.UseBinary = true;
            reqFtp.Credentials = new NetworkCredential(FTPUsername, FTPPwd); //设置通信凭据
            reqFtp.KeepAlive = false; //请求完成后关闭ftp连接
            reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
            reqFtp.ContentLength = f.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            FileStream fs = f.OpenRead();
            try
            {
                Stream strm = reqFtp.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                ftpcheck = 1;
               // MessageBox.Show(ex.ToString());
            }


        }


        void Thread_Test()
        {
            ftpcheck = 0;
            if (textBox2.InvokeRequired == false)
            {
                UpFile(tfilename2, "/WO Verification/");//D:\jaylai
                UpFile(tfilename, "/WO Verification/");//D:\jaylai

                FileInfo fileInfo2 = new FileInfo(tfilename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                FileInfo fileInfo = new FileInfo(tfilename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                if (ftpcheck == 1)
                {
                    FileStream passcheck;
                    this.label5.Text = "FTP上传失败";
                    label5.Visible = true;
                    textBox2.ReadOnly = true;
                    button1.Enabled = false;
                    passcheck = new FileStream("D:\\dcheck.txt", FileMode.Truncate);
                    StreamWriter checkok = new StreamWriter(passcheck); checkok.Write("FTPFAIL"); checkok.Flush(); checkok.Close(); passcheck.Close();
                }
            }
            else
            {
                // MessageBox.Show("Mid2");
                mydelegate mytest = new mydelegate(Thread_Test);
                textBox2.BeginInvoke(mytest);

            }


        }

        void Thread2_Test()
        {
            UpFile(tfilename2, "/WO Verification/");//D:\jaylai
                                                    //  UpFile(tfilename, "/WO Verification/");//D:\jaylai
            
            FileInfo fileInfo2 = new FileInfo(tfilename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
            


        }

        void Thread3_Test()
        {
            UpFile(tfilename, "/WO Verification/");
            FileInfo fileInfo = new FileInfo(tfilename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
        }
        private string filepath = "",language= "CHINA",Mod="";
        public Thread thread1, thread2,thread3;
        int fourcount=0,pan=0;
        public string Modset
        {
            set
            {
                Mod = value;
            }
        }
        public string filepathset2
        {
            set
            {
                filepath = value;
            }
        }
        public string china_L
        {
            set
            {
                language = value;
                label1.Text = "工单号";
                label2.Text = "已刷数量";
                label3.Text = "总数量";
                label4.Text = "序号";
                label8.Text = "检查者";
                dataGridView1.Columns[0].HeaderText = "序号";
                dataGridView1.Columns[1].HeaderText = "时间";
                dataGridView1.Columns[2].HeaderText = "检查员";
            }
        }

        public string English_L
        {
            set
            {
                language = value;
                label1.Text = "Work Order";
                label2.Text = "Finish Quantity";
                label3.Text = "Total Quantity";
                label4.Text = "SN";
                label8.Text = "Operator";
                dataGridView1.Columns[0].HeaderText = "SN";
                dataGridView1.Columns[1].HeaderText = "Time";
                dataGridView1.Columns[2].HeaderText = "Operator";
            }
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string filename = "", filename2 = "";
            string[] lines;
            int total,done;
            if (e.KeyCode == Keys.Enter)
            {
                filename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
                filename2 = filepath + "\\" + textBox1.Text.ToUpper() + "_No" + ".txt";
                tfilename = filename; tfilename2 = filename2;
                if (!File.Exists(filename))
                {
                    if (language == "CHINA") { MessageBox.Show("工单不存在"); }
                    if (language == "english") { MessageBox.Show("Order don't exit"); }
                    textBox1.Text = "";
                }
else
            {

                    lines = File.ReadAllLines(filename2);
                    label2.Text = label2.Text + ":" + lines[0];                  
                    done = int.Parse(lines[0]);
                    lines = File.ReadAllLines(filename);
                    label3.Text=label3.Text+":" + lines[0].Substring(3);                 
                     total = int.Parse(lines[0].Substring(3));
                  
                    if (done < total)
                    {
                        if(textBox3.Text!="")
                        { textBox1.ReadOnly = true; textBox2.ReadOnly = false; textBox2.Focus();button1.Enabled = true;button2.Enabled = true; }
                        else
                        {
                            if (language == "CHINA") { MessageBox.Show("未填写检查者"); }
                            if (language == "english") { MessageBox.Show("No Operator"); ; }
                        }
                    }
                    else
                    {
                        button2.Enabled = true;
                        textBox1.ReadOnly = true;
                        this.label5.ForeColor = Color.Red;
                        if (language == "CHINA") { this.label5.Text = "数量超出"; }
                        if (language == "english") { this.label5.Text = "Act qnantity more than plan"; }
                        label5.Visible = true;
                    }
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(tfilename);
            thread2 = new Thread(Thread2_Test);
            thread2.IsBackground = true;
            thread2.Start();
            thread3 = new Thread(Thread3_Test);
            thread3.IsBackground = true;
            thread3.Start();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { textBox1.Focus(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Focus();textBox2.ReadOnly = false;textBox2.Text = ""; this.label5.Text = "";
        }
        string tfilename = "";
        string tfilename2 = "";
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                
                label5.Visible = false;
                string filename = "", filename2 = "";
                string[] lines;
                int total, done, done2;
                FileStream savefile;
                textBox2.ReadOnly = true;
                filename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
                filename2 = filepath + "\\" + textBox1.Text.ToUpper() + "_No" + ".txt";
                tfilename = filename; tfilename2 = filename2;
                File.SetAttributes(filename2, FileAttributes.Normal); File.SetAttributes(filename, FileAttributes.Normal);

                StreamReader check = new StreamReader(filename, Encoding.Default);
                string line, snpass="ok";
                if ((textBox2.Text.IndexOf("(P)1071833-00-H") == -1)&&(Mod=="M1817"))
                {
                    this.label5.Text = "刷错机种";
                    label5.Visible = true;
                    textBox2.Text = "";
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    snpass = "fail";
                }
                if ((textBox2.Text.IndexOf("(P)1071833-00-J") == -1) && (Mod == "M0078"))
                {
                    this.label5.Text = "刷错机种";
                    label5.Visible = true;
                    textBox2.Text = "";
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    snpass = "fail";
                }
                if ((textBox2.Text.IndexOf("(P)1138081-00-E") == -1) && (Mod == "M0077"))
                {
                    this.label5.Text = "刷错机种";
                    label5.Visible = true;
                    textBox2.Text = "";
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    snpass = "fail";
                }

                if ((textBox2.Text.IndexOf("(P)1138081-00-C") == -1) && (Mod == "M1876"))
                {
                    this.label5.Text = "刷错机种";
                    label5.Visible = true;
                    textBox2.Text = "";
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    snpass = "fail";
                }
                if ((textBox2.Text.IndexOf("(P)1071917-00-E") == -1) && (Mod == "M1829"))
                {
                    this.label5.Text = "刷错机种";
                    label5.Visible = true;
                    textBox2.Text = "";
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    snpass = "fail";
                }

                if ((textBox2.Text.IndexOf("(P)1071917-00-F") == -1) && (Mod == "0079C"))
                {
                    this.label5.Text = "刷错机种";
                    label5.Visible = true;
                    textBox2.Text = "";
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    snpass = "fail";
                }
                if ((textBox2.Text.IndexOf("(P)1071917-01-E") == -1) && (Mod == "M0075"))
                {
                    this.label5.Text = "刷错机种";
                    label5.Visible = true;
                    textBox2.Text = "";
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    snpass = "fail";
                }
                if ((textBox2.Text.IndexOf("(P)1071917-01-F") == -1) && (Mod == "0080C"))
                {
                    this.label5.Text = "刷错机种";
                    label5.Visible = true;
                    textBox2.Text = "";
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    snpass = "fail";
                }

                if ((textBox2.Text.IndexOf("(P)1080536-00-F") == -1) && (Mod == "M1818"))
                {
                    this.label5.Text = "刷错机种";
                    label5.Visible = true;
                    textBox2.Text = "";
                    FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                    FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    snpass = "fail";
                }
                if (snpass == "ok")
                {
                    do
                    {
                        line = check.ReadLine();
                        // MessageBox.Show(line);
                        if (line != null)
                        {
                            if ((line.IndexOf(textBox2.Text.ToUpper()) != -1) || (textBox2.Text == ""))
                            {
                                snpass = "fail"; this.label5.ForeColor = Color.Red; if (language == "CHINA") { this.label5.Text = "序号重复"; }
                                if (language == "english") { this.label5.Text = "SN Duplication"; }
                                label5.Visible = true;
                                if (textBox2.Text == "") { if (language == "CHINA") { this.label5.Text = "序号为空"; } if (language == "english") { this.label5.Text = "NO SN"; } }
                                FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                                FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                                break;
                            }
                        }
                    } while (line != null);

                    check.Close();
                    lines = File.ReadAllLines(filename2);
                    done2 = int.Parse(lines[0]) + 1;
                    lines = File.ReadAllLines(filename);
                    total = int.Parse(lines[0].Substring(3));
                    if (done2 > total)
                    {
                        this.label5.ForeColor = Color.Red; if (language == "CHINA") { this.label5.Text = "数量超出"; }
                        if (language == "english") { this.label5.Text = "Act qnantity more than plan"; }
                        label5.Visible = true; snpass = "fail"; FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                        FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                    }
                    if (snpass == "ok")
                    {
                        int ff = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[ff].Cells[0].Value = textBox2.Text.ToUpper();
                        this.dataGridView1.Rows[ff].Cells[1].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                       // this.dataGridView1.Rows[ff].Cells[1].Value = DateTime.Now.ToString("MM/dd/yyyy");
                        this.dataGridView1.Rows[ff].Cells[2].Value = textBox3.Text;
                        dataGridView1.CurrentCell = this.dataGridView1.Rows[ff].Cells[0];
                        this.dataGridView1.Rows[ff].Selected = true;
                        savefile = new FileStream(filename, FileMode.Append);
                        StreamWriter sw3 = new StreamWriter(savefile);
                        sw3.Write(dataGridView1.Rows[ff].Cells[0].Value + "," + dataGridView1.Rows[ff].Cells[1].Value + "," + dataGridView1.Rows[ff].Cells[2].Value + "\r\n"); sw3.Flush(); sw3.Close(); savefile.Close();
                        lines = File.ReadAllLines(filename2);
                        fourcount = fourcount + 1;
                        if ((Mod == "M1876") || (Mod == "M0077"))
                        {
                            if (fourcount % 4 == 0) { pan = pan + 1; }
                        }
                        if ((Mod == "M1817")|| (Mod == "M0078"))
                        {
                            if (fourcount % 9 == 0) { pan = pan + 1; }
                        }
                        if ((Mod == "M0075") || (Mod == "M1829")|| (Mod == "0080C")||(Mod == "0079C"))
                        {
                            if (fourcount % 2 == 0) { pan = pan + 1; }
                        }
                        if (Mod == "M1818")
                        {
                            if (fourcount % 6 == 0) { pan = pan + 1; }
                        }
                        done = int.Parse(lines[0]) + 1;
                        if (language == "CHINA") { label2.Text = "已刷数量" + ":" + done.ToString(); label9.Text = "盘数" + ":" + pan.ToString(); }
                        if (language == "english") { label2.Text = "Finish Quantity" + ":" + done.ToString(); }
                        if (language == "CHINA") { label3.Text = "总数量" + ":" + total.ToString(); }
                        if (language == "english") { label3.Text = "Total Quantity" + ":" + total.ToString(); }
                        savefile = new FileStream(filename2, FileMode.Truncate);
                        sw3 = new StreamWriter(savefile);
                        sw3.Write(done.ToString()); sw3.Flush(); sw3.Close(); savefile.Close();
                        textBox2.ReadOnly = false; textBox2.Text = ""; label5.Text = "";
                        if(done==total)
                        {
                          //  thread1 = new Thread(Thread_Test);
                          //  thread1.IsBackground = true;
                           // thread1.Start();
                            thread2 = new Thread(Thread2_Test);
                            thread2.IsBackground = true;
                            thread2.Start();
                            thread3 = new Thread(Thread3_Test);
                            thread3.IsBackground = true;
                            thread3.Start();
                        }
                        if (done != total)
                        {
                            FileInfo fileInfo2 = new FileInfo(filename2); fileInfo2.Attributes |= FileAttributes.ReadOnly; fileInfo2.Attributes |= FileAttributes.Hidden;
                            FileInfo fileInfo = new FileInfo(filename); fileInfo.Attributes |= FileAttributes.ReadOnly; fileInfo.Attributes |= FileAttributes.Hidden;
                        }
                        if (ftpcheck == 1)
                        {
                            FileStream passcheck;
                            this.label5.Text = "FTP上传失败";
                            label5.Visible = true;
                            textBox2.ReadOnly = true;
                            button1.Enabled = false;
                            passcheck = new FileStream("D:\\dcheck.txt", FileMode.Truncate);
                            StreamWriter checkok = new StreamWriter(passcheck); checkok.Write("FTPFAIL"); checkok.Flush(); checkok.Close(); passcheck.Close();
                        }


                    }

                }

            }


        }

        private void SNInput_Load(object sender, EventArgs e)
        {
            textBox3.Focus();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "序号";
            dataGridView1.Columns[0].Width = 533;
            dataGridView1.Columns[1].HeaderText = "时间";
            dataGridView1.Columns[1].Width = 233;
            dataGridView1.Columns[2].HeaderText = "检查员";
            dataGridView1.Columns[2].Width = 234;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("楷体", 15, FontStyle.Bold);
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.label5.Font = new Font("隶书", 24, FontStyle.Bold); //第一个是字体，第二个大小，第三个是样式，
            tfilename = filepath + "\\" + textBox1.Text.ToUpper() + ".txt";
            tfilename2 = filepath + "\\" + textBox1.Text.ToUpper() + "_No" + ".txt";
        }



    }
}
