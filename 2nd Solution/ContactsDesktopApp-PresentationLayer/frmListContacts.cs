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

namespace ContactsDesktopApp_PresentationLayer
{
    public partial class frmListContacts : Form
    {
        public frmListContacts()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dgvContacts.DataSource = clsContact.GetAllContacts();
        }

        private void frmListContacts_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            frmAddEditContact form = new frmAddEditContact(-1);

            form.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ContactToEdit = (int)dgvContacts.CurrentRow.Cells[0].Value;

            frmAddEditContact form = new frmAddEditContact(ContactToEdit);
            form.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact [" + dgvContacts.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK) 
            {
                if (clsContact.DeleteContact((int)dgvContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.", "Done");
                }

                else
                    MessageBox.Show("Contact is not Deleted, Operation Canceled.", "Canceled");
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }
    }
}
