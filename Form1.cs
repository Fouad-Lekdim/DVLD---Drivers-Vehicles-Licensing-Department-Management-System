using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD___Business_Layer;

namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshPeopleDataGrid(this, clsPerson.GetAllPeople());
            ctrlPersonFilter1.EnableDisableSearchBTN(false);
            btnAddNewPerson.Visible = false;
            ctrlPersonFilter1.PersonSearched += (s, dt) => RefreshPeopleDataGrid(s, dt);
            ctrlPersonFilter1.PersonAdded += (s, dt) => RefreshPeopleDataGrid(s);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            FrmAddNewPerson frmAddPerson = new FrmAddNewPerson();

            frmAddPerson.PersonSaved += (s, person) => RefreshPeopleDataGrid(s);

            frmAddPerson.ShowDialog();
        }

        public void RefreshPeopleDataGrid(object sender, DataTable dt = null)
        {
            if (dt != null)
                dgvPeople.DataSource = dt;
            else
                dgvPeople.DataSource = clsPerson.GetAllPeople();

            lblRecords.Text = "# " + dgvPeople.Rows.Count.ToString() + "  Records";
        }

        private void viewPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);

            FrmPersonDetails frmPersonDetails = new FrmPersonDetails(clsPerson.FindPersonByID(personID));

            frmPersonDetails.PersonUpdated += (s, updatedPerson) => RefreshPeopleDataGrid(s);

            //subscribe to Update through the event that is called by another method
            frmPersonDetails.ShowDialog();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);
            clsPerson selectedPerson = clsPerson.FindPersonByID(personID);
            FrmAddNewPerson frmEditPerson = new FrmAddNewPerson(selectedPerson);
            frmEditPerson.PersonSaved += (s, updatedPerson) => RefreshPeopleDataGrid(s);
            frmEditPerson.Show();
        }

        //private void tbSearchPerson_TextChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(tbSearchPerson.Text))
        //    {
        //        dgvPeople.DataSource = clsPerson.GetAllPeople();
        //        return;
        //    }

        //    DataTable dt = clsPerson.GetAllPeople();
        //    DataTable FilteredDt = dt.Clone();

        //    string columnName = cbSearchBy.Text;

        //    foreach (DataRow row in dt.Rows)
        //    {

        //        if (row[columnName].ToString().StartsWith(tbSearchPerson.Text))
        //            FilteredDt.ImportRow(row);
        //    }

        //    dgvPeople.DataSource = FilteredDt;
            
        //}

        /*private void _FillSearchByComboBox()
        {
            string[] searchByOptions = new string[] { "personID", "NationalNo", "FirstName" };
            cbSearchBy.Items.AddRange(searchByOptions);
        }*/

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            clsPerson selectedPerson = clsPerson.FindPersonByID(selectedID);

            // ==> TO DO: !!! ADD Code To prevent deleting Connected Person !!!  <==

            if (MessageBox.Show($"Are you sure you want to delete person with ID = {selectedID}", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPerson.DeletePerson(ref selectedPerson))
                {
                    MessageBox.Show("Selected Person deleted successfully:-)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedPerson = new clsPerson();
                    RefreshPeopleDataGrid(this, clsPerson.GetAllPeople());
                    return;
                }

                MessageBox.Show("Selected Person Deletion Failed :-(", "Failed", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

            }
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is NOT implemented yet!", "Phone Call", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is NOT implemented yet!", "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ctrlPersonFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
