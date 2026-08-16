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
    public partial class FrmUserDetails : Form
    {
        public clsUser _User;

        public delegate void PersonUpdatedEventHandler(object sender, clsPerson person);
        public PersonUpdatedEventHandler PersonUpdated;
        public FrmUserDetails()
        {
            InitializeComponent();
        }

        public FrmUserDetails(clsUser user)
        {
            InitializeComponent();
            _User = user;
        }

        private void FrmUserDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            ctrlUserDetails1.LoadControls(_User);

            ctrlUserDetails1.PersonUpdated += (s, updatedPerson) =>
            {
                // This Invocation is to update the data grid view in FrmUsers
                PersonUpdated?.Invoke(this, updatedPerson);

                // Load this Form
                _User.person = updatedPerson;
                _LoadData();
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
