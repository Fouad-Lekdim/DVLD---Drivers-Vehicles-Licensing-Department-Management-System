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
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            FrmAddNewUser frmAddNewUser = new FrmAddNewUser(-1);
            frmAddNewUser.UserAdded += _RefreshUsersList;
            frmAddNewUser.ShowDialog();
        }

        void _RefreshUsersList(object sender)
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();
            lblRecords.Text = "# " + dgvUsers.Rows.Count.ToString() + "  Records";
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList(this);
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddNewUser FrmEditUser = new FrmAddNewUser((int)dgvUsers.CurrentRow.Cells["UserID"].Value);
            FrmEditUser.UserEdited += _RefreshUsersList;
            FrmEditUser.ShowDialog();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvUsers.CurrentRow.Cells["UserID"].Value;
            clsUser selectedUser = clsUser.FindUserByID(userID);
            if (MessageBox.Show($"Are you sure you want to delete user with ID = {userID}", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(selectedUser))
                {
                    MessageBox.Show($"User with ID = {userID} Deleted successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedUser = new clsUser();
                    _RefreshUsersList(this);
                    return;
                }
                
                MessageBox.Show($"Faile to delete user with ID = {userID}", "Failure",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void showUserDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId = (int)dgvUsers.CurrentRow.Cells["UserID"].Value;
            clsUser selectedUser = clsUser.FindUserByID(userId);
            FrmUserDetails frmUserDetails = new FrmUserDetails(selectedUser);

            frmUserDetails.PersonUpdated += (s, updatedPerson) => _RefreshUsersList(this);

            frmUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvUsers.CurrentRow.Cells["UserID"].Value;
            clsUser selectedUser = clsUser.FindUserByID(userID);
            FrmChangePassword frmChangePassword = new FrmChangePassword(selectedUser);
            frmChangePassword.ShowDialog();
        }
    }
}
