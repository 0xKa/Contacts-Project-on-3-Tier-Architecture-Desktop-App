using ContactsBusinessLayer; //contacts BL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsProject_WinsForms
{
    public partial class frmListContacts : Form
    {
        public frmListContacts()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dgvListContacts.DataSource = clsContact.GetAllContacts();
        }

        private void _FormattingListContactsDGV()
        {
            dgvListContacts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvListContacts.Columns["ImagePath"].Width = 200;
        }


        private void frmListContacts_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
            _FormattingListContactsDGV();

        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            frmAddEditContact frmAddEditContact = new frmAddEditContact(-1);
            frmAddEditContact.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact((int)dgvListContacts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshContactsList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are your sure your want to Delete Contact ID = [{dgvListContacts.CurrentRow.Cells[0].Value}]?","Deleting Contact",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Contact Deleted Successfully.");
                _RefreshContactsList();
            }
            else
                MessageBox.Show("Deleting Operation is Cancelled");

        }
    }
}
