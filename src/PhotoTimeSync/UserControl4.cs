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
    public partial class UserControl4 : RefreshableLabelsUC
    {

        private PhotoTimeSynchronizer _sync;

        public UserControl4(PhotoTimeSynchronizer sync)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "Init", "", "");
            InitializeComponent();
            _sync = sync;
            lblProgress.Visible = false;
            btnQuit.Visible = false;
            lstCorrections.Items.Clear();
            foreach (PhotoFolder fld in _sync.Folders)
            {
                lstCorrections.Items.Add(new ListViewItem(new string[] {fld.FolderName, fld.CorrectionToString()}));
            }
            RefreshLabels();
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "Init", "OK", "");
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            lstCorrections.Columns[0].Width = (lstCorrections.Width) / 2;
            lstCorrections.Columns[1].Width = (lstCorrections.Width) / 2;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "btnPrev", "Click", "");
            UserControl3 page3 = new UserControl3(_sync);
            page3.Dock = DockStyle.Fill;
            Control parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(page3);
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "btnPrev", "Done", "");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "btnNext", "Click", "");
            btnNext.Visible = false;
            btnPrev.Visible = false;
            lblProgress.Visible = true;
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += bg_DoWork;
            bg.ProgressChanged += bg_ProgressChanged;
            bg.RunWorkerCompleted += bg_RunWorkerCompleted;
            bg.WorkerReportsProgress = true;
            bg.RunWorkerAsync();
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "btnNext", "Done", "");
        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblProgress.Text = string.Format(Labels.Labels.Screen4_ConversionFailed, e.Error.Message);
                LogManager.Log(System.Diagnostics.TraceLevel.Error, "UserControl4", "RunWorkerCompleted", "Error", "Content:\r\n{0}", ExceptionDisplayer.GetString(e.Error));
                lblProgress.ForeColor = Color.DarkRed;
            }
            else
            {
                int nbPhotosTreated = (int)e.Result;
                LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "RunWorkerCompleted", "Success", "{0} photos date/time corrected", nbPhotosTreated);
                lblProgress.Text = string.Format(Labels.Labels.Screen4_CompletedText, nbPhotosTreated);
                lblProgress.ForeColor = Color.DarkGreen;
                lblStatistics.Visible = true;
                LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "RunWorkerCompleted", "Stats", "You have corrected a total of {0} photos from {1} cameras.", nbPhotosTreated, 0);
                lblStatistics.Text = string.Format(Labels.Labels.Screen4_FinalWords, nbPhotosTreated, 0);
            }
            lblProgress.Font = new Font(lblProgress.Font, FontStyle.Bold);
            btnQuit.Visible = true;
        }

        void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = string.Format(Labels.Labels.Screen4_ProgressText, e.ProgressPercentage);
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "RunWorkerCompleted", "Progress", "{0}%", e.ProgressPercentage);
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
            foreach (PhotoFolder fld in _sync.Folders)
            {
                LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "DoWork", "Processing", "Folder {0}", fld.FolderName);
                foreach (Photo photo in fld.Photos)
                {
                    if (worker.WorkerReportsProgress && (nextReportProgress == null || DateTime.Now > nextReportProgress))
                    {
                        if (totalNbPhotos > 0)
                            worker.ReportProgress(treatedNbPhotos * 100 / totalNbPhotos);
                        nextReportProgress = DateTime.Now + new TimeSpan(0, 0, 1);
                    }
                    // Do this check for each photos to update correctly progress percentage ...
                    if (fld.Correction.TotalSeconds != 0)
                    {
                        LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "DoWork", "Processing", "Photo {0}", photo.fileName);
                        photo.ExifImage.Properties.Set(ExifTag.DateTime, photo.InitialDateTime + fld.Correction);
                        photo.ExifImage.Save(photo.FullPath);
                        treatedNbPhotos++;
                    }
                    else
                    {
                        LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "DoWork", "Correction is 0", "Photo {0}", photo.fileName);
                    }
                }
            }
            e.Result = treatedNbPhotos;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "Exit", "", "");
            Application.Exit();
        }

        public override void RefreshLabels()
        {
            headerControl1.Label = Labels.Labels.Screen4_Header;
            btnNext.Text = Labels.Labels.Screen4_ButtonGo;
            btnPrev.Text = Labels.Labels.Generic_ButtonPrev;
            btnQuit.Text = Labels.Labels.Screen4_ButtonQuit;
            lblIntroduction.Text = Labels.Labels.Screen4_Introduction;
            columnHeader1.Text = Labels.Labels.Screen4_ColFolderName;
            columnHeader2.Text = Labels.Labels.Screen4_ColCorrection;

        }

    }
}
