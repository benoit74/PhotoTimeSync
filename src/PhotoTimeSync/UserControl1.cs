using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PhotoTimeSync
{
    public partial class UserControl1 : UserControl
    {

        private PhotoTimeSynchronizer _sync;

        public UserControl1(PhotoTimeSynchronizer sync)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl1", "Init", "", "");
            InitializeComponent();
            _sync = sync;
            BrowseFolderHint = "Please select a folder ...";
            txtFolder.Text = BrowseFolderHint;
            RefreshContent();
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl1", "Init", "OK", "");
        }

        public string BrowseFolderHint { get; set; }

        private StringBuilder sbImportResult;

        public void RefreshContent()
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl1", "RefreshContent", "Start", "");
            if (txtFolder.Text == BrowseFolderHint)
            {
                txtFolder.Font = new Font(txtFolder.Font, FontStyle.Italic);
                txtFolder.ForeColor = Color.LightGray;
            }
            else
            {
                txtFolder.Font = new Font(txtFolder.Font, FontStyle.Regular);
                txtFolder.ForeColor = Color.Black;
            }
            btnNext.Enabled = _sync.FolderHasBeenChecked && _sync.FolderIsOK;
            lblError.Visible = _sync.FolderHasBeenChecked && !_sync.FolderIsOK;
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl1", "RefreshContent", "", "lblError.Visible={0}, btnNext.Enabled={0}, ", lblError.Visible, btnNext.Enabled);
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl1", "RefreshContent", "Done", "");
        }

        private void RefreshBtnImportAndCheck()
        {
            btnImportAndCheck.Enabled = System.IO.Directory.Exists(txtFolder.Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl1", "btnBrowse", "Click", "");
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (!string.IsNullOrWhiteSpace(_sync.ParentFolder))
                dlg.SelectedPath = _sync.ParentFolder;
            DialogResult res = dlg.ShowDialog();
            if (res != DialogResult.OK)
                return;

            _sync.ParentFolder = dlg.SelectedPath;
            txtFolder.Text = _sync.ParentFolder;
            ImportAndCheck();
            btnImportAndCheck.Enabled = false;
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl1", "btnBrowse", "Folder selected", "{0}", dlg.SelectedPath);
        }

        void txtFolder_TextChanged(object sender, System.EventArgs e)
        {
            if (txtFolder.Text != BrowseFolderHint && System.IO.Directory.Exists(txtFolder.Text))
                _sync.ParentFolder = txtFolder.Text;
            RefreshContent();
            RefreshBtnImportAndCheck();
        }

        private void btnImportAndCheck_Click(object sender, EventArgs e)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl1", "btnImportAndCheck", "Click", "");
            if (!System.IO.Directory.Exists(txtFolder.Text))
                MessageBox.Show("Directory does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ImportAndCheck();
            btnImportAndCheck.Enabled = false;
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl1", "btnImportAndCheck", "Done", "");
        }

        private void ImportAndCheck()
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl1", "ImportAndCheck", "Start", "");
            sbImportResult = new StringBuilder();
            _sync.CheckAndExploreFolder(sbImportResult);
            txtImportResult.Text = sbImportResult.ToString();
            RefreshContent();
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl1", "ImportAndCheck", "Done", "FolderIsOK: {0}", _sync.FolderIsOK);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "UserControl1", "Next", "Start", "");
            UserControl2 page2 = new UserControl2(_sync);
            page2.Dock = DockStyle.Fill;
            Control parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(page2);
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "UserControl1", "Next", "Done", "");
        }
            

        
    }
}
