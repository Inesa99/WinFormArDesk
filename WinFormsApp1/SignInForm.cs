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
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        private bool EmailAndPasswordEmptyCheck(string email, string password)
        {
            return (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WorkWidthJson json = new WorkWidthJson();
            var listJson = json.getJsonList();
            bool checkUserEmailPassword=listJson.Any(a=>a.Email== EmailTextBox.Text && a.Password== PasswordTextBox.Text);
            if (checkUserEmailPassword)
            {
                EnterTextFilesForm form1=new EnterTextFilesForm();
                //form1.Show();
                //this.Close();
                this.Hide();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else
            { if(EmailAndPasswordEmptyCheck(EmailTextBox.Text.Trim(), PasswordTextBox.Text.Trim())) 
                {
                    ShowMessage("Duq grancvac cheq . Hamakarg mutq gorcelu hamar grancvel");
                }
                else
                {
                    ShowMessage("Lracreq dashter@");
                }
            }
        }
        
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            //dasin nayel error cuyctalu hamar
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            //signUpForm.Show();
            this.Hide();
            signUpForm.Closed += (s, args) => this.Close();
            signUpForm.Show();
        }
    }
}
