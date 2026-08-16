namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    partial class FrmAddNewUser
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
            this.lblAddEditUser = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabAddNewUser = new System.Windows.Forms.TabControl();
            this.tabPagePersonInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonFilter1 = new DVLD_Management_System___Drivers_and_Vehicles_License_Department.ctrlPersonFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonDetails1 = new DVLD_Management_System___Drivers_and_Vehicles_License_Department.ctrlPersonDetails();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.tbConfirmPwd = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabAddNewUser.SuspendLayout();
            this.tabPagePersonInfo.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddEditUser
            // 
            this.lblAddEditUser.AutoSize = true;
            this.lblAddEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEditUser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblAddEditUser.Location = new System.Drawing.Point(364, 36);
            this.lblAddEditUser.Name = "lblAddEditUser";
            this.lblAddEditUser.Size = new System.Drawing.Size(206, 32);
            this.lblAddEditUser.TabIndex = 0;
            this.lblAddEditUser.Text = "Add New User";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_Management_System___Drivers_and_Vehicles_License_Department.Properties.Resources.icons8_close_48;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(783, 607);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 60);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabAddNewUser
            // 
            this.tabAddNewUser.Controls.Add(this.tabPagePersonInfo);
            this.tabAddNewUser.Controls.Add(this.tabPageLogin);
            this.tabAddNewUser.Location = new System.Drawing.Point(12, 71);
            this.tabAddNewUser.Name = "tabAddNewUser";
            this.tabAddNewUser.SelectedIndex = 0;
            this.tabAddNewUser.Size = new System.Drawing.Size(997, 530);
            this.tabAddNewUser.TabIndex = 6;
            // 
            // tabPagePersonInfo
            // 
            this.tabPagePersonInfo.Controls.Add(this.ctrlPersonFilter1);
            this.tabPagePersonInfo.Controls.Add(this.btnNext);
            this.tabPagePersonInfo.Controls.Add(this.ctrlPersonDetails1);
            this.tabPagePersonInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPagePersonInfo.Name = "tabPagePersonInfo";
            this.tabPagePersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePersonInfo.Size = new System.Drawing.Size(989, 501);
            this.tabPagePersonInfo.TabIndex = 0;
            this.tabPagePersonInfo.Text = "Person details";
            this.tabPagePersonInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonFilter1
            // 
            this.ctrlPersonFilter1.Location = new System.Drawing.Point(19, 24);
            this.ctrlPersonFilter1.Name = "ctrlPersonFilter1";
            this.ctrlPersonFilter1.Size = new System.Drawing.Size(958, 94);
            this.ctrlPersonFilter1.TabIndex = 7;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::DVLD_Management_System___Drivers_and_Vehicles_License_Department.Properties.Resources.icons8_forward_button_48;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(860, 432);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(106, 63);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(6, 112);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(971, 314);
            this.ctrlPersonDetails1.TabIndex = 5;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.chkIsActive);
            this.tabPageLogin.Controls.Add(this.tbConfirmPwd);
            this.tabPageLogin.Controls.Add(this.tbPassword);
            this.tabPageLogin.Controls.Add(this.label6);
            this.tabPageLogin.Controls.Add(this.label5);
            this.tabPageLogin.Controls.Add(this.lblUserID);
            this.tabPageLogin.Controls.Add(this.label3);
            this.tabPageLogin.Controls.Add(this.label2);
            this.tabPageLogin.Controls.Add(this.tbUsername);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 25);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(989, 501);
            this.tabPageLogin.TabIndex = 1;
            this.tabPageLogin.Text = "Login Info";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(236, 265);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(79, 20);
            this.chkIsActive.TabIndex = 9;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // tbConfirmPwd
            // 
            this.tbConfirmPwd.Location = new System.Drawing.Point(236, 203);
            this.tbConfirmPwd.Name = "tbConfirmPwd";
            this.tbConfirmPwd.PasswordChar = '*';
            this.tbConfirmPwd.Size = new System.Drawing.Size(138, 22);
            this.tbConfirmPwd.TabIndex = 8;
            this.tbConfirmPwd.TextChanged += new System.EventHandler(this.tbConfirmPwd_TextChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(236, 157);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(138, 22);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Confirm Password :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password :";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(232, 66);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(40, 20);
            this.lblUserID.TabIndex = 3;
            this.lblUserID.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "User ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName :";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(236, 112);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(138, 22);
            this.tbUsername.TabIndex = 0;
            this.tbUsername.TextChanged += new System.EventHandler(this.tbUsername_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD_Management_System___Drivers_and_Vehicles_License_Department.Properties.Resources.icons8_save_48;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(900, 607);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 60);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 675);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabAddNewUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAddEditUser);
            this.Name = "FrmAddNewUser";
            this.Text = "FrmAddNewUser";
            this.Load += new System.EventHandler(this.FrmAddNewUser_Load);
            this.tabAddNewUser.ResumeLayout(false);
            this.tabPagePersonInfo.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddEditUser;
        private System.Windows.Forms.Button btnClose;
        private ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.TabControl tabAddNewUser;
        private System.Windows.Forms.TabPage tabPagePersonInfo;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox tbConfirmPwd;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrlPersonFilter ctrlPersonFilter1;
    }
}