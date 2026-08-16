using DVLD___Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    public partial class ctrlPersonCard : UserControl
    {
        public ctrlPersonCard()
        {
            InitializeComponent();

            /* Restrict the DateTime Picker for Birth Date */
            dtpBirthDate.MaxDate = DateTime.Now.AddYears(-18);
            dtpBirthDate.MinDate = DateTime.Now.AddYears(-100);

            llRemoveImage.Visible = false;
            rbMale.Checked = true;
        }

        //clsPerson _Person;
        //public clsPerson Person 
        //{
        //    get { return _Person; }
        //    set
        //    {

        //        _Person = value;
        //        if (_Person != null)
        //        {
        //            LoadControls();
        //        }
        //    } 
        //}

        //public bool RemoveImageLinkVisible
        //{
        //    set { llRemoveImage.Visible = value; }
        //}

        //public bool RemoveImageLinkEnable
        //{
        //    set { llRemoveImage.Enabled = value; }
        //}

        //[DefaultValue(-1)]
        //public int PersonID
        //{
        //    get
        //    {
        //        int.TryParse(lblPersonID.Text, out int result);
        //        return result;
        //    }
        //    set { lblPersonID.Text = value.ToString(); }
        //}

        //[DefaultValue(-1)]
        //public int NationalNo
        //{
        //    get
        //    {
        //        int.TryParse(tbNationalNo.Text, out int result);
        //        return result;
        //    }
        //    set { tbNationalNo.Text = value.ToString(); }
        //}
        //public string FirstName
        //{
        //    get { return this.tbFirstname.Text; }
        //    set { tbFirstname.Text = value; }
        //}
        //public string SecondName
        //{
        //    get { return this.tbSecondname.Text; }
        //    set { tbSecondname.Text = value; }
        //}
        //public string ThirdName
        //{
        //    get { return this.tbThirdname.Text; }
        //    set { tbThirdname.Text = value; }
        //}
        //public string LastName
        //{
        //    get { return this.tbLastname.Text; }
        //    set { tbLastname.Text = value; }
        //}
        //public string Gender
        //{
        //    get
        //    {
        //        if (this.rbMale.Checked)
        //            return "Male";
        //        else
        //            return "Female";
        //    }
        //    set
        //    {
        //        rbMale.Checked = (value == "Male");
        //        rbFemale.Checked = (value == "Female");
        //    }
        //}
        //public DateTime BirthDate
        //{
        //    get { return this.dtpBirthDate.Value; }
        //    set { dtpBirthDate.Value = value; }
        //}
        //public string Country
        //{
        //    get { return this.cbCountry.Text; }
        //    set { cbCountry.Text = value; }
        //}
        //public string Address
        //{
        //    get { return this.tbAddress.Text; }
        //    set { tbAddress.Text = value; }
        //}
        //public string Phone
        //{
        //    get { return this.tbPhone.Text; }
        //    set { tbPhone.Text = value; }
        //}
        //public string Email
        //{
        //    get { return this.tbEmail.Text; }
        //    set { tbEmail.Text = value; }
        //}
        //public Image PersonImage
        //{
        //    get { return pBPersonImage.Image; }
        //    set { pBPersonImage.Image = value; }
        //}

        //public string ImagePath { get; set; }

        public event EventHandler ValidationChanged;

        private bool Is_NNo_Valid;
        private bool Is_FName_Valid;
        private bool Is_LName_Valid;
        private bool Is_Email_Valid;
        private bool Is_Country_Valid;
        private bool Is_Address_Valid;
        public bool IsValid
        {
            get
            {
                bool isValid = true;
                isValid &= Is_NNo_Valid;
                isValid &= Is_FName_Valid;
                isValid &= Is_LName_Valid;
                isValid &= Is_Email_Valid;
                isValid &= Is_Country_Valid;
                isValid &= Is_Address_Valid;

                // Add other validation checks as needed
                return isValid;
            }
        }

        public void LoadPersonIDControl(int personID)
        {
            this.lblPersonID.Text = personID.ToString();
        }
        public void LoadPerson(ref clsPerson person)
        {
            
            if (tbNationalNo.Text != null && int.TryParse(tbNationalNo.Text, out int NNo))
            {
                person.NationalNo = NNo;
            }

            person.FirstName = tbFirstname.Text;
            person.SecondName = tbSecondname.Text;
            person.ThirdName = tbThirdname.Text;
            person.LastName = tbLastname.Text;
            person.Gender = (rbMale.Checked) ? "Male" : "Female";
            person.BirthDate = dtpBirthDate.Value;
            person.Country = cbCountry.Text;
            person.Address = tbAddress.Text;
            person.Phone = tbPhone.Text;
            person.Email = tbEmail.Text;
            person.ImagePath = pBPersonImage.ImageLocation;
        }
        public void LoadControls(clsPerson person)
        {
            this.lblPersonID.Text = person.PersonID.ToString();
            this.tbNationalNo.Text = person.NationalNo.ToString();
            this.tbFirstname.Text = person.FirstName;
            this.tbSecondname.Text = person.SecondName;
            this.tbThirdname.Text = person.ThirdName;
            this.tbLastname.Text = person.LastName;
            if (person.Gender == "Male")
                this.rbMale.Checked = true;
            else
                this.rbFemale.Checked = true;

            this.dtpBirthDate.Value = person.BirthDate;
            this.cbCountry.Text = person.Country;
            this.tbAddress.Text = person.Address;
            this.tbPhone.Text = person.Phone;

            if (clsImageHelper.Is_Image_Exists(person.ImagePath))
            {
                this.pBPersonImage.Load(person.ImagePath);
            }
            else
            {
                this.pBPersonImage.Load(clsImageHelper.NullImagePath);
            }

            this.tbEmail.Text = person.Email;

            if (clsImageHelper.Is_Image_Set(pBPersonImage.ImageLocation))
            {
                this.llRemoveImage.Visible = true;
                this.llRemoveImage.Enabled = true;
            }
            else
            {
                this.llRemoveImage.Visible = false;
                this.llRemoveImage.Enabled = false;
            }
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }
        public bool validateFirstName()
        {
            if (string.IsNullOrWhiteSpace(tbFirstname.Text))
            {
                errorProvider1.SetError(tbFirstname, "Firstname is required!");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tbFirstname.Text, @"^[a-zA-Z\s]+$"))
            {
                errorProvider1.SetError(tbFirstname, "Firstname must contain only letters and spaces.");
                return false;
            }

            errorProvider1.SetError(tbFirstname, string.Empty);
            return true;
        }

        public bool validateLastName()
        {
            if (string.IsNullOrWhiteSpace(tbLastname.Text))
            {
                errorProvider1.SetError(tbLastname, "Lastname is required!");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tbLastname.Text, @"^[a-zA-Z\s]+$"))
            {
                errorProvider1.SetError(tbLastname, "Lastname must contain only letters and spaces.");
                return false;
            }

            errorProvider1.SetError(tbLastname, string.Empty);
            return true;
        }
        public bool ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                errorProvider1.SetError(tbEmail, "Email is required.");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tbEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(tbEmail, "Invalid email format, exemple: name@domain.com");
                return false;
            }

            errorProvider1.SetError(tbEmail, string.Empty);
            return true;
        }
        public bool ValidateCountry()
        {
            if (string.IsNullOrWhiteSpace(cbCountry.Text))
            {
                errorProvider1.SetError(cbCountry, "Country is required.");
                return false;
            }

            if (!cbCountry.Items.Contains(cbCountry.Text))
            {
                errorProvider1.SetError(cbCountry, "Please select a valid country from the list.");
                return false;
            }

            errorProvider1.SetError(cbCountry, string.Empty);
            return true;
        }

        public bool ValidateAddress()
        {
            if (string.IsNullOrEmpty(tbAddress.Text)) 
            { 
                errorProvider1.SetError(tbAddress, "Address is required.");
                return false;
            }

            errorProvider1.SetError(tbAddress, string.Empty);
            return true;
        } 
        public bool ValidateNationalNo()
        {
            if (string.IsNullOrWhiteSpace(tbNationalNo.Text))
            {
                errorProvider1.SetError(tbNationalNo, "National Number is required.");
                return false;
            }
            if (!int.TryParse(tbNationalNo.Text, out _)) 
            { 
                errorProvider1.SetError(tbNationalNo, "National Number must be a valid integer.");
                return false;
            }
            errorProvider1.SetError(tbNationalNo, string.Empty);
            return true;
        }

        public void FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow dr in dtCountries.Rows)
            {
                this.cbCountry.Items.Add(dr["CountryName"]);
            }

        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Select an Image";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pBPersonImage.Load(openFileDialog1.FileName);
                llRemoveImage.Visible = true;
                llRemoveImage.Enabled = true;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            switch (textBox.Name)
            {
                case "tbNationalNo":
                    this.Is_NNo_Valid = ValidateNationalNo();// Validate the National Number whenever the text changes
                    break;               // this shows the error provider message if the validation fails
                case "tbFirstname":
                    this.Is_FName_Valid = validateFirstName();
                    break;
                case "tbLastname":
                    this.Is_LName_Valid = validateLastName();
                    break;
                case "tbEmail":
                    this.Is_Email_Valid = ValidateEmail();
                    break;
                case "tbAddress":
                    this.Is_Address_Valid = ValidateAddress();
                    break;
                default:
                    return; // No validation for other text boxes
            }
                                  
            ValidationChanged?.Invoke(this, EventArgs.Empty);
        }

        void UpdateDefaultImage()
        {
            if (!clsImageHelper.Is_Image_Set(pBPersonImage.ImageLocation))
            {
                if (rbMale.Checked)
                {
                    pBPersonImage.Load(clsImageHelper.ManImagePath);
                }
                else if (rbFemale.Checked)
                {
                    pBPersonImage.Load(clsImageHelper.WomanImagePath);
                }
            }
        }

        //void UpdateDefaultImage()
        //{
        //    if (string.IsNullOrEmpty(_Person.ImagePath) || _Person.ImagePath == clsPerson.DEFAULT_MALE_IMAGE
        //            || _Person.ImagePath == clsPerson.DEFAULT_FEMALE_IMAGE
        //            || _Person.ImagePath == clsPerson.DEFAULT_NULL_IMAGE)
        //    {
        //        if (rbMale.Checked)
        //        {
        //            pBPersonImage.Image = Properties.Resources.man;
        //            _Person.ImagePath = clsPerson.DEFAULT_MALE_IMAGE;
        //        }
        //        else if (rbFemale.Checked)
        //        {
        //            pBPersonImage.Image = Properties.Resources.woman;
        //            _Person.ImagePath = clsPerson.DEFAULT_FEMALE_IMAGE;
        //        }
        //    }
        //}

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Is_Country_Valid = ValidateCountry();

            ValidationChanged?.Invoke(this, EventArgs.Empty);
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDefaultImage();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDefaultImage();
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pBPersonImage.ImageLocation = null;
            llRemoveImage.Visible = false;
            this.UpdateDefaultImage();
        }

        private void pBPersonImage_LocationChanged(object sender, EventArgs e)
        {
            UpdateDefaultImage();
        }
    }
}
