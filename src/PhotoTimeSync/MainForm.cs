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
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "MainForm", "Init", "Starting PhotoTimeSync", "");
            InitializeComponent();
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "MainForm", "Init", "Main GUI Init Done", "");
            _sync = new PhotoTimeSynchronizer();
            UserControl1 page1 = new UserControl1(_sync);
            page1.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(page1);
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "MainForm", "Init", "UserControl GUI Init Done", "");
        }

        /*
        Image image = null;
        ImageFile imageF = null;
        bool first = true;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                UserControl1 page1 = new UserControl1();
                page1.Dock = DockStyle.Fill;
                panel2.Controls.Clear();
                panel2.Controls.Add(page1);
                
                // Check if textbox has a value
                //if (txtFileNm.Text != String.Empty)
                if (first)
                {
                    image = Image.FromFile("sample.jpg");
                    imageF= ImageFile.FromFile("sample.jpg");
                }
                else
                {
                    image = Image.FromFile("sample2.jpg");
                    imageF = ImageFile.FromFile("sample2.jpg");
                } 
                first = !first;
                // Check if image exists
                if (image != null)
                {
                    //lblDateTime.Text = imageF.Properties[ExifTag.DateTime].Value.ToString();
                    //lblCameraID.Text = imageF.Properties[ExifTag.Model].Value.ToString();
                    this.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("An error occured");
            }
        }
        */
        /*
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (image != null)
            {
                Image imgThumb = null;
                ThumbnailGenerator gen = new ThumbnailGenerator(image.Width, image.Height, panel1.Width, panel1.Height);
                imgThumb = image.GetThumbnailImage(gen.ThumbnailWidth, gen.ThumbnailHeight, null, new IntPtr());
                if (imgThumb != null)
                    e.Graphics.DrawImage(imgThumb, gen.ThumbnailHorizontalOffset, gen.ThumbnailVerticalOffset, gen.ThumbnailWidth, gen.ThumbnailHeight);
            }
        }
        */
    }


}
