using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ContactsBusinessLayer; //BL
using CountriesBussinessLayer; //Bl

namespace ContactsDesktopApp_PresentationLayer
{
    public partial class frmAddEditContact : Form
    {
        private clsContact.enMode _Mode = clsContact.enMode.AddNew;

        private int _ContactID = -1;
        private clsContact _Contact;

        public frmAddEditContact( int ContactID )
        {
            InitializeComponent();

            _ContactID = ContactID;

            if (_ContactID == -1)
                _Mode = clsContact.enMode.AddNew;
            else
                _Mode = clsContact.enMode.Update;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach( DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
            
            cbCountry.SelectedIndex = 0;
        }
        private void _FillContactDetailsInEditForm(clsContact contact)
        {
            lblContactID.Text = contact.ID.ToString();
            txtFirstName.Text = contact.FirstName;
            txtLastName.Text = contact.LastName;
            txtEmail.Text = contact.Email;
            txtPhone.Text = contact.Phone;
            txtAddress.Text = contact.Address;
            dtpDateOfBirth.Value = contact.DateOfBirth;

            if (contact.ImagePath != string.Empty)
            {
                pbContactImage.Load(contact.ImagePath);
                llRemoveImage.Visible = true;
            }

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(contact.CountryID).CountryName);
        }

        private void _LoadData()
        {
            _FillCountriesInComboBox();

            if (_Mode == clsContact.enMode.AddNew)
            {
                lblMode.Text = "Add New Contact";
                _Contact = new clsContact();
                return;
            }

            _Contact = clsContact.Find(_ContactID);

            if (_Contact == null)
            {
                MessageBox.Show($"Contact with ID = {_ContactID} Not Found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            //arriving here means _Contact is filled with the correct info
            lblMode.Text = "Edit Contact ID = " + _ContactID;
            _FillContactDetailsInEditForm(_Contact);
          

        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _FillContactObjectWithDetails()
        {
            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAddress.Text;
            _Contact.DateOfBirth = dtpDateOfBirth.Value;
            _Contact.CountryID = clsCountry.Find(cbCountry.Text).CountryID;

            if (pbContactImage != null)
                _Contact.ImagePath = pbContactImage.ImageLocation;
            else
                _Contact.ImagePath = string.Empty;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillContactObjectWithDetails();

            if (_Contact.Save())
                MessageBox.Show("Data Saved Successfully.", "Done");
            else
                MessageBox.Show("Error: Data is NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _Mode = clsContact.enMode.Update;
            lblMode.Text = "Edit Contact ID = " + _Contact.ID;
            lblContactID.Text = _Contact.ID.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbContactImage.ImageLocation = null;
            llRemoveImage.Visible = false;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbContactImage.Load(openFileDialog1.FileName);
            }

            llRemoveImage.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            dtpDateOfBirth.Value = DateTime.Now;
            cbCountry.SelectedItem = cbCountry.Items[0];

            pbContactImage.ImageLocation = null;
            llRemoveImage.Visible = false;
        }
    }
}
