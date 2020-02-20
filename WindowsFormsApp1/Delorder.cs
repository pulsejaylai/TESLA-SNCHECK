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
    public partial class Delorder : Form
    {
        public Delorder()
        {
            InitializeComponent();
        }
        private string filepath = "";
        public string filepathset4
        {
            set
            {
                filepath = value;
            }
        }


        private void Delorder_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].HeaderText = "工单号";
            dataGridView1.Columns[0].Width = 350;
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
if(textBox1.Text=="")
                {
                    DirectoryInfo theFolder = new DirectoryInfo(filepath);
                    FileInfo[] fileInfo = theFolder.GetFiles();
                    int ff;
                    foreach (FileInfo NextFile in fileInfo)
                    {
                        if  (NextFile.Name.IndexOf("_No") == -1)
                        {
                            ff = this.dataGridView1.Rows.Add();
                            this.dataGridView1.Rows[ff].Cells[0].Value = NextFile.Name.Replace(".txt","");                        
                            dataGridView1.CurrentCell = this.dataGridView1.Rows[ff].Cells[0];
                            this.dataGridView1.Rows[ff].Selected = true;
                        }

                         }      
                                
                                
                                }
else
                {
                    DirectoryInfo theFolder = new DirectoryInfo(filepath);
                    FileInfo[] fileInfo = theFolder.GetFiles();
                    int ff;
                    foreach (FileInfo NextFile in fileInfo)
                    {
                        if (NextFile.Name.IndexOf("_No") == -1)
                        {
                            ff = this.dataGridView1.Rows.Add();
                            this.dataGridView1.Rows[ff].Cells[0].Value = NextFile.Name.Replace(".txt", "");
                            if (NextFile.Name.Replace(".txt", "") == textBox1.Text.ToUpper())
                            {
                                dataGridView1.CurrentCell = this.dataGridView1.Rows[ff].Cells[0];
                                this.dataGridView1.Rows[ff].Selected = true; 
                            }
                        }

                    }



                }


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ix = dataGridView1.CurrentRow.Index;
            DirectoryInfo theFolder = new DirectoryInfo(filepath);
            FileInfo[] fileInfo = theFolder.GetFiles();
            foreach (FileInfo NextFile in fileInfo)
            {
                if ((NextFile.Name== dataGridView1.Rows[ix].Cells[0].Value.ToString()+".txt")||(NextFile.Name == dataGridView1.Rows[ix].Cells[0].Value.ToString() +"_No"+ ".txt"))
                {
                   
                    File.SetAttributes(filepath + "\\" + NextFile.Name, FileAttributes.Normal);
                    File.Delete(filepath + "\\" + NextFile.Name);
                }
            }
            dataGridView1.Rows.Remove(dataGridView1.Rows[ix]);




        }













    }
}
