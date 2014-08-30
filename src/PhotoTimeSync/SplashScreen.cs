using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoTimeSync
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        internal void SetMessage(string message)
        {
            label1.Text = message;
        }

        public delegate void CloseSplashScreen();
        public delegate void UpdateSplashScreen(string msg);
        static SplashScreen newSplashForm;
        static Thread t1;

        public static void ShowSplash()
        {
            newSplashForm = new SplashScreen();
            Thread t1 = new Thread(new ThreadStart(CreateSplashInternal));
            t1.Start();
            while (!newSplashForm.IsHandleCreated)
            {
                System.Threading.Thread.Sleep(10);
            }
        }

        public static void UpdateSplash(string text)
        {
            newSplashForm.Invoke(new UpdateSplashScreen(UpdateSplashInternal), text);
        }

        public static void CloseSplash()
        {
            newSplashForm.Invoke(new CloseSplashScreen(CloseSplashInternal));
            try
            {
                t1.Abort();
            }
            catch
            {
            }
        }

        static void CreateSplashInternal()
        {
            newSplashForm.ShowDialog();
            newSplashForm.Dispose();
        }

        static void CloseSplashInternal()
        {
            newSplashForm.Close();
        }

        static void UpdateSplashInternal(string msg)
        {
            newSplashForm.SetMessage(msg);
        }

    }
}
