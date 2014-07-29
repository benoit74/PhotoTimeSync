using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExifLibrary;
using System.IO;

namespace PhotoTimeSync
{
    public partial class UserControl2 : UserControl
    {

        private PhotoTimeSynchronizer _sync;
        private Image _currentImage = null;
        private Photo _currentPhoto = null;
        
        public UserControl2(PhotoTimeSynchronizer sync)
        {
            InitializeComponent();
            _sync = sync;
            lstFolders.Items.Clear();
            foreach (PhotoFolder fld in _sync.Folders)
            {
                lstFolders.Items.Add(fld.FolderName);
                fld.IsSynced = false;
            }
            btnNext.Enabled = false;
            pnlPictureDetail.Visible = false;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            CleanResources();
            UserControl1 page1 = new UserControl1(_sync);
            page1.Dock = DockStyle.Fill;
            Control parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(page1);
        }

        private void lstFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFolders.SelectedItem == null)
                return;

            lstPictures.Items.Clear();
            string fldName = (string)lstFolders.SelectedItem;
            PhotoFolder fld = _sync.Folders.Where(f => f.FolderName == fldName).FirstOrDefault();
            if (fld == null)
            {
                btnNext.Enabled = false;
                return;
            }
            _sync.CurrentPendingFolder = fld;
            btnNext.Enabled = true; 
            foreach (Photo ph in fld.Photos)
            {
                lstPictures.Items.Add(ph.fileName);
            }
        }

        private void lstPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fldName = (string)lstFolders.SelectedItem;
            PhotoFolder fld = _sync.Folders.Where(f => f.FolderName == fldName).FirstOrDefault();
            if (fld == null)
                return;
            string photoName = (string)lstPictures.SelectedItem;
            Photo photo = fld.Photos.Where(ph => ph.fileName == photoName).FirstOrDefault();
            if (photo == null)
                return;
            _currentPhoto = photo;
            if (_currentImage != null)
                _currentImage.Dispose();
            _currentImage = Image.FromFile(photo.FullPath);
            pnlPictureDetail.Visible = true;
            lblOriginalDateTimeValue.Text = photo.InitialDateTime.ToString("yyyy/MM/dd HH:mm:ss");
            DateTime correctedDateTime = photo.InitialDateTime + _sync.CurrentPendingFolder.Correction;
            yearUpDown.Value = correctedDateTime.Year;
            monthUpDown.Value = correctedDateTime.Month;
            dayUpDown.Value = correctedDateTime.Day;
            hourUpDown.Value = correctedDateTime.Hour;
            minuteUpDown.Value = correctedDateTime.Minute;
            secondUpDown.Value = correctedDateTime.Second;
            this.Refresh();
        }

        private void pnlPicturePreview_Paint(object sender, PaintEventArgs e)
        {
            if (_currentImage != null)
            {
                Image imgThumb = null;
                ThumbnailGenerator gen = new ThumbnailGenerator(_currentImage.Width, _currentImage.Height, pnlPicturePreview.Width, pnlPicturePreview.Height);
                imgThumb = _currentImage.GetThumbnailImage(gen.ThumbnailWidth, gen.ThumbnailHeight, null, new IntPtr());
                if (imgThumb != null)
                    e.Graphics.DrawImage(imgThumb, gen.ThumbnailHorizontalOffset, gen.ThumbnailVerticalOffset, gen.ThumbnailWidth, gen.ThumbnailHeight);
            }
         }

        private void anUpDown_ValueChanged(MyNumericUpDown sender)
        {
            DateTime correctedDateTime = new DateTime(yearUpDown.Value, monthUpDown.Value, dayUpDown.Value,
                                                      hourUpDown.Value, minuteUpDown.Value, secondUpDown.Value);
            _sync.CurrentPendingFolder.Correction = correctedDateTime - _currentPhoto.InitialDateTime;
            lblCorrectionValue.Text = _sync.CurrentPendingFolder.CorrectionToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CleanResources();
            _sync.CurrentPendingFolder.IsSynced = true;
            UserControl3 page3 = new UserControl3(_sync);
            page3.Dock = DockStyle.Fill;
            Control parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(page3);
        }

        private void CleanResources()
        {
            if (_currentImage != null)
                _currentImage.Dispose();
        }



    }
}
