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
    public partial class FrmPersonDetails : Form
    {
        public FrmPersonDetails()
        {
            InitializeComponent();
        }

        public delegate void PersonUpdatedEventHandler(object sender, clsPerson updatedPerson);

        public PersonUpdatedEventHandler PersonUpdated;

        clsPerson _Person;
        public FrmPersonDetails(clsPerson person)
        {
            InitializeComponent();
            _Person = person;
        }
        private void LoadPersonData()
        {

            /*//string fullname = "";
            //fullname = _Person.FirstName;
            //fullname += !string.IsNullOrEmpty(_Person.SecondName) ? " " + _Person.SecondName : "";
            //fullname += !string.IsNullOrEmpty(_Person.ThirdName) ? " " + _Person.ThirdName : "";
            //fullname += " " + _Person.LastName;

            //string path = _Person.ImagePath;

            //ctrlPersonDetails1.PersonID = _Person.PersonID;
            //ctrlPersonDetails1.NationalNo = _Person.NationalNo;
            //ctrlPersonDetails1.FullName = fullname;
            //ctrlPersonDetails1.Country = _Person.Country;
            //ctrlPersonDetails1.Address = _Person.Address;
            //ctrlPersonDetails1.Gender = _Person.Gender;
            //ctrlPersonDetails1.PersonImage = clsImageHelper.LoadPersonImage(ref path);
            //_Person.ImagePath = path;
            //if (!clsImageHelper.Is_ImagePath_Valid(_Person.ImagePath))
            //{
            //    _Person.ImagePath = clsPerson.DEFAULT_NULL_IMAGE;
            //}

            //ctrlPersonDetails1.ImagePath = _Person.ImagePath;
            //ctrlPersonDetails1.BirthDate = _Person.BirthDate;
            //ctrlPersonDetails1.Phone = _Person.Phone;
            //ctrlPersonDetails1.Email = _Person.Email;*/

            ctrlPersonDetails1.LoadControls(_Person);
            /* Handler "PersonDetailsChanged" Subscribes to 
             * the event that sends Data back to Form1 */
            ctrlPersonDetails1.PersonDetailsChanged += (s, updatedPerson) =>
            {
                PersonUpdated?.Invoke(this, updatedPerson);
                // Then Load updated data into the FrmPersonDetails Form
                _Person = clsPerson.FindPersonByID(_Person.PersonID);
                LoadPersonData();
            };

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPersonDetails_Load(object sender, EventArgs e)
        {
            LoadPersonData();
        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
