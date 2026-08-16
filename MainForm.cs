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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 FrmManagePeople = new Form1();
            FrmManagePeople.Show();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet", "Applications", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.Show();
        }

        private void showAccountInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserDetails frmUserDetails = new FrmUserDetails(clsGlobal.LoggedInUser);
            frmUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frmChangePassword = new FrmChangePassword(clsGlobal.LoggedInUser);
            frmChangePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
