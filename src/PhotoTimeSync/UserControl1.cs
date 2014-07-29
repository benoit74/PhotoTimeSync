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
            InitializeComponent();
            _sync = sync;
            BrowseFolderHint = "Please select a folder ...";
            txtFolder.Text = BrowseFolderHint;
            RefreshContent();
        }

        public string BrowseFolderHint { get; set; }

        private StringBuilder sbImportResult;

        public void RefreshContent()
        {
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
        }

        private void RefreshBtnImportAndCheck()
        {
            btnImportAndCheck.Enabled = System.IO.Directory.Exists(txtFolder.Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
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
            if (!System.IO.Directory.Exists(txtFolder.Text))
                MessageBox.Show("Directory does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ImportAndCheck();
            btnImportAndCheck.Enabled = false;
        }

        private void ImportAndCheck()
        {
            sbImportResult = new StringBuilder();
            _sync.CheckAndExploreFolder(sbImportResult);
            txtImportResult.Text = sbImportResult.ToString();
            RefreshContent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            UserControl2 page2 = new UserControl2(_sync);
            page2.Dock = DockStyle.Fill;
            Control parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(page2);
        }
            

        
    }
}
