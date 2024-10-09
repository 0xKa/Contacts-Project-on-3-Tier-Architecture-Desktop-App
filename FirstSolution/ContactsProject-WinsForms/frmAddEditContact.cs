using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ContactsBusinessLayer;
using CountriesBussinessLayer;

namespace ContactsProject_WinsForms
{
    public partial class frmAddEditContact : Form
    {
        ContactsBusinessLayer.clsContact.enMode _Mode = clsContact.enMode.AddNew;

        private int _ContactID { get; }
        private clsContact _Contact;

        //when opening this form the constructer will requset a ContactID
        public frmAddEditContact(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;
            if (_ContactID == -1 )
                _Mode = clsContact.enMode.AddNew;
            else
                _Mode = clsContact.enMode.Update;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            
            foreach (DataRow dataRow in dtCountries.Rows)
            {
                cbCountries.Items.Add(dataRow["CountryName"].ToString());
            }
        }

        private void _LoadData()
        {
            _FillCountriesInComboBox();
            cbCountries.SelectedIndex = 0;

            if (_Mode == clsContact.enMode.AddNew)
            {
                lblMode.Text = "Add New Contact";
                _Contact = new clsContact();

            }
            else
            {
                _Contact = clsContact.Find(_ContactID);

                if ( _Contact == null )
                {
                    MessageBox.Show("Error, Contact Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); //close the form

                    return; //exit the func
                }

                lblMode.Text = "Edit Contact ID = " + _ContactID;
                lblContactID.Text = _ContactID.ToString();
                txbFirstName.Text = _Contact.FirstName;
                txbLastName.Text = _Contact.LastName;
                txbEmail.Text = _Contact.Email;
                txbPhone.Text = _Contact.Phone;
                txbAddress.Text = _Contact.Address;
                dtpDateOfBirth.Value = _Contact.DateOfBirth;

                if (_Contact.ImagePath != string.Empty)
                {
                    try
                    {
                        pbContactImage.Load(_Contact.ImagePath);
                    }
                    catch (Exception ex)
                    {
                        _Contact.ImagePath = string.Empty;
                    }

                    llRemoveImage.Visible = true;
                }

                cbCountries.SelectedIndex = cbCountries.FindString(clsCountry.Find(_Contact.CountryID).CountryName);
            }
        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Contact.FirstName = txbFirstName.Text;
            _Contact.LastName = txbLastName.Text;
            _Contact.Email = txbEmail.Text;
            _Contact.Phone = txbPhone.Text;
            _Contact.Address = txbAddress.Text;
            _Contact.DateOfBirth = dtpDateOfBirth.Value;
            _Contact.CountryID = clsCountry.Find(cbCountries.Text).CountryID; //get the id of the selected country

            if (pbContactImage.ImageLocation != null && pbContactImage.Image != Properties.Resources.unknown)
                _Contact.ImagePath = pbContactImage.ImageLocation;
            else
                _Contact.ImagePath = string.Empty;

            if (_Contact.Save())
                MessageBox.Show("Contact Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error, Saving Contact Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _Mode = clsContact.enMode.Update;
            lblMode.Text = "Edit Contact ID = " + _Contact.ID;
            lblContactID.Text = _Contact.ID.ToString();

        }
    }
}
