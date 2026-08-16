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
    public partial class ctrlPersonFilter : UserControl
    {
        public ctrlPersonFilter()
        {
            InitializeComponent();
        }

        enum eSearchFilter { ePersonID, eNationalNumber, eFirstName };
        eSearchFilter _SearchFilter;

        string[] _searchByOptions = new string[] { "personID", "NationalNo", "FirstName" };

        DataTable _FilteredList;
        clsPerson _Person;

        //public bool btnSearchEnabled
        //{
        //    get { return btnSearchPerson.Enabled; }
        //    set { btnSearchPerson.Enabled = value; }
        //}

        //public bool btnSearchVisible
        //{
        //    get { return btnSearchPerson.Visible; }
        //    set { btnSearchPerson.Visible = value;  }
        //}

        //public bool btnAddPersonEnabled
        //{
        //    get { return btnAddPerson.Enabled; }
        //    set { btnAddPerson.Enabled = value; }
        //}

        //public bool btnAddPersonVisible
        //{
        //    get { return btnAddPerson.Visible; }
        //    set { btnAddPerson.Visible = value; }
        //}

        public delegate void SearchPersonEventHandler(object sender, DataTable dt);
        public SearchPersonEventHandler PersonSearched;

        public delegate void PersonAddedEventHandler(object sender, clsPerson person);
        public PersonAddedEventHandler PersonAdded;

        public delegate void PersonFoundEventHandler(object sender, clsPerson person);
        public PersonFoundEventHandler PersonFound;

        public void EnableDisableSearchBTN(bool state)
        {
            btnSearchPerson.Enabled = state;
        }
        void _FillSearchByComboBox()
        {           
            cbSearchBy.Items.AddRange(_searchByOptions);
        }

        private void ctrlPersonFilter_Load(object sender, EventArgs e)
        { 
            this._FillSearchByComboBox();
            cbSearchBy.SelectedIndex = 0;
        }

        private void tbSearchPerson_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchPerson.Text))
            {
                _FilteredList = clsPerson.GetAllPeople();
                PersonSearched?.Invoke(this, _FilteredList);
                return;
            }

            string selectedFilter = cbSearchBy.Text;
            DataTable unfilteredList = clsPerson.GetAllPeople();

            _FilteredList = unfilteredList.Clone();

            foreach (DataRow row in unfilteredList.Rows)
            {
                if (row[selectedFilter].ToString().StartsWith(tbSearchPerson.Text))
                {
                    _FilteredList.ImportRow(row);
                }
            }

            PersonSearched?.Invoke(this, _FilteredList);
        }

        public DataTable GetFilteredPeopleList()
        {
            return _FilteredList;
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchPerson.Text)) { return; }

            switch (_SearchFilter)
            {
                case eSearchFilter.ePersonID:
                    _Person = clsPerson.FindPersonByID(Convert.ToInt32(tbSearchPerson.Text));
                    break;
                case eSearchFilter.eNationalNumber:
                    _Person = clsPerson.FindPersonByNNo(Convert.ToInt32(tbSearchPerson.Text));
                    break;
                case eSearchFilter.eFirstName:
                    _Person = clsPerson.FindPersonByFirstName(tbSearchPerson.Text);
                    break;
                default:
                    break;
            }

            PersonFound?.Invoke(this, _Person);
        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SearchFilter = (eSearchFilter)cbSearchBy.SelectedIndex;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            FrmAddNewPerson frmAddNewPerson = new FrmAddNewPerson();
            frmAddNewPerson.PersonSaved += SendPerson;
            frmAddNewPerson.ShowDialog();
        }

        private void SendPerson(object sender, clsPerson person)
        {
            _Person = person;
            this.PersonAdded?.Invoke(this, _Person);
            this.PersonFound?.Invoke(this, _Person);
        }
    }
}
