using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select File";
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "txt files(*.txt)| *.txt";
            openFileDialog1.ShowDialog();
            if(openFileDialog1.FileName != "") { textBox1.Text = openFileDialog1.FileName; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Title = "Select File";
            openFileDialog2.InitialDirectory = "C:\\";
            openFileDialog2.Filter = "txt files(*.txt)| *.txt";
            openFileDialog2.ShowDialog();
            if (openFileDialog2.FileName != "") { textBox2.Text = openFileDialog2.FileName; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                FileInfo fi1 = new FileInfo(textBox1.Text);
                FileInfo fi2 = new FileInfo(textBox2.Text);
                if(fi1.Length <= 1073741824 && fi2.Length <= 1073741824)
                {
                    char[] t1 = System.IO.File.ReadAllText(textBox1.Text).ToCharArray();
                    char[] t2 = System.IO.File.ReadAllText(textBox2.Text).ToCharArray();
                    int m = t1.Length;
                    int n = t2.Length;
                    int cost;
                    int[,] arr = new int[m + 1, n + 1];
                    for (int i = 0; i <= m; i++) { arr[i, 0] = i; }
                    for (int j = 1; j <= n; j++) { arr[0, j] = j; }

                    for (int i = 1; i <= m; i++)
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            if (t1[i-1] == t2[j-1]) cost = 0;
                            else cost = 1;
                            arr[i, j] = findMin(arr[i - 1, j] + 1, arr[i, j - 1] + 1, arr[i - 1, j - 1] + cost);
                        }
                    }

                    textBox3.Text = arr[m, n].ToString();
                }
                else
                {
                    textBox3.Text = "One of the files > 1GB";
                }
            }
        }

        private int findMin(int x, int y, int z)
        {
            if (x <= y)
            {
                if (x <= z)
                {
                    return x;
                }
                else
                {
                    return z;
                }
            }
            else
            {
                if (y <= z)
                {
                    return y;
                }
                else
                {
                    return z;
                }
            }
        }
    }
}
