using BCrypt.Net;
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

namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        public FrmChangePassword(clsUser user)
        {
            InitializeComponent();
            _User = user;
        }


        clsUser _User;
        private bool _Is_Valid;
        private bool _Is_Valid_OldPassword;
        private bool _Is_Valid_NewPassword;
        private bool _Is_Match_NewPassword;
        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            _LoadData();
        }

        private void _LoadData()
        {
            ctrlUserDetails1.LoadControls(_User);
        }
        
        private void Validate_Inputs()
        {
            bool valid = true;
            valid &= _Is_Valid_OldPassword;
            valid &= _Is_Valid_NewPassword;
            valid &= _Is_Match_NewPassword;
            _Is_Valid = valid;
        }

        private bool Validate_OldPassword()
        {
            _Is_Valid_OldPassword = BCrypt.Net.BCrypt.Verify(tbCurrentPassword.Text, _User.Password);
            return _Is_Valid_OldPassword;
        }

        private bool Validate_NewPassword()
        {
            _Is_Valid_NewPassword = !string.IsNullOrEmpty(tbNewPassword.Text);
            return _Is_Valid_NewPassword;
        }

        private bool Validate_PasswordConfirmation()
        {
            _Is_Match_NewPassword = string.Equals(tbNewPassword.Text, tbConfirmPassword.Text);
            return _Is_Match_NewPassword;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.Password = BCrypt.Net.BCrypt.HashPassword(tbNewPassword.Text);

            if (_User.Save())
            {
                MessageBox.Show("Password changed Successfully :-)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Change Password :-(", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            if (!Validate_OldPassword())
            {
                errorProvider1.SetError(tbCurrentPassword, "Entered password don't match current user password");
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, string.Empty);
            }

            Validate_Inputs();
            this.btnSave.Enabled = _Is_Valid;
        }

        private void tbNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (!Validate_NewPassword())
            {
                errorProvider1.SetError(tbNewPassword, "New Password must Not be empty!");
            }
            else
            {
                errorProvider1.SetError (tbNewPassword, string.Empty);
            }

            Validate_Inputs();
            this.btnSave.Enabled = _Is_Valid;
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!Validate_PasswordConfirmation())
            {
                errorProvider1.SetError(tbConfirmPassword, "Password Mismatch!");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, string.Empty);
            }

            Validate_Inputs();
            this.btnSave.Enabled = _Is_Valid;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
