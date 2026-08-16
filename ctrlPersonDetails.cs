using DVLD___Business_Layer;
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

namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    public partial class ctrlPersonDetails : UserControl
    {
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }
        
        clsPerson _Person;
        
        //public int PersonID
        //{
        //    get 
        //    { 
        //        if (int.TryParse(lblpersonID.Text, out int personid))
        //            return personid;
        //        return -1;
        //    }
        //    set
        //    {
        //        lblpersonID.Text = value.ToString();
        //    }
        //}
        //public int NationalNo
        //{
        //    get
        //    {
        //        if (int.TryParse(lblNationalNo.Text, out int NNo))
        //            return NNo;
        //        else
        //            return -1;
        //    }
        //    set
        //    {
        //        lblNationalNo.Text = value.ToString();
        //    }
        //}
        //public string FullName
        //{
        //    get
        //    {
        //        return lblFullName.Text;
        //    }
        //    set
        //    {
        //        lblFullName.Text = value;
        //    }
        //}
        //public string Country
        //{
        //    get
        //    {
        //        return lblCountry.Text;
        //    }
        //    set
        //    {
        //        lblCountry.Text = value;
        //    }
        //}
        //public string Address
        //{
        //    get
        //    {
        //        return lblAddress.Text;
        //    }
        //    set
        //    {
        //        lblAddress.Text = value;
        //    }
        //}
        //public string Phone
        //{
        //    get
        //    {
        //        return lblPhone.Text;
        //    }
        //    set
        //    {
        //        lblPhone.Text = value;
        //    }
        //}
        //public string Email
        //{
        //    get { return lblEmail.Text; }
        //    set { lblEmail.Text = value; }
        //}

        //public Image PersonImage
        //{ 
        //    get { return pbPersonImage.Image; }
        //    set {  pbPersonImage.Image = value; }
        //}
        //public string ImagePath { get; set; }

        //public string Gender
        //{
        //    get { return lblGender.Text; }
        //    set { lblGender.Text = value; }
        //}
        
        //public DateTime BirthDate
        //{
        //    set 
        //    {
        //        lblBirthDate.Text = value.Day.ToString();
        //        lblBirthDate.Text += "/" + value.Month.ToString();
        //        lblBirthDate.Text += "/" + value.Year.ToString();
        //    }
        //}

        public delegate void PersonDetailsChangedEventHandler(object Sender, clsPerson person);
        public PersonDetailsChangedEventHandler PersonDetailsChanged;


        public void LoadControls(clsPerson person)
        {
            _Person = person;

            string fullname = "";
            fullname = person.FirstName;
            fullname += !string.IsNullOrEmpty(_Person.SecondName) ? " " + _Person.SecondName : "";
            fullname += !string.IsNullOrEmpty(_Person.ThirdName) ? " " + _Person.ThirdName : "";
            fullname += " " + _Person.LastName;

            string path = _Person.ImagePath;

            this.lblpersonID.Text = _Person.PersonID.ToString();
            this.lblNationalNo.Text = _Person.NationalNo.ToString();
            this.lblFullName.Text = fullname;
            this.lblCountry.Text = _Person.Country;
            this.lblAddress.Text = _Person.Address;
            this.lblGender.Text = _Person.Gender;

            if (!clsImageHelper.Is_ImagePath_Valid(_Person.ImagePath))
            {
                _Person.ImagePath = clsImageHelper.NullImagePath;
            }

            pbPersonImage.Load(_Person.ImagePath);

            string formattedBirthdate = "";
            formattedBirthdate += _Person.BirthDate.Day.ToString();
            formattedBirthdate += "/" + _Person.BirthDate.Month.ToString();
            formattedBirthdate += "/" + _Person.BirthDate.Year.ToString();
            this.lblBirthDate.Text = formattedBirthdate;
            this.lblPhone.Text = _Person.Phone;
            this.lblEmail.Text = _Person.Email;
        }

        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddNewPerson frmEditPerson = new FrmAddNewPerson(_Person);
            /* "PersonUpdatedThroughLink" Handler Subscribes to the event 
             * that forwards data to
                FrmPersonDetails */
            frmEditPerson.PersonSaved += (s, updatedPerson) =>
            {
                PersonDetailsChanged?.Invoke(s, updatedPerson); 
            };
            frmEditPerson.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
