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

namespace PhotoTimeSync
{
    public partial class UserControl4 : UserControl
    {

        private PhotoTimeSynchronizer _sync;

        public UserControl4(PhotoTimeSynchronizer sync)
        {
            InitializeComponent();
            _sync = sync;
            lblProgress.Visible = false;
            btnQuit.Visible = false;
            lstCorrections.Items.Clear();
            foreach (PhotoFolder fld in _sync.Folders)
            {
                lstCorrections.Items.Add(new ListViewItem(new string[] {fld.FolderName, fld.CorrectionToString()}));
            }
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            lstCorrections.Columns[0].Width = (lstCorrections.Width) / 2;
            lstCorrections.Columns[1].Width = (lstCorrections.Width) / 2;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            UserControl3 page3 = new UserControl3(_sync);
            page3.Dock = DockStyle.Fill;
            Control parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(page3);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Visible = false;
            btnPrev.Visible = false;
            lblProgress.Visible = true;
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += bg_DoWork;
            bg.ProgressChanged += bg_ProgressChanged;
            bg.RunWorkerCompleted += bg_RunWorkerCompleted;
            bg.WorkerReportsProgress = true;
            bg.RunWorkerAsync();
        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblProgress.Text = string.Format("Conversion failed ! {0}.", e.Error.Message);
                lblProgress.ForeColor = Color.DarkRed;
            }
            else
            {
                int nbPhotosTreated = (int)e.Result;
                lblProgress.Text = string.Format("Conversion completed - {0} photos date/time corrected.", nbPhotosTreated);
                lblProgress.ForeColor = Color.DarkGreen;
                lblStatistics.Visible = true;
                lblStatistics.Text = string.Format("You have corrected a total of {0} photos from {1} cameras. If you enjoy the software, please mind donating few euros to reward the work done and ongoing.", nbPhotosTreated, 0);
            }
            lblProgress.Font = new Font(lblProgress.Font, FontStyle.Bold);
            btnQuit.Visible = true;
        }

        void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = string.Format("Correcting photos date/time - {0}%", e.ProgressPercentage);
        }

        void CountPhotosIfCorrectionNeeded(PhotoFolder fld, ref int currentCount)
        {
            if (fld.Correction.TotalSeconds != 0)
            {
                currentCount += fld.Photos.Count();
            }
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int totalNbPhotos = 0;
            _sync.Folders.ForEach(f => CountPhotosIfCorrectionNeeded(f, ref totalNbPhotos));
            DateTime? nextReportProgress = null;

            int treatedNbPhotos = 0;
            foreach(PhotoFolder fld in _sync.Folders)
            {
                foreach(Photo photo in fld.Photos)
                {
                    if(worker.WorkerReportsProgress && ( nextReportProgress == null || DateTime.Now > nextReportProgress))
                    {
                        if (totalNbPhotos > 0)
                            worker.ReportProgress(treatedNbPhotos * 100 / totalNbPhotos);
                        nextReportProgress = DateTime.Now + new TimeSpan(0, 0, 1);
                    }
                    if (fld.Correction.TotalSeconds != 0)
                    {
                        photo.ExifImage.Properties.Set(ExifTag.DateTime, photo.InitialDateTime + fld.Correction);
                        photo.ExifImage.Save(photo.FullPath);
                        treatedNbPhotos++;
                    }
                }
            }
            e.Result = treatedNbPhotos;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



    }
}
