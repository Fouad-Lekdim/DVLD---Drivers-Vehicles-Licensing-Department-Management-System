using DVLD___Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    public partial class FrmAddNewUser : Form
    {
        int _UserID;
        clsUser _User;
        clsPerson _Person;
        enum enMode { eAddNew, eEdit };
        enMode _Mode;

        public delegate void UserAddedEventHandler(object sender);
        public UserAddedEventHandler UserAdded;
        public UserAddedEventHandler UserEdited;

        public FrmAddNewUser()
        {
            InitializeComponent();
        }

        public FrmAddNewUser(int userId)
        {
            InitializeComponent();
            _UserID = userId;

            if (_UserID == -1)
            {
                _Mode = enMode.eAddNew;
            }
            else
            {
                _Mode= enMode.eEdit;
            }
        }

        bool _Is_Login_Valid
        {
            get
            {
                bool isValid = true;
                isValid &= _is_username_valid();
                isValid &= _is_password_valid();
                isValid &= _is_password_match();
                isValid &= tabPageLogin.Enabled;
                return isValid;
            }
        }

        bool _is_username_valid()
        {
            return !string.IsNullOrEmpty(tbUsername.Text);
        }

        bool _is_password_valid()
        {
            return !string.IsNullOrEmpty(tbPassword.Text);
        }

        bool _is_password_match()
        {
            return tbPassword.Text.Equals(tbConfirmPwd.Text);
        }

        private void FrmAddNewUser_Load(object sender, EventArgs e)
        {

            if (_Mode == enMode.eAddNew)
            {
                lblAddEditUser.Text = "Add New User";
                _User = new clsUser();
                btnSave.Enabled = false;
                tabPageLogin.Enabled = false;
            }

            if (_Mode == enMode.eEdit)
            {
                lblAddEditUser.Text = "Edit User";
                _User = clsUser.FindUserByID(_UserID);
                DataLoad(this, _User.person);
            }

            ctrlPersonFilter1.PersonFound += DataLoad;
            ctrlPersonDetails1.PersonDetailsChanged += DataLoad;
        }

        private void DataLoad(object sender, clsPerson person)
        {
            _Person = person;
            if (person.PersonID == -1)
            {
                MessageBox.Show("person Not Found :-(", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
            ctrlPersonDetails1.LoadControls(person);
            
            // Find User based on the current person
            clsUser currUser = clsUser.FindUserByPersonID(person.PersonID);

            if (_Mode == enMode.eAddNew)
            {
                if (currUser.UserID == -1)
                {
                    _ResetLoginInfoFields();
                    return;
                }
                btnSave.Enabled = false;
                tabPageLogin.Enabled = false;

            }

            // In case the person has changed via the person filter in Edit Mode
            if (_Mode == enMode.eEdit)
            {                
                if (currUser.UserID == -1)
                {
                    if (MessageBox.Show($"person with ID = {person.PersonID} does not have user account! Do you want to create one?",
                            "User account missing", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        _Mode = enMode.eAddNew;
                        _ResetLoginInfoFields();
                        this.FrmAddNewUser_Load(this, EventArgs.Empty);
                        return;
                    }
                    else
                    {
                        DataLoad(this, _User.person);
                        return;
                    }
                }
                else
                {
                    _User = currUser;
                }
            }

            // Case : User already exists
            // Fill Login info fields part for both AddNew and Edit modes
            this.lblUserID.Text = currUser.UserID.ToString();
            this.tbUsername.Text = currUser.UserName.ToString();
            this.tbPassword.Text = currUser.Password.ToString();
            this.tbConfirmPwd.Text = currUser.Password.ToString();
            this.chkIsActive.Checked = currUser.IsActive;

            //// if the person selected through the filter has a user account, fill login controls
            //if (_Mode == enMode.eAddNew)
            //{
            //    clsUser filteredUser = new clsUser();
            //    filteredUser = clsUser.FindUserByPersonID(person.PersonID);

            //    if (filteredUser != null)
            //    {
            //        this.lblUserID.Text = filteredUser.UserID.ToString();
            //        this.tbUsername.Text = filteredUser.UserName.ToString();
            //        this.tbPassword.Text = filteredUser.Password.ToString();
            //        this.tbConfirmPwd.Text = filteredUser.Password.ToString();
            //        this.chkIsActive.Checked = filteredUser.IsActive;
            //    }
            //}
            //// if edit mode 
            //if (_Mode == enMode.eEdit)
            //{
            //    this.lblUserID.Text = _User.UserID.ToString();
            //    this.tbUsername.Text = _User.UserName.ToString();
            //    this.tbPassword.Text = _User.Password.ToString();
            //    this.tbConfirmPwd.Text = _User.Password.ToString();
            //    this.chkIsActive.Checked = _User.IsActive;
            //}
        }

        //void Save()
        //{
        //    switch (_Mode)
        //    {
        //        case enMode.eAddNew:
        //            if (clsUser.AddNewUser(_User))
        //            {
        //                MessageBox.Show("User Successfully Added :-)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                _Mode = enMode.eEdit;
        //                lblAddEditUser.Text = "Edit User";
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to add user :-(", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            break;
        //        case enMode.eEdit:
        //            if (clsUser.UpdateUser(_User))
        //            {
        //                MessageBox.Show("User Updated successfully:-)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to update user :-(", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}

        void _ResetLoginInfoFields()
        {
            lblUserID.Text = "N/A";
            tbUsername.Text = "";
            tbPassword.Text = "";
            tbConfirmPwd.Text = "";
            chkIsActive.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ctrlPersonFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Person == null || _Person.PersonID == -1)
            {
                MessageBox.Show("Select an existing Person First!", "Failed", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User = clsUser.FindUserByPersonID(_Person.PersonID);

            if (_User.UserID != -1 && _Mode == enMode.eAddNew)
            {
                MessageBox.Show("This person already has a user account!", "Failed",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabAddNewUser.SelectedTab = tabPageLogin;
            tabAddNewUser.SelectedTab.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /* 2nd wall of security: repeating a verification code Here 
             * already written in btnNext_Click event
             * for security in case Save button is enabled (first wall of security)
             * while the person already exist in AddNew Mode */
            if (_Mode == enMode.eAddNew)
            {
                _User = clsUser.FindUserByPersonID(_Person.PersonID);

                if (_User.UserID != -1)
                {
                    MessageBox.Show("This person already has a user account!", "Failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _User.UserName = tbUsername.Text;
            _User.Password = BCrypt.Net.BCrypt.HashPassword(tbPassword.Text);
            _User.IsActive = chkIsActive.Checked;
            _User.person = clsPerson.FindPersonByID(_Person.PersonID);

            if (_User.Save())
            {
                MessageBox.Show("User Successfully Saved :-)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.eEdit;
                lblAddEditUser.Text = "Edit User";
            }
            else
            {
                MessageBox.Show("Failed to Save User :-(", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.lblUserID.Text = _User.UserID.ToString();
            UserAdded?.Invoke(this);
            UserEdited?.Invoke(this);

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            if (!_is_username_valid())
            {
                errorProvider1.SetError(tbUsername, "Username cannot be empty.");
            }
            else
            {
                errorProvider1.SetError(tbUsername, string.Empty);
            }

            if (_Is_Login_Valid)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (!_is_password_valid())
            {
                errorProvider1.SetError(tbPassword, "Password cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(tbPassword, string.Empty);
            }

            if (_Is_Login_Valid)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void tbConfirmPwd_TextChanged(object sender, EventArgs e)
        {
            if (!_is_password_match())
            {
                errorProvider1.SetError(tbConfirmPwd, "Passwords do not match!");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPwd, string.Empty);
            }

            if (_Is_Login_Valid)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }
    }
}
