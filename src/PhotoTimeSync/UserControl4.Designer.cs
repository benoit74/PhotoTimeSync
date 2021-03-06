﻿namespace PhotoTimeSync
{
    partial class UserControl4
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Album1",
            "-15 seconds"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl4));
            this.lblIntroduction = new System.Windows.Forms.Label();
            this.lstCorrections = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblStatistics = new System.Windows.Forms.Label();
            this.btnDonatePaypal5Euros = new System.Windows.Forms.Button();
            this.btnDonatePaypalFreeAmount = new System.Windows.Forms.Button();
            this.btnFlattr = new System.Windows.Forms.Button();
            this.headerControl1 = new PhotoTimeSync.HeaderControl();
            this.btnTwitter = new System.Windows.Forms.Button();
            this.btnFacebook = new System.Windows.Forms.Button();
            this.chkRenamePhotos = new System.Windows.Forms.CheckBox();
            this.txtFilenamePrefixRename = new System.Windows.Forms.TextBox();
            this.btnShowLogs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIntroduction
            // 
            this.lblIntroduction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIntroduction.Location = new System.Drawing.Point(3, 48);
            this.lblIntroduction.Name = "lblIntroduction";
            this.lblIntroduction.Size = new System.Drawing.Size(677, 53);
            this.lblIntroduction.TabIndex = 0;
            this.lblIntroduction.Text = "Following time corrections will be applied to the pictures of each folders";
            this.lblIntroduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstCorrections
            // 
            this.lstCorrections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCorrections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstCorrections.FullRowSelect = true;
            this.lstCorrections.GridLines = true;
            this.lstCorrections.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstCorrections.Location = new System.Drawing.Point(3, 104);
            this.lstCorrections.MultiSelect = false;
            this.lstCorrections.Name = "lstCorrections";
            this.lstCorrections.Size = new System.Drawing.Size(677, 279);
            this.lstCorrections.TabIndex = 1;
            this.lstCorrections.UseCompatibleStateImageBehavior = false;
            this.lstCorrections.View = System.Windows.Forms.View.Details;
            this.lstCorrections.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCorrections_MouseDoubleClick);
            this.lstCorrections.Resize += new System.EventHandler(this.lstCorrections_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Folder name";
            this.columnHeader1.Width = 193;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Correction";
            this.columnHeader2.Width = 119;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Filename prefix";
            this.columnHeader3.Width = 120;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.Location = new System.Drawing.Point(3, 527);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(100, 23);
            this.btnPrev.TabIndex = 10;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(569, 527);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Go !";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Location = new System.Drawing.Point(3, 412);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(677, 27);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Text = "---";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgress.Visible = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuit.Location = new System.Drawing.Point(344, 527);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(150, 23);
            this.btnQuit.TabIndex = 14;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblStatistics
            // 
            this.lblStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatistics.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistics.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblStatistics.Location = new System.Drawing.Point(3, 444);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(677, 40);
            this.lblStatistics.TabIndex = 20;
            this.lblStatistics.Text = "---";
            this.lblStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatistics.Visible = false;
            // 
            // btnDonatePaypal5Euros
            // 
            this.btnDonatePaypal5Euros.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDonatePaypal5Euros.Location = new System.Drawing.Point(344, 494);
            this.btnDonatePaypal5Euros.Name = "btnDonatePaypal5Euros";
            this.btnDonatePaypal5Euros.Size = new System.Drawing.Size(96, 23);
            this.btnDonatePaypal5Euros.TabIndex = 14;
            this.btnDonatePaypal5Euros.Text = "5 Euros";
            this.btnDonatePaypal5Euros.UseVisualStyleBackColor = true;
            this.btnDonatePaypal5Euros.Click += new System.EventHandler(this.btnDonatePaypal5Euros_Click);
            // 
            // btnDonatePaypalFreeAmount
            // 
            this.btnDonatePaypalFreeAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDonatePaypalFreeAmount.Location = new System.Drawing.Point(443, 494);
            this.btnDonatePaypalFreeAmount.Name = "btnDonatePaypalFreeAmount";
            this.btnDonatePaypalFreeAmount.Size = new System.Drawing.Size(96, 23);
            this.btnDonatePaypalFreeAmount.TabIndex = 21;
            this.btnDonatePaypalFreeAmount.Text = "Free amount";
            this.btnDonatePaypalFreeAmount.UseVisualStyleBackColor = true;
            this.btnDonatePaypalFreeAmount.Click += new System.EventHandler(this.btnDonatePaypalFreeAmount_Click);
            // 
            // btnFlattr
            // 
            this.btnFlattr.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFlattr.BackColor = System.Drawing.Color.Transparent;
            this.btnFlattr.BackgroundImage = global::PhotoTimeSync.Pics.flattr_badge_large;
            this.btnFlattr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFlattr.FlatAppearance.BorderSize = 0;
            this.btnFlattr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlattr.Location = new System.Drawing.Point(554, 494);
            this.btnFlattr.Name = "btnFlattr";
            this.btnFlattr.Size = new System.Drawing.Size(100, 23);
            this.btnFlattr.TabIndex = 22;
            this.btnFlattr.UseVisualStyleBackColor = false;
            this.btnFlattr.Visible = false;
            this.btnFlattr.Click += new System.EventHandler(this.btnFlattr_Click);
            // 
            // headerControl1
            // 
            this.headerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("headerControl1.BackgroundImage")));
            this.headerControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headerControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerControl1.Label = "Apply correction to photos";
            this.headerControl1.Location = new System.Drawing.Point(0, 0);
            this.headerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.headerControl1.Name = "headerControl1";
            this.headerControl1.Size = new System.Drawing.Size(684, 44);
            this.headerControl1.TabIndex = 19;
            // 
            // btnTwitter
            // 
            this.btnTwitter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnTwitter.Location = new System.Drawing.Point(245, 494);
            this.btnTwitter.Name = "btnTwitter";
            this.btnTwitter.Size = new System.Drawing.Size(96, 23);
            this.btnTwitter.TabIndex = 23;
            this.btnTwitter.Text = "Twitter";
            this.btnTwitter.UseVisualStyleBackColor = true;
            this.btnTwitter.Click += new System.EventHandler(this.btnTwitter_Click);
            // 
            // btnFacebook
            // 
            this.btnFacebook.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFacebook.Location = new System.Drawing.Point(146, 494);
            this.btnFacebook.Name = "btnFacebook";
            this.btnFacebook.Size = new System.Drawing.Size(96, 23);
            this.btnFacebook.TabIndex = 24;
            this.btnFacebook.Text = "Facebook";
            this.btnFacebook.UseVisualStyleBackColor = true;
            this.btnFacebook.Click += new System.EventHandler(this.btnFacebook_Click);
            // 
            // chkRenamePhotos
            // 
            this.chkRenamePhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRenamePhotos.AutoSize = true;
            this.chkRenamePhotos.Location = new System.Drawing.Point(3, 389);
            this.chkRenamePhotos.Name = "chkRenamePhotos";
            this.chkRenamePhotos.Size = new System.Drawing.Size(85, 19);
            this.chkRenamePhotos.TabIndex = 25;
            this.chkRenamePhotos.Text = "checkBox1";
            this.chkRenamePhotos.UseVisualStyleBackColor = true;
            this.chkRenamePhotos.CheckedChanged += new System.EventHandler(this.chkRenamePhotos_CheckedChanged);
            // 
            // txtFilenamePrefixRename
            // 
            this.txtFilenamePrefixRename.Location = new System.Drawing.Point(406, 173);
            this.txtFilenamePrefixRename.Name = "txtFilenamePrefixRename";
            this.txtFilenamePrefixRename.Size = new System.Drawing.Size(100, 21);
            this.txtFilenamePrefixRename.TabIndex = 26;
            this.txtFilenamePrefixRename.Visible = false;
            this.txtFilenamePrefixRename.Leave += new System.EventHandler(this.txtFilenamePrefixRename_Leave);
            // 
            // btnShowLogs
            // 
            this.btnShowLogs.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowLogs.Location = new System.Drawing.Point(191, 527);
            this.btnShowLogs.Name = "btnShowLogs";
            this.btnShowLogs.Size = new System.Drawing.Size(150, 23);
            this.btnShowLogs.TabIndex = 27;
            this.btnShowLogs.Text = "Show logs";
            this.btnShowLogs.UseVisualStyleBackColor = true;
            this.btnShowLogs.Click += new System.EventHandler(this.btnShowLogs_Click);
            // 
            // UserControl4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShowLogs);
            this.Controls.Add(this.txtFilenamePrefixRename);
            this.Controls.Add(this.chkRenamePhotos);
            this.Controls.Add(this.btnFacebook);
            this.Controls.Add(this.btnTwitter);
            this.Controls.Add(this.btnFlattr);
            this.Controls.Add(this.btnDonatePaypalFreeAmount);
            this.Controls.Add(this.lblStatistics);
            this.Controls.Add(this.headerControl1);
            this.Controls.Add(this.btnDonatePaypal5Euros);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.lstCorrections);
            this.Controls.Add(this.lblIntroduction);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl4";
            this.Size = new System.Drawing.Size(684, 556);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIntroduction;
        private System.Windows.Forms.ListView lstCorrections;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnQuit;
        private HeaderControl headerControl1;
        private System.Windows.Forms.Label lblStatistics;
        private System.Windows.Forms.Button btnDonatePaypal5Euros;
        private System.Windows.Forms.Button btnDonatePaypalFreeAmount;
        private System.Windows.Forms.Button btnFlattr;
        private System.Windows.Forms.Button btnTwitter;
        private System.Windows.Forms.Button btnFacebook;
        private System.Windows.Forms.CheckBox chkRenamePhotos;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtFilenamePrefixRename;
        private System.Windows.Forms.Button btnShowLogs;
    }
}
