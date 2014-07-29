namespace PhotoTimeSync
{
    partial class UserControl2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.txtIntroduction = new System.Windows.Forms.TextBox();
            this.lstFolders = new System.Windows.Forms.ListBox();
            this.lstPictures = new System.Windows.Forms.ListBox();
            this.pnlPictureDetail = new System.Windows.Forms.Panel();
            this.lblAdjustedDateTime = new System.Windows.Forms.Label();
            this.hourUpDown = new PhotoTimeSync.MyNumericUpDown();
            this.minuteUpDown = new PhotoTimeSync.MyNumericUpDown();
            this.yearUpDown = new PhotoTimeSync.MyNumericUpDown();
            this.monthUpDown = new PhotoTimeSync.MyNumericUpDown();
            this.lblCorrectionValue = new System.Windows.Forms.Label();
            this.lblCorrection = new System.Windows.Forms.Label();
            this.lblOriginalDateTimeValue = new System.Windows.Forms.Label();
            this.secondUpDown = new PhotoTimeSync.MyNumericUpDown();
            this.dayUpDown = new PhotoTimeSync.MyNumericUpDown();
            this.lblOriginalDateTime = new System.Windows.Forms.Label();
            this.pnlPicturePreview = new System.Windows.Forms.Panel();
            this.headerControl1 = new PhotoTimeSync.HeaderControl();
            this.pnlPictureDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(487, 455);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(70, 22);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.Location = new System.Drawing.Point(3, 455);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(70, 22);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // txtIntroduction
            // 
            this.txtIntroduction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIntroduction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIntroduction.Location = new System.Drawing.Point(0, 55);
            this.txtIntroduction.Multiline = true;
            this.txtIntroduction.Name = "txtIntroduction";
            this.txtIntroduction.ReadOnly = true;
            this.txtIntroduction.Size = new System.Drawing.Size(554, 19);
            this.txtIntroduction.TabIndex = 8;
            this.txtIntroduction.Text = "Select a camera folder which date/time is OK or for which you want to apply an ad" +
    "-hoc time adjustment";
            // 
            // lstFolders
            // 
            this.lstFolders.FormattingEnabled = true;
            this.lstFolders.ItemHeight = 15;
            this.lstFolders.Location = new System.Drawing.Point(3, 77);
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.Size = new System.Drawing.Size(173, 139);
            this.lstFolders.TabIndex = 9;
            this.lstFolders.SelectedIndexChanged += new System.EventHandler(this.lstFolders_SelectedIndexChanged);
            // 
            // lstPictures
            // 
            this.lstPictures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPictures.FormattingEnabled = true;
            this.lstPictures.ItemHeight = 15;
            this.lstPictures.Location = new System.Drawing.Point(3, 230);
            this.lstPictures.Name = "lstPictures";
            this.lstPictures.Size = new System.Drawing.Size(173, 199);
            this.lstPictures.TabIndex = 16;
            this.lstPictures.SelectedIndexChanged += new System.EventHandler(this.lstPictures_SelectedIndexChanged);
            // 
            // pnlPictureDetail
            // 
            this.pnlPictureDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPictureDetail.Controls.Add(this.lblAdjustedDateTime);
            this.pnlPictureDetail.Controls.Add(this.hourUpDown);
            this.pnlPictureDetail.Controls.Add(this.minuteUpDown);
            this.pnlPictureDetail.Controls.Add(this.yearUpDown);
            this.pnlPictureDetail.Controls.Add(this.monthUpDown);
            this.pnlPictureDetail.Controls.Add(this.lblCorrectionValue);
            this.pnlPictureDetail.Controls.Add(this.lblCorrection);
            this.pnlPictureDetail.Controls.Add(this.lblOriginalDateTimeValue);
            this.pnlPictureDetail.Controls.Add(this.secondUpDown);
            this.pnlPictureDetail.Controls.Add(this.dayUpDown);
            this.pnlPictureDetail.Controls.Add(this.lblOriginalDateTime);
            this.pnlPictureDetail.Controls.Add(this.pnlPicturePreview);
            this.pnlPictureDetail.Location = new System.Drawing.Point(182, 77);
            this.pnlPictureDetail.Name = "pnlPictureDetail";
            this.pnlPictureDetail.Size = new System.Drawing.Size(375, 365);
            this.pnlPictureDetail.TabIndex = 0;
            // 
            // lblAdjustedDateTime
            // 
            this.lblAdjustedDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdjustedDateTime.AutoSize = true;
            this.lblAdjustedDateTime.Location = new System.Drawing.Point(10, 311);
            this.lblAdjustedDateTime.Name = "lblAdjustedDateTime";
            this.lblAdjustedDateTime.Size = new System.Drawing.Size(109, 15);
            this.lblAdjustedDateTime.TabIndex = 27;
            this.lblAdjustedDateTime.Text = "Adjusted date/time";
            // 
            // hourUpDown
            // 
            this.hourUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hourUpDown.Location = new System.Drawing.Point(236, 305);
            this.hourUpDown.Name = "hourUpDown";
            this.hourUpDown.Size = new System.Drawing.Size(33, 26);
            this.hourUpDown.TabIndex = 31;
            this.hourUpDown.Value = 11;
            this.hourUpDown.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // minuteUpDown
            // 
            this.minuteUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.minuteUpDown.Location = new System.Drawing.Point(265, 305);
            this.minuteUpDown.Name = "minuteUpDown";
            this.minuteUpDown.Size = new System.Drawing.Size(33, 26);
            this.minuteUpDown.TabIndex = 32;
            this.minuteUpDown.Value = 11;
            this.minuteUpDown.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // yearUpDown
            // 
            this.yearUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yearUpDown.Location = new System.Drawing.Point(98, 305);
            this.yearUpDown.Name = "yearUpDown";
            this.yearUpDown.Size = new System.Drawing.Size(74, 26);
            this.yearUpDown.TabIndex = 28;
            this.yearUpDown.Value = 2014;
            this.yearUpDown.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // monthUpDown
            // 
            this.monthUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.monthUpDown.Location = new System.Drawing.Point(168, 305);
            this.monthUpDown.Name = "monthUpDown";
            this.monthUpDown.Size = new System.Drawing.Size(33, 26);
            this.monthUpDown.TabIndex = 29;
            this.monthUpDown.Value = 11;
            this.monthUpDown.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // lblCorrectionValue
            // 
            this.lblCorrectionValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCorrectionValue.AutoSize = true;
            this.lblCorrectionValue.Location = new System.Drawing.Point(128, 340);
            this.lblCorrectionValue.Name = "lblCorrectionValue";
            this.lblCorrectionValue.Size = new System.Drawing.Size(81, 15);
            this.lblCorrectionValue.TabIndex = 36;
            this.lblCorrectionValue.Text = "1 day 2 hours";
            // 
            // lblCorrection
            // 
            this.lblCorrection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCorrection.AutoSize = true;
            this.lblCorrection.Location = new System.Drawing.Point(55, 340);
            this.lblCorrection.Name = "lblCorrection";
            this.lblCorrection.Size = new System.Drawing.Size(64, 15);
            this.lblCorrection.TabIndex = 35;
            this.lblCorrection.Text = "Correction";
            this.lblCorrection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOriginalDateTimeValue
            // 
            this.lblOriginalDateTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOriginalDateTimeValue.AutoSize = true;
            this.lblOriginalDateTimeValue.Location = new System.Drawing.Point(128, 283);
            this.lblOriginalDateTimeValue.Name = "lblOriginalDateTimeValue";
            this.lblOriginalDateTimeValue.Size = new System.Drawing.Size(119, 15);
            this.lblOriginalDateTimeValue.TabIndex = 34;
            this.lblOriginalDateTimeValue.Text = "2014/11/23 12:21:09";
            // 
            // secondUpDown
            // 
            this.secondUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.secondUpDown.Location = new System.Drawing.Point(294, 305);
            this.secondUpDown.Name = "secondUpDown";
            this.secondUpDown.Size = new System.Drawing.Size(33, 26);
            this.secondUpDown.TabIndex = 33;
            this.secondUpDown.Value = 11;
            this.secondUpDown.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // dayUpDown
            // 
            this.dayUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dayUpDown.Location = new System.Drawing.Point(197, 305);
            this.dayUpDown.Name = "dayUpDown";
            this.dayUpDown.Size = new System.Drawing.Size(33, 26);
            this.dayUpDown.TabIndex = 30;
            this.dayUpDown.Value = 11;
            this.dayUpDown.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // lblOriginalDateTime
            // 
            this.lblOriginalDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOriginalDateTime.AutoSize = true;
            this.lblOriginalDateTime.Location = new System.Drawing.Point(15, 283);
            this.lblOriginalDateTime.Name = "lblOriginalDateTime";
            this.lblOriginalDateTime.Size = new System.Drawing.Size(104, 15);
            this.lblOriginalDateTime.TabIndex = 26;
            this.lblOriginalDateTime.Text = "Original date/time";
            // 
            // pnlPicturePreview
            // 
            this.pnlPicturePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPicturePreview.Location = new System.Drawing.Point(0, 0);
            this.pnlPicturePreview.Name = "pnlPicturePreview";
            this.pnlPicturePreview.Size = new System.Drawing.Size(375, 263);
            this.pnlPicturePreview.TabIndex = 25;
            this.pnlPicturePreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPicturePreview_Paint);
            // 
            // headerControl1
            // 
            this.headerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("headerControl1.BackgroundImage")));
            this.headerControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headerControl1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerControl1.Label = "Select primary camera folder";
            this.headerControl1.Location = new System.Drawing.Point(0, 0);
            this.headerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.headerControl1.Name = "headerControl1";
            this.headerControl1.Size = new System.Drawing.Size(560, 44);
            this.headerControl1.TabIndex = 17;
            // 
            // UserControl2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.headerControl1);
            this.Controls.Add(this.pnlPictureDetail);
            this.Controls.Add(this.lstPictures);
            this.Controls.Add(this.lstFolders);
            this.Controls.Add(this.txtIntroduction);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(560, 480);
            this.pnlPictureDetail.ResumeLayout(false);
            this.pnlPictureDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TextBox txtIntroduction;
        private System.Windows.Forms.ListBox lstFolders;
        private System.Windows.Forms.ListBox lstPictures;
        private System.Windows.Forms.Panel pnlPictureDetail;
        private System.Windows.Forms.Label lblOriginalDateTimeValue;
        private MyNumericUpDown secondUpDown;
        private MyNumericUpDown minuteUpDown;
        private MyNumericUpDown hourUpDown;
        private MyNumericUpDown dayUpDown;
        private MyNumericUpDown monthUpDown;
        private MyNumericUpDown yearUpDown;
        private System.Windows.Forms.Label lblAdjustedDateTime;
        private System.Windows.Forms.Label lblOriginalDateTime;
        private System.Windows.Forms.Panel pnlPicturePreview;
        private System.Windows.Forms.Label lblCorrectionValue;
        private System.Windows.Forms.Label lblCorrection;
        private HeaderControl headerControl1;
    }
}
