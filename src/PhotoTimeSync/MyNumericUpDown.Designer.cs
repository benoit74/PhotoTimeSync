using System.ComponentModel;
namespace PhotoTimeSync
{
    partial class MyNumericUpDown
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
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDown.BackgroundImage = global::PhotoTimeSync.Pics.arrow_down;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(80, 23);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(12, 12);
            this.btnDown.TabIndex = 18;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUp.BackgroundImage = global::PhotoTimeSync.Pics.arrow_up;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(80, 13);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(12, 12);
            this.btnUp.TabIndex = 17;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // txtBox
            // 
            this.txtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox.BackColor = System.Drawing.SystemColors.Control;
            this.txtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox.Location = new System.Drawing.Point(8, 17);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(71, 13);
            this.txtBox.TabIndex = 19;
            this.txtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MyNumericUpDown
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Name = "MyNumericUpDown";
            this.Size = new System.Drawing.Size(92, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.TextBox txtBox;

    }
}
