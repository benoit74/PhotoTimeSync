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
using System.Diagnostics;

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
            btnShowLogs.Visible = false;
            btnDonatePaypalFreeAmount.Visible = false;
            btnDonatePaypal5Euros.Visible = false;
            btnFacebook.Visible = false;
            btnTwitter.Visible = false;
            btnFlattr.Visible = false;
            lstCorrections.Items.Clear();
            foreach (PhotoFolder fld in _sync.Folders)
            {
                ListViewItem item = new ListViewItem(new string[] { fld.FolderName, fld.CorrectionToString(), fld.PicsPrefix });
                item.Tag = fld;
                lstCorrections.Items.Add(item);
            }
            lstCorrections.Columns[2].Width = 0;
            RefreshLabels();
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "Init", "OK", "");
        }

        private void lstCorrections_Resize(object sender, EventArgs e)
        {
            if (chkRenamePhotos.Checked)
            {
                lstCorrections.Columns[0].Width = (lstCorrections.Width) / 3;
                lstCorrections.Columns[1].Width = (lstCorrections.Width) / 3;
                lstCorrections.Columns[2].Width = (lstCorrections.Width) / 3;
            }
            else
            {
                lstCorrections.Columns[0].Width = (lstCorrections.Width) / 2;
                lstCorrections.Columns[1].Width = (lstCorrections.Width) / 2;
                lstCorrections.Columns[2].Width = 0;
            }
        }

        private void chkRenamePhotos_CheckedChanged(object sender, EventArgs e)
        {
            lstCorrections_Resize(sender, e);
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
                BackgroundWorkerResult res = (BackgroundWorkerResult)e.Result;
                LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "RunWorkerCompleted", "Finished", "{0} photos date/time corrected", res.nbTreatedPhotos);
                LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "RunWorkerCompleted", "Finished", "{0} photos in error", res.nbPhotosInError);
                LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "RunWorkerCompleted", "Finished", "{0} photos ignored (nothing to do)", res.nbPhotosIgnored);
                string completedText = Labels.Labels.Screen4_CompletedText;
                if (res.nbPhotosInError > 0)
                {
                    completedText += " " + Labels.Labels.Screen4_CompletedTextForErrors;
                }
                lblProgress.Text = string.Format(completedText, res.nbTreatedPhotos, res.nbPhotosInError);
                lblProgress.ForeColor = Color.DarkGreen;
                Properties.Settings.Default.TotalPhotosCorrected += res.nbTreatedPhotos;
                Properties.Settings.Default.TotalAlbumsCorrected += res.nbAlbumsTreated;
                Properties.Settings.Default.TotalPhotosInError += res.nbPhotosInError;
                lblStatistics.Text = string.Format(
                    Labels.Labels.Screen4_FinalWords_Part1 + Environment.NewLine + Labels.Labels.Screen4_FinalWords_Part2,
                    Properties.Settings.Default.TotalPhotosCorrected,
                    Properties.Settings.Default.TotalAlbumsCorrected);
                lblStatistics.Visible = true;
                LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "RunWorkerCompleted", "Stats", "You have corrected a total of {0} photos from {1} cameras.",
                    Properties.Settings.Default.TotalPhotosCorrected,
                    Properties.Settings.Default.TotalAlbumsCorrected);
                LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "RunWorkerCompleted", "Stats", "You have encountered a total of {0} photos in error.",
                                    Properties.Settings.Default.TotalPhotosInError);
                Properties.Settings.Default.Save();
            }
            lblProgress.Font = new Font(lblProgress.Font, FontStyle.Bold);
            btnQuit.Visible = true;
            btnShowLogs.Visible = true; 
            btnDonatePaypalFreeAmount.Visible = true;
            btnDonatePaypal5Euros.Visible = true;
            btnFacebook.Visible = true;
            btnTwitter.Visible = true;
            //btnFlattr.Visible = true;
        }

        void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = string.Format(Labels.Labels.Screen4_ProgressText, e.ProgressPercentage);
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "RunWorkerCompleted", "Progress", "{0}%", e.ProgressPercentage);
        }

        void CountPhotosIfCorrectionNeeded(PhotoFolder fld, ref int currentCount)
        {
            if (fld.Correction.TotalSeconds != 0 || chkRenamePhotos.Checked)
            {
                currentCount += fld.Photos.Count();
            }
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            BackgroundWorkerResult res = new BackgroundWorkerResult();
            _sync.Folders.ForEach(f => CountPhotosIfCorrectionNeeded(f, ref res.expectedNbPhotosToTreat));
            DateTime? nextReportProgress = null;

            PhotoFolder prevTreatedFld = null;

            foreach (PhotoFolder fld in _sync.Folders)
            {
                LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "DoWork", "Processing", "Folder {0}", fld.FolderName);
                foreach (Photo photo in fld.Photos)
                {
                    try
                    {
                        if (worker.WorkerReportsProgress && (nextReportProgress == null || DateTime.Now > nextReportProgress))
                        {
                            if (res.expectedNbPhotosToTreat > 0)
                                worker.ReportProgress(res.nbTreatedPhotos * 100 / res.expectedNbPhotosToTreat);
                            nextReportProgress = DateTime.Now + new TimeSpan(0, 0, 1);
                        }
                        // Do this check for each photos to update correctly progress percentage ...
                        if (fld.Correction.TotalSeconds != 0 || chkRenamePhotos.Checked)
                        {
                            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "DoWork", "Processing", "Photo {0}", photo.fileName);
                            if (prevTreatedFld == null || prevTreatedFld != fld)
                            {
                                res.nbAlbumsTreated++;
                                prevTreatedFld = fld;
                            }
                            ImageFile image = photo.ExifImage;
                            DateTime correctedDateTime = photo.InitialDateTime + fld.Correction;
                            image.Properties.Set(ExifTag.DateTimeOriginal, correctedDateTime);

                            /*
                            if (!photo.AlreadyProcessedPreviously)
                            {
                                string newUsrComment = string.Empty;
                                if (!string.IsNullOrEmpty(photo.InitialUserComment))
                                {
                                    newUsrComment += photo.InitialUserComment + "\r\n";
                                }
                                newUsrComment += Photo.CustomUserComment;
                                image.Properties.Set(ExifTag.UserComment, newUsrComment);
                            }
                             * */

                            if (chkRenamePhotos.Checked)
                            {
                                System.IO.FileInfo file = new System.IO.FileInfo(photo.FullPath);
                                string originalFileName;
                                if  (photo.AlreadyProcessedPreviously)
                                {
                                    int thirdUnderScorePos = file.Name.IndexOf('_', 16);
                                    if (thirdUnderScorePos > 0)
                                    {
                                        originalFileName = file.Name.Substring(thirdUnderScorePos + 1);
                                    }
                                    else
                                    {
                                        originalFileName = file.Name.Substring(16);
                                    } 
                                }
                                else
                                {
                                    originalFileName = file.Name;
                                }
                                string newFileName = correctedDateTime.ToString("yyyyMMdd_HHmmss") + "_" + fld.PicsPrefix + "_" + originalFileName; 
                                string folder = System.IO.Path.GetDirectoryName(file.FullName);
                                LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "DoWork", "", "Photo {0} will be renamed to {1}", photo.fileName, newFileName);
                                image.Save(System.IO.Path.Combine(folder, newFileName));
                                System.IO.File.Delete(file.FullName);
                            }
                            else
                            {
                                image.Save(photo.FullPath);
                            }
                            res.nbTreatedPhotos++;
                        }
                        else
                        {
                            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl4", "DoWork", "Nothing to do on", "photo {0}", photo.fileName);
                            res.nbPhotosIgnored++;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogManager.Log(System.Diagnostics.TraceLevel.Error, "UserControl4", "DoWork", "Error while processing photo", "Photo {0}\r\n{1}", photo.fileName, ExceptionDisplayer.GetString(ex));
                        res.nbPhotosInError++;
                    }
                }
            }
            e.Result = res;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl4", "Exit", "", "");
            Application.Exit();
        }

        private void btnShowLogs_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (ILogger logger in LogManager.Loggers)
            {
                RotatingFileLogger rotLog = logger as RotatingFileLogger;
                if (rotLog != null)
                {
                    string logFile = rotLog.BaseFilePath;
                    Process.Start(System.IO.Directory.GetParent(logFile).FullName);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                MessageBox.Show(Labels.Labels.Screen4_LogsAreNotActivated, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDonatePaypal5Euros_Click(object sender, System.EventArgs e)
        {
            Process.Start(DonateURLs.Paypal5Euros);
        }
        private void btnFlattr_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btnDonatePaypalFreeAmount_Click(object sender, EventArgs e)
        {
            Process.Start(DonateURLs.PaypalFreeAmount);
        }

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            Process.Start(DonateURLs.TwitterUrl);
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            Process.Start(DonateURLs.FacebookUrl);
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
            columnHeader3.Text = Labels.Labels.Screen4_ColFilenamePrefix;
            btnDonatePaypal5Euros.Text = Labels.Labels.Screen4_ButtonDonate5Euros;
            btnDonatePaypalFreeAmount.Text = Labels.Labels.Screen4_ButtonDonateFreeAmount;
            chkRenamePhotos.Text = Labels.Labels.Screen4_RenamePhotosCheckbox;
            btnShowLogs.Text = Labels.Labels.Screen4_ButtonShowLogs;
        }

        private void lstCorrections_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selIdx = -1;
            PhotoFolder fld = null;

            if (lstCorrections.SelectedIndices.Count > 0)
            {
                selIdx = lstCorrections.SelectedIndices[0];
                fld = (PhotoFolder)lstCorrections.Items[selIdx].Tag;
            }

            if (selIdx >= 0 && fld != null)
            {
                if (lstCorrections.Items[selIdx].SubItems.Count >= 2)
                {
                    Rectangle itemRect = lstCorrections.Items[selIdx].SubItems[2].Bounds;

                    itemRect.Offset(lstCorrections.Left, lstCorrections.Top);

                    txtFilenamePrefixRename.SetBounds(itemRect.X, itemRect.Y, itemRect.Width, itemRect.Height);
                    txtFilenamePrefixRename.Text = lstCorrections.Items[selIdx].SubItems[2].Text;
                    txtFilenamePrefixRename.Visible = true;
                    txtFilenamePrefixRename.Focus();
                }
            }
        
        }

        private void txtFilenamePrefixRename_Leave(object sender, EventArgs e)
        {
            int selIdx = -1;
            PhotoFolder fld = null;

            if (lstCorrections.SelectedIndices.Count > 0)
            {
                selIdx = lstCorrections.SelectedIndices[0];
                fld = (PhotoFolder)lstCorrections.Items[selIdx].Tag;
            }

            if (selIdx >= 0 && fld != null)
            {
                if (txtFilenamePrefixRename.Text.Contains('_'))
                {
                    MessageBox.Show(Labels.Labels.Screen4_UnderscoreNotAllowed);
                }
                else
                {
                    fld.PicsPrefix = txtFilenamePrefixRename.Text;
                    lstCorrections.Items[selIdx].SubItems[2].Text = fld.PicsPrefix;
                }
            }

            txtFilenamePrefixRename.Text = "";
            txtFilenamePrefixRename.Visible = false;
        }




        private class BackgroundWorkerResult
        {
            public int nbTreatedPhotos;
            public int nbPhotosInError;
            public int nbPhotosIgnored;
            public int expectedNbPhotosToTreat;
            public int nbAlbumsTreated;

            public BackgroundWorkerResult()
            {
                nbPhotosInError = 0;
                nbTreatedPhotos = 0;
                expectedNbPhotosToTreat = 0;
                nbPhotosIgnored = 0;
                nbAlbumsTreated = 0;
            }
        }


    }
}
