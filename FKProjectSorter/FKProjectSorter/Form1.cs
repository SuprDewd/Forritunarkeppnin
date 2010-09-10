using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FKProjectSorter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtSource_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtSource.Text))
            {
                fbDialog.SelectedPath = txtSource.Text;
            }
            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = fbDialog.SelectedPath;
            }
            fbDialog.SelectedPath = "C:\\";
        }

        private void txtDest_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDest.Text))
            {
                fbDialog.SelectedPath = txtDest.Text;
            }
            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                txtDest.Text = fbDialog.SelectedPath;
            }
            fbDialog.SelectedPath = "C:\\";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Visual Studio 2010\Projects"))
            {
                txtSource.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Visual Studio 2010\Projects";
            }

            txtDest.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            btnDone.Focus();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if(File.Exists(txtSource.Text+@"\Program.cs"))
            {
                StreamReader sr = new StreamReader(txtSource.Text+@"\Program.cs");
                string inni = sr.ReadToEnd();
                sr.Close();
                inni = inni.Replace("class Program", "class Verk"+udNum.Value);
                StreamWriter sw = new StreamWriter(txtDest.Text+@"\Verk"+udNum.Value+".cs");
                sw.Write(inni);
                sw.Close();

                foreach (string i in Directory.GetFiles(txtSource.Text+@"\bin\Debug\"))
                {
                    if (i.EndsWith(".exe") && !i.EndsWith(".vshost.exe"))
                    {
                        File.Copy(i, txtDest.Text + @"\Verk" + udNum.Value + ".exe", true);
                        break;
                    }
                }

                udNum.Value++;
            }
        }
    }
}
