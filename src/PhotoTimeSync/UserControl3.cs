using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoTimeSync
{
    public partial class UserControl3 : UserControl
    {

        private PhotoTimeSynchronizer _sync;
        private Image _currentSyncImage = null;
        private Photo _currentSyncPhoto = null;
        private Image _currentPendingImage = null;
        private Photo _currentPendingPhoto = null;
        private int _currentSyncPhotoSkip;
        private int _currentPendingPhotoSkip;


        public UserControl3(PhotoTimeSynchronizer sync)
        {
            InitializeComponent();
            _sync = sync;
            _sync.CurrentSyncFolder = null;
            _sync.CurrentPendingFolder = null;
            btnSyncAlbumNextPic.Enabled = false;
            btnSyncAlbumPrevPic.Enabled = false;
            RefreshAlbumsLists();
            _currentSyncPhotoSkip = 0;
            SyncPhotoIndexHasChanged();
            _currentPendingPhotoSkip = 0;
            PendingPhotoIndexHasChanged();
            lblAbsCorrectionSyncAlbumValue.Text = "---";
            //pnlPictureDetail.Visible = false;
        }

        private void RefreshAlbumsLists()
        {
            lstSyncAlbums.Items.Clear();
            foreach (PhotoFolder fld in _sync.Folders.Where(f => f.IsSynced == true))
                lstSyncAlbums.Items.Add(fld.FolderName);
            lstPendingAlbums.Items.Clear();
            foreach (PhotoFolder fld in _sync.Folders.Where(f => f.IsSynced == false))
                lstPendingAlbums.Items.Add(fld.FolderName);
            btnNext.Enabled = (lstPendingAlbums.Items.Count == 0);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            CleanResources();
            UserControl2 page2 = new UserControl2(_sync);
            page2.Dock = DockStyle.Fill;
            Control parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(page2);
        }

        private void lstSyncAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSyncAlbums.SelectedItem == null)
                return;
            string fldName = (string)lstSyncAlbums.SelectedItem;
            PhotoFolder fld = _sync.Folders.Where(f => f.FolderName == fldName).FirstOrDefault();
            if (fld == null)
                return;
            _sync.CurrentSyncFolder = fld;
            _currentSyncPhotoSkip = 0;
            SyncPhotoIndexHasChanged();
            lblAbsCorrectionSyncAlbumValue.Text = _sync.CurrentSyncFolder.CorrectionToString();
        }

        private void lstPendingAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPendingAlbums.SelectedItem == null)
                return;
            string fldName = (string)lstPendingAlbums.SelectedItem;
            PhotoFolder fld = _sync.Folders.Where(f => f.FolderName == fldName).FirstOrDefault();
            if (fld == null)
                return;
            _sync.CurrentPendingFolder = fld;
            _currentPendingPhotoSkip = 0;
            PendingPhotoIndexHasChanged();
        }

        private void SyncPhotoIndexHasChanged()
        {
            if (_sync.CurrentSyncFolder == null)
            {
                _currentSyncPhoto = null;
            }
            else
            {
                _currentSyncPhoto = _sync.CurrentSyncFolder.Photos.Skip(_currentSyncPhotoSkip).Take(1).FirstOrDefault();
            }
            if (_currentSyncImage != null)
                _currentSyncImage.Dispose();
            if (_currentSyncPhoto == null)
            {
                _currentSyncImage = null;
                lblSyncAlbumPicName.Text = "---";
                lblAdjustedDateTimeSyncAlbumValue.Text = "---";
            }
            else
            {
                _currentSyncImage = Image.FromFile(_currentSyncPhoto.FullPath);
                lblSyncAlbumPicName.Text = _currentSyncPhoto.fileName;
                DateTime correctedDateTime = _currentSyncPhoto.InitialDateTime + _sync.CurrentSyncFolder.Correction;
                lblAdjustedDateTimeSyncAlbumValue.Text = correctedDateTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
            RefreshPendingCorrectionBasedOnCurrentPhotos();
            btnSyncAlbumPrevPic.Enabled = (_currentSyncPhoto != null) && (_currentSyncPhotoSkip > 0);
            btnSyncAlbumNextPic.Enabled = (_currentSyncPhoto != null) && (_currentSyncPhotoSkip < _sync.CurrentSyncFolder.Photos.Count - 1);
            this.Refresh();
        }

        private void PendingPhotoIndexHasChanged()
        {
            if (_sync.CurrentPendingFolder == null)
            {
                _currentPendingPhoto = null;
            }
            else
            {
                _currentPendingPhoto = _sync.CurrentPendingFolder.Photos.Skip(_currentPendingPhotoSkip).Take(1).FirstOrDefault();
            }
            if (_currentPendingImage != null)
                _currentPendingImage.Dispose();
            if (_currentPendingPhoto == null)
            {
                _currentPendingImage = null;
                lblPendingAlbumOriginalDateTimeValue.Text = "---";
                lblPendingAlbumPicName.Text ="---";
                btnPendingAlbumIsSync.Enabled = false;
            }
            else
            {
                _currentPendingImage = Image.FromFile(_currentPendingPhoto.FullPath);
                lblPendingAlbumOriginalDateTimeValue.Text = _currentPendingPhoto.InitialDateTime.ToString("yyyy/MM/dd HH:mm:ss");
                lblPendingAlbumPicName.Text = _currentPendingPhoto.fileName;
                btnPendingAlbumIsSync.Enabled = true;
            }
            RefreshPendingCorrectionBasedOnCurrentPhotos();
            btnPendingAlbumPrevPic.Enabled = (_currentPendingPhoto != null) && (_currentPendingPhotoSkip > 0);
            btnPendingAlbumNextPic.Enabled = (_currentPendingPhoto != null) && (_currentPendingPhotoSkip < _sync.CurrentPendingFolder.Photos.Count - 1);
            this.Refresh();
        }

        private void PendingCorrectionHasChanged()
        {
            if (_currentPendingPhoto == null || _sync.CurrentPendingFolder == null)
            {
                udPendingAlbumYear.Visible = false;
                udPendingAlbumMonth.Visible = false;
                udPendingAlbumDay.Visible = false;
                udPendingAlbumHour.Visible = false;
                udPendingAlbumMinute.Visible = false;
                udPendingAlbumSecond.Visible = false;
                lblPendingAlbumAbsCorrectionValue.Text = "---";
            }
            else
            {
                udPendingAlbumYear.Visible = true;
                udPendingAlbumMonth.Visible = true;
                udPendingAlbumDay.Visible = true;
                udPendingAlbumHour.Visible = true;
                udPendingAlbumMinute.Visible = true;
                udPendingAlbumSecond.Visible = true;
                DateTime correctedDateTime = _currentPendingPhoto.InitialDateTime + _sync.CurrentPendingFolder.Correction;
                udPendingAlbumYear.Value = correctedDateTime.Year;
                udPendingAlbumMonth.Value = correctedDateTime.Month;
                udPendingAlbumDay.Value = correctedDateTime.Day;
                udPendingAlbumHour.Value = correctedDateTime.Hour;
                udPendingAlbumMinute.Value = correctedDateTime.Minute;
                udPendingAlbumSecond.Value = correctedDateTime.Second;
            }

        }

        private void RefreshPendingCorrectionBasedOnCurrentPhotos()
        {
            if (_sync.CurrentSyncFolder != null && _currentSyncPhoto != null
                && _sync.CurrentPendingFolder != null && _currentPendingPhoto != null)
                _sync.CurrentPendingFolder.Correction = _currentSyncPhoto.InitialDateTime + _sync.CurrentSyncFolder.Correction - _currentPendingPhoto.InitialDateTime;

            PendingCorrectionHasChanged();
            
        }

        private void pnlSyncAlbumPic_Paint(object sender, PaintEventArgs e)
        {
            if (_currentSyncImage != null)
            {
                Image imgThumb = null;
                ThumbnailGenerator gen = new ThumbnailGenerator(_currentSyncImage.Width, _currentSyncImage.Height, pnlSyncAlbumPic.Width, pnlSyncAlbumPic.Height);
                imgThumb = _currentSyncImage.GetThumbnailImage(gen.ThumbnailWidth, gen.ThumbnailHeight, null, new IntPtr());
                if (imgThumb != null)
                    e.Graphics.DrawImage(imgThumb, gen.ThumbnailHorizontalOffset, gen.ThumbnailVerticalOffset, gen.ThumbnailWidth, gen.ThumbnailHeight);
            }
        }

        private void pnlPendingAlbumPic_Paint(object sender, PaintEventArgs e)
        {
            if (_currentPendingImage != null)
            {
                Image imgThumb = null;
                ThumbnailGenerator gen = new ThumbnailGenerator(_currentPendingImage.Width, _currentPendingImage.Height, pnlPendingAlbumPic.Width, pnlPendingAlbumPic.Height);
                imgThumb = _currentPendingImage.GetThumbnailImage(gen.ThumbnailWidth, gen.ThumbnailHeight, null, new IntPtr());
                if (imgThumb != null)
                    e.Graphics.DrawImage(imgThumb, gen.ThumbnailHorizontalOffset, gen.ThumbnailVerticalOffset, gen.ThumbnailWidth, gen.ThumbnailHeight);
            }
        }

        private void anUpDown_ValueChanged(MyNumericUpDown sender)
        {
            DateTime correctedDateTime = new DateTime(udPendingAlbumYear.Value, udPendingAlbumMonth.Value, udPendingAlbumDay.Value,
                                          udPendingAlbumHour.Value, udPendingAlbumMinute.Value, udPendingAlbumSecond.Value);
            _sync.CurrentPendingFolder.Correction = correctedDateTime - _currentPendingPhoto.InitialDateTime;
            lblPendingAlbumAbsCorrectionValue.Text = _sync.CurrentPendingFolder.CorrectionToString();
        }

        private void btnPendingAlbumIsSync_Click(object sender, EventArgs e)
        {
            _sync.CurrentPendingFolder.IsSynced = true;
            _sync.CurrentPendingFolder = null;
            _currentPendingPhotoSkip = 0;
            PendingPhotoIndexHasChanged();
            RefreshAlbumsLists();
            this.Refresh();
        }

        private void btnSyncAlbumPrevPic_Click(object sender, EventArgs e)
        {
            MovePrevSyncPic();
        }

        private void MovePrevSyncPic()
        {
            _currentSyncPhotoSkip--;
            SyncPhotoIndexHasChanged();
        }

        private void btnSyncAlbumNextPic_Click(object sender, EventArgs e)
        {
            MoveNextSyncPic();
        }

        private void MoveNextSyncPic()
        {
            _currentSyncPhotoSkip++;
            SyncPhotoIndexHasChanged();
        }

        private void btnPendingAlbumPrevPic_Click(object sender, EventArgs e)
        {
            MovePrevPendingPic();
        }

        private void MovePrevPendingPic()
        {
            _currentPendingPhotoSkip--;
            PendingPhotoIndexHasChanged();
        }

        private void btnPendingAlbumNextPic_Click(object sender, EventArgs e)
        {
            MoveNextPendingPic();
        }

        private void MoveNextPendingPic()
        {
            _currentPendingPhotoSkip++;
            PendingPhotoIndexHasChanged();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CleanResources();
            UserControl4 page4 = new UserControl4(_sync);
            page4.Dock = DockStyle.Fill;
            Control parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(page4);
        }

        private void CleanResources()
        {
            if (_currentSyncImage != null)
                _currentSyncImage.Dispose();
            if (_currentPendingImage != null)
                _currentPendingImage.Dispose();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left && btnSyncAlbumPrevPic.Enabled)
            {
                MovePrevSyncPic();
            }
            else if (keyData == Keys.Right && btnSyncAlbumNextPic.Enabled)
            {
                MoveNextSyncPic();
            }
            else if (keyData == Keys.Up && btnPendingAlbumPrevPic.Enabled)
            {
                MovePrevPendingPic();
            }
            else if (keyData == Keys.Down && btnPendingAlbumNextPic.Enabled)
            {
                MoveNextPendingPic();
            }
            // Those keys have been processed and cannot be used for anything else
            return (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down);
            //return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
