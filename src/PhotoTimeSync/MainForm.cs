using ExifLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoTimeSync
{
    public partial class MainForm : Form
    {

        private PhotoTimeSynchronizer _sync;
            
        public MainForm()
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "MainForm", "Init", "Creating MainForm", "");
            InitializeComponent();
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "MainForm", "Init", "Main GUI Init Done", "");
            _sync = new PhotoTimeSynchronizer();
            UserControl1 page1 = new UserControl1(_sync);
            page1.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(page1);

            //french disabled since translation is not available so far
            //comboBoxWithImage1.Items.Add(new ComboBoxWithImage.DropDownItem() { Value = "Français (France)", Image = PhotoTimeSync.Pics.flag_france, Tag = "fr-FR" });
            comboBoxWithImage1.Items.Add(new ComboBoxWithImage.DropDownItem() { Value = "English (United-States)", Image = PhotoTimeSync.Pics.flag_usa, Tag = "en-US" });
            
            // Search for current language in combobox to select it
            string language = PhotoTimeSync.Properties.Settings.Default.UserLanguage;
            foreach(ComboBoxWithImage.DropDownItem item in comboBoxWithImage1.Items)
            {
                if ((string)item.Tag == language)
                {
                    comboBoxWithImage1.SelectedItem = item;
                    break;
                }
            }

            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "MainForm", "Init", "UserControl GUI Init Done", "");
        }

        private void comboBoxWithImage1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = PhotoTimeSync.Properties.Settings.Default.UserLanguage;
            string newLanguage = (string)((ComboBoxWithImage.DropDownItem)comboBoxWithImage1.SelectedItem).Tag;
            if (language != newLanguage)
            {
                PhotoTimeSync.Properties.Settings.Default.UserLanguage = newLanguage;
                PhotoTimeSync.Properties.Settings.Default.Save();
                PhotoTimeSync.Labels.Labels.Culture = new System.Globalization.CultureInfo(Properties.Settings.Default.UserLanguage);

                // Explore all control of current form and update labels that can be updated to change language
                // (Nota: this is a little optical illusion since some text are not easily updatable by the
                // RefreshLabels method)
                Queue<Control> cntrls = new Queue<Control>();
                foreach (Control cntrl in this.Controls)
                {
                    cntrls.Enqueue(cntrl);
                }
                while (cntrls.Count > 0)
                {
                    Control aCnt = cntrls.Dequeue();
                    RefreshableLabelsUC refreshCntrl = aCnt as RefreshableLabelsUC;
                    if (refreshCntrl != null)
                    {
                        refreshCntrl.RefreshLabels();
                    }
                    foreach (Control cntrl in aCnt.Controls)
                    {
                        cntrls.Enqueue(cntrl);
                    }
                }
            }
        }



    }


}
