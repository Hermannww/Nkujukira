using MetroFramework.Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public abstract class AbstractThread:ThreadInterface
    {
        //VOLATILE BOOL BECOZ MULTIPLE THREADS WILL ACCESS IT
        protected bool running= false;
        protected bool paused = false;

        //THE BACKGROUND WORKER
        protected BackgroundWorker background_worker;

        //HOW LONG THIS THREAD SHOULD SLEEP
        protected int SLEEP_TIME = 50;

        //CONSTRUCTOR
        public AbstractThread()
        {
            
            //INITIALIZE BACKGROUND WORKER
            background_worker                            = new BackgroundWorker();
            background_worker.WorkerReportsProgress      = true;
            background_worker.WorkerSupportsCancellation = true;

            //SET UP EVENT HANDLERS FOR THE BACKGROUND WORKER
            background_worker.DoWork += new DoWorkEventHandler(DoWork);
            background_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            background_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ThreadIsDone);
        }

        //CALLED WHEN THE THREAD IS TERMINATING
        public virtual void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e) { }

        //CALLED WHEN THE PROGRESS OF THE THREAD HAS CHANGED
        public virtual void ProgressChanged(object sender, ProgressChangedEventArgs e) { }
        
        //CALLED TO DO WORK IN THE BACKGROUND
        public abstract void DoWork(object sender, DoWorkEventArgs e);

        //METHOD DELEGATE
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        //PROVIDES A THREAD SAFE WAY TO UPDATE THE GUI FROM THIS THREAD
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            //IF AN INVOKE IS REQUIRED FOR THIS CONTROL
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    //INVOKE THE UPDATE OPERATION
                    control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
                }
                else
                {
                    control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
                }
            }
        }

        public virtual void StartWorking()
        {
            //SET SSOME PROPERTIES
            running = true;
            paused  = false;

            //START THE BACKGROUND WORKER
            background_worker.RunWorkerAsync();

            //THIS THREAD SHOULD YIELD TILL THE BACKGROUND WORKER STARTS WORKING
            while (!background_worker.IsBusy) ;
        }

        //CALLED TO CHECK IF THE THREAD IS RUNNING
        public virtual bool IsRunning()
        {
            return running;
        }

        //CALLED INORDER TO PAUSE THE THREAD
        public virtual bool Pause()
        {
            paused = true;
            return true;
        }

        //CALLED INORDER TO RESUME A PAUSED THREAD
        public virtual bool Resume()
        {
            paused = false;
            return true;
        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL OBJECTS HERE
        public virtual bool RequestStop()
        {
            running = false;
            return true;
        }
    }
}
