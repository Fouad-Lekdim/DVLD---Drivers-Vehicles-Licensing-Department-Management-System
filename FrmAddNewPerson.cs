using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD___Business_Layer;

namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    public partial class FrmAddNewPerson : Form
    {
        enum Mode
        {
            eAddNew,
            eEdit
        }

        Mode _Mode;
        clsPerson _Person;
        public FrmAddNewPerson()
        {
            InitializeComponent();

            _Mode = Mode.eAddNew;
            _Person = new clsPerson();
        }
        public FrmAddNewPerson(clsPerson person)
        {
            InitializeComponent();
            _Mode = Mode.eEdit;
            _Person = person;
        }
        
        public void FrmAddEditPerson_ValidationChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = ctrlPersonCard1.IsValid;
        }


        public delegate void PersonSavedEventHandler(object sender, clsPerson person);
        public PersonSavedEventHandler PersonSaved;

        private void FrmAddNewPerson_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            ctrlPersonCard1.FillCountriesInComboBox();
            ctrlPersonCard1.ValidationChanged += FrmAddEditPerson_ValidationChanged;

            if (_Mode == Mode.eEdit)
            {
                this.lblTitle.Text = "Edit Person";
                ctrlPersonCard1.LoadControls(_Person);  
            }

            if (_Mode == Mode.eAddNew)
            {
                this.lblTitle.Text = "Add New Person";

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            // Fill person info through the form controls

            ctrlPersonCard1.LoadPerson(ref _Person);

            switch (_Person.Save())
            {
                case clsPerson.enSaveResults.eAddedSuccess:
                    ctrlPersonCard1.LoadPersonIDControl(_Person.PersonID);
                    this.lblTitle.Text = "Edit Person";
                    MessageBox.Show("Person Added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case clsPerson.enSaveResults.eUpdatedSuccess:
                    MessageBox.Show("Person Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case clsPerson.enSaveResults.eSvFailed:
                    MessageBox.Show("Failed to Save Person.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                default:
                    MessageBox.Show("Failed to Save Person.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            // this this reachable only if the person is successfully saved!
            PersonSaved?.Invoke(this, _Person);

            //if (_Person.Save() == clsPerson.enSaveResults.eAddedSuccess)
            //{

            //    MessageBox.Show("Person Added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    // better to Call the Save method of the clsPerson to Save the mode which determines
            //    // whether the person already exist or NOT not the developer to avoid unwanted mistakes.
            //    PersonSaved?.Invoke(this, _Person);
            //}
            //else
            //{
            //    MessageBox.Show("Failed to Save Person.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //public bool Save()
        //{
        //    switch (_Mode)
        //    {
        //        case Mode.eAddNew:
        //            int personID = clsPerson.AddNewPerson(_Person);
        //            if (personID != -1)
        //            {
        //                _Person.PersonID = personID;
        //                MessageBox.Show("New person added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                _Mode = Mode.eEdit; // Change mode to Edit after successful addition
        //                return true;
        //            }
        //            else
        //            {
        //                _Person.PersonID = -1;
        //                MessageBox.Show("Failed to add new person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
        //        case Mode.eEdit:
        //            if (clsPerson.UpdatedPerson(_Person))
        //            {
        //                MessageBox.Show("Person updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to update person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }                   
        //        default:
        //            return false;
        //    }
        //}
    }
}

