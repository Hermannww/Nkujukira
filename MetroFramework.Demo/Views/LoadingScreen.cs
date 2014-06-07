using MetroFramework.Demo.Singletons;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Views
{
    public partial class LoadingScreen : MetroForm
    {
        BackgroundWorker background_worker;
        private string status_text="Processing......";
        public string STATUS_TEXT { get { return status_text; } set { status_text = value; } }

        public LoadingScreen()
        {
            InitializeComponent();
            background_worker = new BackgroundWorker();
            background_worker.DoWork += new DoWorkEventHandler(DoWork);
            background_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            background_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkCompleted);
            background_worker.WorkerReportsProgress = true;
            background_worker.WorkerSupportsCancellation = true;
        }

        public ProgressBar GetProgressBar() 
        {
            return progress_bar;
        }

        private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(100);
            Singleton.MAIN_WINDOW.PauseVideo();
            this.Close();
        }

        
        /// Notification is performed here to the progress bar    
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Here you play with the main UI thread
            progress_bar.Value = e.ProgressPercentage;
            label_status.Text  = STATUS_TEXT + progress_bar.Value.ToString() + "%";
        }

       
        /// Time consuming operations go here </br>
        /// i.e. Database operations,Reporting
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            //NOTE : Never play with the UI thread here...

            //time consuming operation
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                background_worker.ReportProgress(i);

                //If cancel button was pressed while the execution is in progress
                //Change the state from cancellation ---> cancel'ed
                if (background_worker.CancellationPending)
                {
                    e.Cancel = true;
                    background_worker.ReportProgress(0);
                    return;
                }

            }

            //Report 100% completion on operation completed
            background_worker.ReportProgress(100);
        }

        //start doing work
        public void StartWorking()
        {
            background_worker.RunWorkerAsync();
            this.Show();
        }

        //stop doing work
        public void StopWorking() 
        {
            if (background_worker.IsBusy)
            {
                //Stop/Cancel the async operation here
                background_worker.CancelAsync();
            }
        }
    }
}
