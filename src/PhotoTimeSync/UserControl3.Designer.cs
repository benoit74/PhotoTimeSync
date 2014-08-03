namespace PhotoTimeSync
{
    partial class UserControl3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl3));
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtIntroduction = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblSyncAlbums = new System.Windows.Forms.Label();
            this.lstSyncAlbums = new System.Windows.Forms.ListBox();
            this.lblAbsCorrectionSyncAlbumValue = new System.Windows.Forms.Label();
            this.lblAdjustedDateTimeSyncAlbum = new System.Windows.Forms.Label();
            this.lblAbsCorrectionSyncAlbum = new System.Windows.Forms.Label();
            this.lblAdjustedDateTimeSyncAlbumValue = new System.Windows.Forms.Label();
            this.lblSyncAlbumPicName = new System.Windows.Forms.Label();
            this.btnSyncAlbumNextPic = new System.Windows.Forms.Button();
            this.btnSyncAlbumPrevPic = new System.Windows.Forms.Button();
            this.pnlSyncAlbumPic = new System.Windows.Forms.Panel();
            this.lblPendingAlbums = new System.Windows.Forms.Label();
            this.lblPendingAlbumAbsCorrection = new System.Windows.Forms.Label();
            this.lblPendingAlbumAbsCorrectionValue = new System.Windows.Forms.Label();
            this.lblPendingAlbumOriginalDateTime = new System.Windows.Forms.Label();
            this.lblPendingAlbumAdjustedDateTime = new System.Windows.Forms.Label();
            this.udPendingAlbumYear = new PhotoTimeSync.MyNumericUpDown();
            this.udPendingAlbumMonth = new PhotoTimeSync.MyNumericUpDown();
            this.udPendingAlbumDay = new PhotoTimeSync.MyNumericUpDown();
            this.udPendingAlbumHour = new PhotoTimeSync.MyNumericUpDown();
            this.udPendingAlbumMinute = new PhotoTimeSync.MyNumericUpDown();
            this.udPendingAlbumSecond = new PhotoTimeSync.MyNumericUpDown();
            this.lblPendingAlbumOriginalDateTimeValue = new System.Windows.Forms.Label();
            this.btnPendingAlbumIsSync = new System.Windows.Forms.Button();
            this.lstPendingAlbums = new System.Windows.Forms.ListBox();
            this.lblPendingAlbumPicName = new System.Windows.Forms.Label();
            this.btnPendingAlbumNextPic = new System.Windows.Forms.Button();
            this.pnlPendingAlbumPic = new System.Windows.Forms.Panel();
            this.btnPendingAlbumPrevPic = new System.Windows.Forms.Button();
            this.headerControl1 = new PhotoTimeSync.HeaderControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.Location = new System.Drawing.Point(3, 571);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(100, 23);
            this.btnPrev.TabIndex = 9;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(785, 571);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtIntroduction
            // 
            this.txtIntroduction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIntroduction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIntroduction.Location = new System.Drawing.Point(3, 52);
            this.txtIntroduction.Multiline = true;
            this.txtIntroduction.Name = "txtIntroduction";
            this.txtIntroduction.ReadOnly = true;
            this.txtIntroduction.Size = new System.Drawing.Size(882, 36);
            this.txtIntroduction.TabIndex = 10;
            this.txtIntroduction.Text = "Select a synchronized album and a pending album. Then search for two photos taken" +
    " at the same time (or set the adujsted date/time of a given photo manually) and " +
    "validate synchronization.";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 89);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblSyncAlbums);
            this.splitContainer1.Panel1.Controls.Add(this.lstSyncAlbums);
            this.splitContainer1.Panel1.Controls.Add(this.lblAbsCorrectionSyncAlbumValue);
            this.splitContainer1.Panel1.Controls.Add(this.lblAdjustedDateTimeSyncAlbum);
            this.splitContainer1.Panel1.Controls.Add(this.lblAbsCorrectionSyncAlbum);
            this.splitContainer1.Panel1.Controls.Add(this.lblAdjustedDateTimeSyncAlbumValue);
            this.splitContainer1.Panel1.Controls.Add(this.lblSyncAlbumPicName);
            this.splitContainer1.Panel1.Controls.Add(this.btnSyncAlbumNextPic);
            this.splitContainer1.Panel1.Controls.Add(this.btnSyncAlbumPrevPic);
            this.splitContainer1.Panel1.Controls.Add(this.pnlSyncAlbumPic);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblPendingAlbums);
            this.splitContainer1.Panel2.Controls.Add(this.lblPendingAlbumAbsCorrection);
            this.splitContainer1.Panel2.Controls.Add(this.lblPendingAlbumAbsCorrectionValue);
            this.splitContainer1.Panel2.Controls.Add(this.lblPendingAlbumOriginalDateTime);
            this.splitContainer1.Panel2.Controls.Add(this.lblPendingAlbumAdjustedDateTime);
            this.splitContainer1.Panel2.Controls.Add(this.udPendingAlbumYear);
            this.splitContainer1.Panel2.Controls.Add(this.udPendingAlbumMonth);
            this.splitContainer1.Panel2.Controls.Add(this.udPendingAlbumDay);
            this.splitContainer1.Panel2.Controls.Add(this.udPendingAlbumHour);
            this.splitContainer1.Panel2.Controls.Add(this.udPendingAlbumMinute);
            this.splitContainer1.Panel2.Controls.Add(this.udPendingAlbumSecond);
            this.splitContainer1.Panel2.Controls.Add(this.lblPendingAlbumOriginalDateTimeValue);
            this.splitContainer1.Panel2.Controls.Add(this.btnPendingAlbumIsSync);
            this.splitContainer1.Panel2.Controls.Add(this.lstPendingAlbums);
            this.splitContainer1.Panel2.Controls.Add(this.lblPendingAlbumPicName);
            this.splitContainer1.Panel2.Controls.Add(this.btnPendingAlbumNextPic);
            this.splitContainer1.Panel2.Controls.Add(this.pnlPendingAlbumPic);
            this.splitContainer1.Panel2.Controls.Add(this.btnPendingAlbumPrevPic);
            this.splitContainer1.Size = new System.Drawing.Size(882, 479);
            this.splitContainer1.SplitterDistance = 440;
            this.splitContainer1.TabIndex = 14;
            // 
            // lblSyncAlbums
            // 
            this.lblSyncAlbums.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSyncAlbums.Location = new System.Drawing.Point(6, 10);
            this.lblSyncAlbums.Name = "lblSyncAlbums";
            this.lblSyncAlbums.Size = new System.Drawing.Size(431, 15);
            this.lblSyncAlbums.TabIndex = 74;
            this.lblSyncAlbums.Text = "Synchronized Albums";
            this.lblSyncAlbums.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstSyncAlbums
            // 
            this.lstSyncAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSyncAlbums.FormattingEnabled = true;
            this.lstSyncAlbums.ItemHeight = 15;
            this.lstSyncAlbums.Location = new System.Drawing.Point(6, 28);
            this.lstSyncAlbums.Name = "lstSyncAlbums";
            this.lstSyncAlbums.Size = new System.Drawing.Size(431, 79);
            this.lstSyncAlbums.TabIndex = 73;
            this.lstSyncAlbums.SelectedIndexChanged += new System.EventHandler(this.lstSyncAlbums_SelectedIndexChanged);
            // 
            // lblAbsCorrectionSyncAlbumValue
            // 
            this.lblAbsCorrectionSyncAlbumValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbsCorrectionSyncAlbumValue.AutoSize = true;
            this.lblAbsCorrectionSyncAlbumValue.Location = new System.Drawing.Point(155, 406);
            this.lblAbsCorrectionSyncAlbumValue.Name = "lblAbsCorrectionSyncAlbumValue";
            this.lblAbsCorrectionSyncAlbumValue.Size = new System.Drawing.Size(81, 15);
            this.lblAbsCorrectionSyncAlbumValue.TabIndex = 72;
            this.lblAbsCorrectionSyncAlbumValue.Text = "1 day 2 hours";
            // 
            // lblAdjustedDateTimeSyncAlbum
            // 
            this.lblAdjustedDateTimeSyncAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdjustedDateTimeSyncAlbum.Location = new System.Drawing.Point(0, 377);
            this.lblAdjustedDateTimeSyncAlbum.Name = "lblAdjustedDateTimeSyncAlbum";
            this.lblAdjustedDateTimeSyncAlbum.Size = new System.Drawing.Size(146, 15);
            this.lblAdjustedDateTimeSyncAlbum.TabIndex = 69;
            this.lblAdjustedDateTimeSyncAlbum.Text = "Adjusted date/time";
            this.lblAdjustedDateTimeSyncAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAbsCorrectionSyncAlbum
            // 
            this.lblAbsCorrectionSyncAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbsCorrectionSyncAlbum.Location = new System.Drawing.Point(0, 406);
            this.lblAbsCorrectionSyncAlbum.Name = "lblAbsCorrectionSyncAlbum";
            this.lblAbsCorrectionSyncAlbum.Size = new System.Drawing.Size(146, 15);
            this.lblAbsCorrectionSyncAlbum.TabIndex = 71;
            this.lblAbsCorrectionSyncAlbum.Text = "Absolute correction";
            this.lblAbsCorrectionSyncAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAdjustedDateTimeSyncAlbumValue
            // 
            this.lblAdjustedDateTimeSyncAlbumValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdjustedDateTimeSyncAlbumValue.AutoSize = true;
            this.lblAdjustedDateTimeSyncAlbumValue.Location = new System.Drawing.Point(154, 377);
            this.lblAdjustedDateTimeSyncAlbumValue.Name = "lblAdjustedDateTimeSyncAlbumValue";
            this.lblAdjustedDateTimeSyncAlbumValue.Size = new System.Drawing.Size(119, 15);
            this.lblAdjustedDateTimeSyncAlbumValue.TabIndex = 70;
            this.lblAdjustedDateTimeSyncAlbumValue.Text = "2014/11/23 12:21:09";
            // 
            // lblSyncAlbumPicName
            // 
            this.lblSyncAlbumPicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSyncAlbumPicName.Location = new System.Drawing.Point(6, 325);
            this.lblSyncAlbumPicName.Name = "lblSyncAlbumPicName";
            this.lblSyncAlbumPicName.Size = new System.Drawing.Size(431, 23);
            this.lblSyncAlbumPicName.TabIndex = 68;
            this.lblSyncAlbumPicName.Text = "label3";
            this.lblSyncAlbumPicName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSyncAlbumNextPic
            // 
            this.btnSyncAlbumNextPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncAlbumNextPic.Location = new System.Drawing.Point(415, 116);
            this.btnSyncAlbumNextPic.Name = "btnSyncAlbumNextPic";
            this.btnSyncAlbumNextPic.Size = new System.Drawing.Size(22, 209);
            this.btnSyncAlbumNextPic.TabIndex = 67;
            this.btnSyncAlbumNextPic.Text = ">";
            this.btnSyncAlbumNextPic.UseVisualStyleBackColor = true;
            this.btnSyncAlbumNextPic.Click += new System.EventHandler(this.btnSyncAlbumNextPic_Click);
            // 
            // btnSyncAlbumPrevPic
            // 
            this.btnSyncAlbumPrevPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSyncAlbumPrevPic.Location = new System.Drawing.Point(6, 116);
            this.btnSyncAlbumPrevPic.Name = "btnSyncAlbumPrevPic";
            this.btnSyncAlbumPrevPic.Size = new System.Drawing.Size(22, 209);
            this.btnSyncAlbumPrevPic.TabIndex = 66;
            this.btnSyncAlbumPrevPic.Text = "<";
            this.btnSyncAlbumPrevPic.UseVisualStyleBackColor = true;
            this.btnSyncAlbumPrevPic.Click += new System.EventHandler(this.btnSyncAlbumPrevPic_Click);
            // 
            // pnlSyncAlbumPic
            // 
            this.pnlSyncAlbumPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSyncAlbumPic.Location = new System.Drawing.Point(31, 116);
            this.pnlSyncAlbumPic.Name = "pnlSyncAlbumPic";
            this.pnlSyncAlbumPic.Size = new System.Drawing.Size(378, 209);
            this.pnlSyncAlbumPic.TabIndex = 65;
            this.pnlSyncAlbumPic.SizeChanged += new System.EventHandler(this.pnlSyncAlbumPic_SizeChanged);
            this.pnlSyncAlbumPic.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSyncAlbumPic_Paint);
            // 
            // lblPendingAlbums
            // 
            this.lblPendingAlbums.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPendingAlbums.Location = new System.Drawing.Point(6, 10);
            this.lblPendingAlbums.Name = "lblPendingAlbums";
            this.lblPendingAlbums.Size = new System.Drawing.Size(428, 15);
            this.lblPendingAlbums.TabIndex = 62;
            this.lblPendingAlbums.Text = "Pending Albums";
            this.lblPendingAlbums.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPendingAlbumAbsCorrection
            // 
            this.lblPendingAlbumAbsCorrection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendingAlbumAbsCorrection.Location = new System.Drawing.Point(3, 419);
            this.lblPendingAlbumAbsCorrection.Name = "lblPendingAlbumAbsCorrection";
            this.lblPendingAlbumAbsCorrection.Size = new System.Drawing.Size(145, 15);
            this.lblPendingAlbumAbsCorrection.TabIndex = 77;
            this.lblPendingAlbumAbsCorrection.Text = "Absolute correction";
            this.lblPendingAlbumAbsCorrection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPendingAlbumAbsCorrectionValue
            // 
            this.lblPendingAlbumAbsCorrectionValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendingAlbumAbsCorrectionValue.AutoSize = true;
            this.lblPendingAlbumAbsCorrectionValue.Location = new System.Drawing.Point(158, 419);
            this.lblPendingAlbumAbsCorrectionValue.Name = "lblPendingAlbumAbsCorrectionValue";
            this.lblPendingAlbumAbsCorrectionValue.Size = new System.Drawing.Size(81, 15);
            this.lblPendingAlbumAbsCorrectionValue.TabIndex = 78;
            this.lblPendingAlbumAbsCorrectionValue.Text = "1 day 2 hours";
            // 
            // lblPendingAlbumOriginalDateTime
            // 
            this.lblPendingAlbumOriginalDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendingAlbumOriginalDateTime.Location = new System.Drawing.Point(3, 362);
            this.lblPendingAlbumOriginalDateTime.Name = "lblPendingAlbumOriginalDateTime";
            this.lblPendingAlbumOriginalDateTime.Size = new System.Drawing.Size(145, 15);
            this.lblPendingAlbumOriginalDateTime.TabIndex = 68;
            this.lblPendingAlbumOriginalDateTime.Text = "Original date/time";
            this.lblPendingAlbumOriginalDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPendingAlbumAdjustedDateTime
            // 
            this.lblPendingAlbumAdjustedDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendingAlbumAdjustedDateTime.Location = new System.Drawing.Point(3, 387);
            this.lblPendingAlbumAdjustedDateTime.Name = "lblPendingAlbumAdjustedDateTime";
            this.lblPendingAlbumAdjustedDateTime.Size = new System.Drawing.Size(145, 20);
            this.lblPendingAlbumAdjustedDateTime.TabIndex = 69;
            this.lblPendingAlbumAdjustedDateTime.Text = "Adjusted date/time";
            this.lblPendingAlbumAdjustedDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // udPendingAlbumYear
            // 
            this.udPendingAlbumYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.udPendingAlbumYear.BackColor = System.Drawing.Color.Transparent;
            this.udPendingAlbumYear.Location = new System.Drawing.Point(141, 385);
            this.udPendingAlbumYear.Name = "udPendingAlbumYear";
            this.udPendingAlbumYear.Size = new System.Drawing.Size(62, 26);
            this.udPendingAlbumYear.TabIndex = 70;
            this.udPendingAlbumYear.Value = 2014;
            this.udPendingAlbumYear.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // udPendingAlbumMonth
            // 
            this.udPendingAlbumMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.udPendingAlbumMonth.BackColor = System.Drawing.Color.Transparent;
            this.udPendingAlbumMonth.Location = new System.Drawing.Point(188, 385);
            this.udPendingAlbumMonth.Name = "udPendingAlbumMonth";
            this.udPendingAlbumMonth.Size = new System.Drawing.Size(45, 26);
            this.udPendingAlbumMonth.TabIndex = 71;
            this.udPendingAlbumMonth.Value = 11;
            this.udPendingAlbumMonth.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // udPendingAlbumDay
            // 
            this.udPendingAlbumDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.udPendingAlbumDay.BackColor = System.Drawing.Color.Transparent;
            this.udPendingAlbumDay.Location = new System.Drawing.Point(221, 385);
            this.udPendingAlbumDay.Name = "udPendingAlbumDay";
            this.udPendingAlbumDay.Size = new System.Drawing.Size(43, 26);
            this.udPendingAlbumDay.TabIndex = 72;
            this.udPendingAlbumDay.Value = 11;
            this.udPendingAlbumDay.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // udPendingAlbumHour
            // 
            this.udPendingAlbumHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.udPendingAlbumHour.BackColor = System.Drawing.Color.Transparent;
            this.udPendingAlbumHour.Location = new System.Drawing.Point(261, 385);
            this.udPendingAlbumHour.Name = "udPendingAlbumHour";
            this.udPendingAlbumHour.Size = new System.Drawing.Size(42, 26);
            this.udPendingAlbumHour.TabIndex = 73;
            this.udPendingAlbumHour.Value = 11;
            this.udPendingAlbumHour.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // udPendingAlbumMinute
            // 
            this.udPendingAlbumMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.udPendingAlbumMinute.BackColor = System.Drawing.Color.Transparent;
            this.udPendingAlbumMinute.Location = new System.Drawing.Point(291, 385);
            this.udPendingAlbumMinute.Name = "udPendingAlbumMinute";
            this.udPendingAlbumMinute.Size = new System.Drawing.Size(43, 26);
            this.udPendingAlbumMinute.TabIndex = 74;
            this.udPendingAlbumMinute.Value = 11;
            this.udPendingAlbumMinute.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // udPendingAlbumSecond
            // 
            this.udPendingAlbumSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.udPendingAlbumSecond.BackColor = System.Drawing.Color.Transparent;
            this.udPendingAlbumSecond.Location = new System.Drawing.Point(320, 385);
            this.udPendingAlbumSecond.Name = "udPendingAlbumSecond";
            this.udPendingAlbumSecond.Size = new System.Drawing.Size(44, 26);
            this.udPendingAlbumSecond.TabIndex = 75;
            this.udPendingAlbumSecond.Value = 11;
            this.udPendingAlbumSecond.ValueChanged += new PhotoTimeSync.MyNumericUpDown.ValueChangedHandler(this.anUpDown_ValueChanged);
            // 
            // lblPendingAlbumOriginalDateTimeValue
            // 
            this.lblPendingAlbumOriginalDateTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendingAlbumOriginalDateTimeValue.AutoSize = true;
            this.lblPendingAlbumOriginalDateTimeValue.Location = new System.Drawing.Point(158, 362);
            this.lblPendingAlbumOriginalDateTimeValue.Name = "lblPendingAlbumOriginalDateTimeValue";
            this.lblPendingAlbumOriginalDateTimeValue.Size = new System.Drawing.Size(119, 15);
            this.lblPendingAlbumOriginalDateTimeValue.TabIndex = 76;
            this.lblPendingAlbumOriginalDateTimeValue.Text = "2014/11/23 12:21:09";
            // 
            // btnPendingAlbumIsSync
            // 
            this.btnPendingAlbumIsSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPendingAlbumIsSync.Location = new System.Drawing.Point(38, 447);
            this.btnPendingAlbumIsSync.Name = "btnPendingAlbumIsSync";
            this.btnPendingAlbumIsSync.Size = new System.Drawing.Size(359, 23);
            this.btnPendingAlbumIsSync.TabIndex = 61;
            this.btnPendingAlbumIsSync.Text = "Pending album is synchronized";
            this.btnPendingAlbumIsSync.UseVisualStyleBackColor = true;
            this.btnPendingAlbumIsSync.Click += new System.EventHandler(this.btnPendingAlbumIsSync_Click);
            // 
            // lstPendingAlbums
            // 
            this.lstPendingAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPendingAlbums.FormattingEnabled = true;
            this.lstPendingAlbums.ItemHeight = 15;
            this.lstPendingAlbums.Location = new System.Drawing.Point(6, 28);
            this.lstPendingAlbums.Name = "lstPendingAlbums";
            this.lstPendingAlbums.Size = new System.Drawing.Size(428, 79);
            this.lstPendingAlbums.TabIndex = 67;
            this.lstPendingAlbums.SelectedIndexChanged += new System.EventHandler(this.lstPendingAlbums_SelectedIndexChanged);
            // 
            // lblPendingAlbumPicName
            // 
            this.lblPendingAlbumPicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPendingAlbumPicName.Location = new System.Drawing.Point(6, 325);
            this.lblPendingAlbumPicName.Name = "lblPendingAlbumPicName";
            this.lblPendingAlbumPicName.Size = new System.Drawing.Size(427, 23);
            this.lblPendingAlbumPicName.TabIndex = 64;
            this.lblPendingAlbumPicName.Text = "label4";
            this.lblPendingAlbumPicName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPendingAlbumNextPic
            // 
            this.btnPendingAlbumNextPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPendingAlbumNextPic.Location = new System.Drawing.Point(412, 116);
            this.btnPendingAlbumNextPic.Name = "btnPendingAlbumNextPic";
            this.btnPendingAlbumNextPic.Size = new System.Drawing.Size(22, 209);
            this.btnPendingAlbumNextPic.TabIndex = 66;
            this.btnPendingAlbumNextPic.Text = ">";
            this.btnPendingAlbumNextPic.UseVisualStyleBackColor = true;
            this.btnPendingAlbumNextPic.Click += new System.EventHandler(this.btnPendingAlbumNextPic_Click);
            // 
            // pnlPendingAlbumPic
            // 
            this.pnlPendingAlbumPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPendingAlbumPic.Location = new System.Drawing.Point(33, 116);
            this.pnlPendingAlbumPic.Name = "pnlPendingAlbumPic";
            this.pnlPendingAlbumPic.Size = new System.Drawing.Size(372, 209);
            this.pnlPendingAlbumPic.TabIndex = 63;
            this.pnlPendingAlbumPic.SizeChanged += new System.EventHandler(this.pnlPendingAlbumPic_SizeChanged);
            this.pnlPendingAlbumPic.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPendingAlbumPic_Paint);
            // 
            // btnPendingAlbumPrevPic
            // 
            this.btnPendingAlbumPrevPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPendingAlbumPrevPic.Location = new System.Drawing.Point(6, 116);
            this.btnPendingAlbumPrevPic.Name = "btnPendingAlbumPrevPic";
            this.btnPendingAlbumPrevPic.Size = new System.Drawing.Size(22, 209);
            this.btnPendingAlbumPrevPic.TabIndex = 65;
            this.btnPendingAlbumPrevPic.Text = "<";
            this.btnPendingAlbumPrevPic.UseVisualStyleBackColor = true;
            this.btnPendingAlbumPrevPic.Click += new System.EventHandler(this.btnPendingAlbumPrevPic_Click);
            // 
            // headerControl1
            // 
            this.headerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("headerControl1.BackgroundImage")));
            this.headerControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headerControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.headerControl1.Label = "Synchronize pending camera folders";
            this.headerControl1.Location = new System.Drawing.Point(0, 0);
            this.headerControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.headerControl1.Name = "headerControl1";
            this.headerControl1.Size = new System.Drawing.Size(888, 44);
            this.headerControl1.TabIndex = 18;
            // 
            // UserControl3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.headerControl1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtIntroduction);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(888, 596);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtIntroduction;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblSyncAlbums;
        private System.Windows.Forms.ListBox lstSyncAlbums;
        private System.Windows.Forms.Label lblAbsCorrectionSyncAlbumValue;
        private System.Windows.Forms.Label lblAdjustedDateTimeSyncAlbum;
        private System.Windows.Forms.Label lblAbsCorrectionSyncAlbum;
        private System.Windows.Forms.Label lblAdjustedDateTimeSyncAlbumValue;
        private System.Windows.Forms.Label lblSyncAlbumPicName;
        private System.Windows.Forms.Button btnSyncAlbumNextPic;
        private System.Windows.Forms.Button btnSyncAlbumPrevPic;
        private System.Windows.Forms.Panel pnlSyncAlbumPic;
        private System.Windows.Forms.Label lblPendingAlbums;
        private System.Windows.Forms.Label lblPendingAlbumAbsCorrection;
        private System.Windows.Forms.Label lblPendingAlbumAbsCorrectionValue;
        private System.Windows.Forms.Label lblPendingAlbumOriginalDateTime;
        private System.Windows.Forms.Label lblPendingAlbumAdjustedDateTime;
        private MyNumericUpDown udPendingAlbumYear;
        private MyNumericUpDown udPendingAlbumMonth;
        private MyNumericUpDown udPendingAlbumDay;
        private MyNumericUpDown udPendingAlbumHour;
        private MyNumericUpDown udPendingAlbumMinute;
        private MyNumericUpDown udPendingAlbumSecond;
        private System.Windows.Forms.Label lblPendingAlbumOriginalDateTimeValue;
        private System.Windows.Forms.Button btnPendingAlbumIsSync;
        private System.Windows.Forms.ListBox lstPendingAlbums;
        private System.Windows.Forms.Label lblPendingAlbumPicName;
        private System.Windows.Forms.Button btnPendingAlbumNextPic;
        private System.Windows.Forms.Panel pnlPendingAlbumPic;
        private System.Windows.Forms.Button btnPendingAlbumPrevPic;
        private HeaderControl headerControl1;
    }
}
