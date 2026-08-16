using DVLD___Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using BCrypt.Net;
using System.Security.Cryptography;

namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            btnLogin.BackColor = Color.FromArgb(20, 50, 100);

        }

        Aes _MyAes;
        private clsUser _User;
        private string _FilePath = "LoggedInUser_Credentials.json";

        class clsRememberedLogin
        {
            public string username {  get; set; }
            public string password { get; set; }
        }

        clsRememberedLogin _RememberedLogin;
        private bool Validate_Credentials()
        {
            if (_User == null || _User.UserID == -1)
                return false;

            bool valid = true;
            valid &= Validate_Username();
            valid &= Validate_Password();
            return valid;
        }
        private bool Validate_Username()
        {
            return string.Equals(tbUsername.Text, _User.UserName);
        }

        private bool Validate_Password()
        {
            
            return BCrypt.Net.BCrypt.Verify(tbPassword.Text, _User.Password);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _User = clsUser.FindUserByUsername(tbUsername.Text);

            if (Validate_Credentials())
            {
                
                if (!_User.IsActive)
                {
                    lblLoginError.Text = "This user is not active!\r\nPlease contact Admin!";
                    lblLoginError.Visible = true;
                    return;
                }

                lblLoginError.Visible = false;
                clsGlobal.LoggedInUser = _User;

                if (chkRememberMe.Checked)
                {
                    _RememberedLogin.username = tbUsername.Text;
                    _RememberedLogin.password = tbPassword.Text;
                    byte[] EncryptedPwd = clsSecurity.EncryptStringToBytes_Aes(_RememberedLogin.password, clsSecurity.Key, clsSecurity.IV);
                    _RememberedLogin.password = Convert.ToBase64String(EncryptedPwd);
                    Save_LoggedInUser_ToFile();
                }
                else
                {
                    if (File.Exists(_FilePath) && !string.IsNullOrEmpty(File.ReadAllText(_FilePath)))
                    {
                        File.WriteAllText(_FilePath, string.Empty);
                    }
                }

                MainForm frmMain = new MainForm();
                
                frmMain.ShowDialog();
                this.Close();
            }
            else
            {
                lblLoginError.Text = "Invalid Credentials!";
                lblLoginError.Visible = true;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            _MyAes = Aes.Create();
            _RememberedLogin = new clsRememberedLogin();

            lblLoginError.Visible = false;

            if (File.Exists(_FilePath) && !string.IsNullOrEmpty(File.ReadAllText(_FilePath)))
            {
                tbPassword.UseSystemPasswordChar = true;
                chkRememberMe.Checked = true;

                Load_LoggedInUser_FromFile();

                _RememberedLogin.password = clsSecurity.DecryptStringFromBytes_Aes(
                    Convert.FromBase64String(_RememberedLogin.password), clsSecurity.Key, clsSecurity.IV);

                tbUsername.Text = _RememberedLogin.username;
                tbPassword.Text = _RememberedLogin.password;

            }
            else
            {
                // Placeholder
                tbUsername.Text = "Username";
                tbUsername.ForeColor = Color.Gray;

                tbPassword.Text = "Password";
                tbPassword.ForeColor = Color.Gray;
                tbPassword.UseSystemPasswordChar = false;
            }
        }

        private void Save_LoggedInUser_ToFile()
        {
            string json = JsonConvert.SerializeObject(_RememberedLogin, Formatting.Indented);
            File.WriteAllText(_FilePath, json);
        }

        private void Load_LoggedInUser_FromFile()
        {
            string json = File.ReadAllText("LoggedInUser_Credentials.json");
            _RememberedLogin = JsonConvert.DeserializeObject<clsRememberedLogin> (json);
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Username")
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;
            }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                tbUsername.Text = "Username";
                tbUsername.ForeColor = Color.Gray;
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Password")
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;
                tbPassword.UseSystemPasswordChar = true;
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                tbPassword.UseSystemPasswordChar = false;
                tbPassword.ForeColor = Color.Gray;
                tbPassword.Text = "Password";
            }
        }
    }
}
