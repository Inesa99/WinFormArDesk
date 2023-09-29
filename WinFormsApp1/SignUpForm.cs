using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            WorkWidthJson json = new WorkWidthJson();
            var listJson = json.getJsonList();
            bool checkUserEmailPassword = listJson.Any(a => a.Email == EmailTextBox.Text);
          
            //WorkWidthJson json = new WorkWidthJson();
            SignInForm signInForm = new SignInForm();
            if (checkUserEmailPassword)
            {
                ShowMessage("Dzer Email hasceov goyutyun uni User");
                signInForm.Show();    
            }
            else
            {
                
                if (!string.IsNullOrEmpty(NameTextBox.Text.Trim()) && !string.IsNullOrEmpty(PasswordTextBox.Text.Trim()) &&
                !string.IsNullOrEmpty(ConfirmPasswordTextBox.Text.Trim()) && !string.IsNullOrEmpty(EmailTextBox.Text.Trim()))
                {
                    if (RegexEmailCheck(EmailTextBox.Text) && ConfirmPasswordCheck(PasswordTextBox.Text, ConfirmPasswordTextBox.Text))
                    {
                        User newUser = new User();
                        newUser.Name = NameTextBox.Text;
                        newUser.Email = EmailTextBox.Text;
                        newUser.Password = PasswordTextBox.Text;
                        json.AddUserToJson(newUser);
                        //signInForm.Show();
                        this.Hide();
                        signInForm.Closed += (s, args) => this.Close();
                        signInForm.Show();
                    }
                    else
                    {
                        if (!ConfirmPasswordCheck(PasswordTextBox.Text, ConfirmPasswordTextBox.Text))
                        {
                            ShowMessage("Mutqagrvac passwordner@ chen hamapatasxanum ");
                        }
                        else
                        {
                            ShowMessage("Mutqagrel valid mail");
                        }

                    }
                }
                else
                {
                    ShowMessage("Lracnel bolor patuhanner@");
                }
            }
        }
       
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
       private bool RegexEmailCheck(string email)
        {
            // returns true if the input is a valid email
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        private bool ConfirmPasswordCheck(string password,string confirmPassword)
        {
            return password == confirmPassword;
        }
        private void NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                errorProviderName.SetError(NameTextBox, "Datark");
            }
            else
            {
                errorProviderName.Clear();
            }
        }

        private void EmailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                errorProviderEmail.SetError(EmailTextBox, "datark email");
            }else if (!RegexEmailCheck(EmailTextBox.Text))
            {
                errorProviderEmail.SetError(EmailTextBox, "mutqagrel valid email");
            }
            else
            {
                errorProviderEmail.Clear();
            }
        }

        private void ConfirmPasswordTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(ConfirmPasswordTextBox.Text))
            {
                errorProviderConfirmPassword.SetError(ConfirmPasswordTextBox, "datark");
            }
            else if (ConfirmPasswordTextBox.Text != PasswordTextBox.Text) {
                errorProviderConfirmPassword.SetError(ConfirmPasswordTextBox, "Sxal password");
            }
            else
            {
                errorProviderConfirmPassword.Clear();
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
