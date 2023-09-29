using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using WinFormsApp1.SumTwoFiles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormsApp00000111;

namespace WinFormsApp1
{
    public partial class EnterTextFilesForm : Form
    {
        public int lastNumber = 0;
        public static string FileDialog1;
        public static string FileDialog2;
        public EnterTextFilesForm()
        {
            InitializeComponent();
        }

        string chengeNumber(Match m, int lastNumber)
        {
            int a = (int)Convert.ToInt32(m.Value.Substring(1, m.Length - 1));
            return "#" + (a + lastNumber).ToString();
        }
        public static string openFile(System.Windows.Forms.TextBox text)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.FileName != "")
            {
                text.Text = openFileDialog1.FileName;
            }
            else { text.Text = "You didn't select the file"; }

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return "";
            
            string filename = openFileDialog1.FileName;//get file
            
            string fileText = System.IO.File.ReadAllText(filename);//reed file
            text.Text = fileText;
            MessageBox.Show("file open");
            return openFileDialog1.FileName;
        }
        private void fileButton1_Click(object sender, EventArgs e)
        {
            FileDialog1 = openFile(enterFileText1);
        }

        private void fileButton2_Click(object sender, EventArgs e)
        {
            FileDialog2 = openFile(enterFileText2);
        }
        //todo change method
        public void fileButton3_Click(object sender, EventArgs e)
        {
            var lines1 = File.ReadLines(FileDialog1).ToList();

            var lines2 = File.ReadLines(FileDialog2).ToList();

            ReplacementOfReferences rof = new ReplacementOfReferences();
            saveFileTextResult.Text = rof.TwoFiles(lines1, lines2);
            SaveFileDialog f = new SaveFileDialog();

            if (f.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(f.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(saveFileTextResult.Text);
                }
            }
        }

        private void enterFileText1_TextChanged(object sender, EventArgs e)
        {}

        private void enterFileText2_TextChanged(object sender, EventArgs e)
        {}

        private void saveFileTextResult_TextChanged(object sender, EventArgs e)
        {}
    }
}

