using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUpForm signUp = new SignUpForm();
            //this.Hide();
            //signUp.Show();
            this.Hide();
            signUp.Closed += (s, args) => this.Close();
            signUp.Show();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            SignInForm signIn = new SignInForm();
            //this.Hide();
            //signIn.Show();
            this.Hide();
            signIn.Closed += (s, args) => this.Close();
            signIn.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
