namespace ContactsDesktopApp_PresentationLayer
{
    partial class frmListContacts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button btnAddNewContact;
            System.Windows.Forms.Button btnRefresh;
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnAddNewContact = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvContacts
            // 
            this.dgvContacts.AllowUserToAddRows = false;
            this.dgvContacts.AllowUserToDeleteRows = false;
            this.dgvContacts.AllowUserToOrderColumns = true;
            this.dgvContacts.AllowUserToResizeRows = false;
            this.dgvContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvContacts.CausesValidation = false;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvContacts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvContacts.Location = new System.Drawing.Point(0, 177);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.ReadOnly = true;
            this.dgvContacts.Size = new System.Drawing.Size(901, 225);
            this.dgvContacts.TabIndex = 0;
            // 
            // btnAddNewContact
            // 
            btnAddNewContact.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            btnAddNewContact.FlatAppearance.BorderSize = 5;
            btnAddNewContact.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            btnAddNewContact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            btnAddNewContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddNewContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            btnAddNewContact.Location = new System.Drawing.Point(503, 40);
            btnAddNewContact.Name = "btnAddNewContact";
            btnAddNewContact.Size = new System.Drawing.Size(172, 81);
            btnAddNewContact.TabIndex = 2;
            btnAddNewContact.Text = "Add New Contact";
            btnAddNewContact.UseVisualStyleBackColor = true;
            btnAddNewContact.Click += new System.EventHandler(this.btnAddNewContact_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::ContactsDesktopApp_PresentationLayer.Properties.Resources.edit_1159633;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::ContactsDesktopApp_PresentationLayer.Properties.Resources.remove_1828947;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnRefresh
            // 
            btnRefresh.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            btnRefresh.FlatAppearance.BorderSize = 5;
            btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            btnRefresh.Location = new System.Drawing.Point(266, 40);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(172, 81);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmListContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(901, 402);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnAddNewContact);
            this.Controls.Add(this.dgvContacts);
            this.Name = "frmListContacts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts List";
            this.Load += new System.EventHandler(this.frmListContacts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

