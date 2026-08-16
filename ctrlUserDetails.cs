using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD___Business_Layer;

namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    public partial class ctrlUserDetails : UserControl
    {
        clsUser _User;

        public delegate void PersonUpdatedEventHandler(object sender, clsPerson person);
        public PersonUpdatedEventHandler PersonUpdated;
        public ctrlUserDetails()
        {
            InitializeComponent();
            ctrlPersonDetails1.PersonDetailsChanged += (s, updatedperson) =>
            {
                PersonUpdated?.Invoke(s, updatedperson);
            };
        }

        //public clsUser User
        //{
        //    get { return _User; }
        //    set
        //    {
        //        _User = value;
        //        if (_User != null)
        //        {
        //            LoadData();
        //        }
        //    }
        //}

        public void LoadControls(clsUser user)
        {
            _User = user;
            ctrlPersonDetails1.LoadControls(_User.person);

            // My 1st approach NOT optimized (it requires me to handle the loading of the subcontrols from each Form I call the user control from)
            /*//ctrlPersonDetails1.Person = person;
            //ctrlPersonDetails1.PersonID = person.PersonID;
            //ctrlPersonDetails1.NationalNo = person.NationalNo;

            //string fullname = "";
            //fullname += person.FirstName;

            //if (!string.IsNullOrEmpty(person.SecondName))
            //    fullname += " " + person.SecondName;

            //if (!string.IsNullOrEmpty(person.ThirdName))
            //    fullname += " " + person.ThirdName;

            //fullname += " " + person.LastName;

            //ctrlPersonDetails1.FullName = fullname;
            //ctrlPersonDetails1.Gender = person.Gender;
            //ctrlPersonDetails1.BirthDate = person.BirthDate;

            //string imagepath = person.ImagePath;
            //ctrlPersonDetails1.PersonImage = clsImageHelper.LoadPersonImage(ref imagepath);
            //if (!clsImageHelper.Is_ImagePath_Valid(imagepath))
            //{
            //    person.ImagePath = clsPerson.DEFAULT_NULL_IMAGE;
            //}

            //_User.person.ImagePath = person.ImagePath;
            //ctrlPersonDetails1.ImagePath = person.ImagePath;

            //ctrlPersonDetails1.Country = person.Country;
            //ctrlPersonDetails1.Address = person.Address;

            //if (!string.IsNullOrEmpty(person.Phone))
            //    ctrlPersonDetails1.Phone = person.Phone;

            //ctrlPersonDetails1.Email = person.Email;*/

            // My current approach: I let the usercontrol handle the loading of its fields internally (optimized)

            // Load login info controls
            this.lblUsername.Text = _User.UserName;
            this.lblUserID.Text = _User.UserID.ToString();
            this.lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";
        }

        private void ctrlUserDetails_Load(object sender, EventArgs e)
        {
            
        }
    }
}
