using MetroFramework.Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Nkujukira.Threads
{
    public abstract class AbstractThread:ThreadInterface
    {
        //VOLATILE BOOL BECOZ MULTIPLE THREADS WILL ACCESS IT
        protected bool running= false;
        protected bool paused = false;
        protected BackgroundWorker background_worker;

        //CONSTRUCTOR
        public AbstractThread()
        {
            

            background_worker                            = new BackgroundWorker();
            background_worker.WorkerReportsProgress      = true;
            background_worker.WorkerSupportsCancellation = true;

            background_worker.DoWork += new DoWorkEventHandler(DoWork);
            background_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            background_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ThreadIsDone);
        }

        public virtual void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e) { }


        public virtual void ProgressChanged(object sender, ProgressChangedEventArgs e) { }
        

        public abstract void DoWork(object sender, DoWorkEventArgs e);

        //METHOD DELEGATE
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        //PROVIDES A THREAD SAFE WAY TO UPDATE THE GUI FROM THIS THREAD
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            //IF AN INVOKE IS REQUIRED FOR THIS CONTROL
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

        public void StartWorking()
        {
            running = true;
            paused  = false;
            background_worker.RunWorkerAsync();
        }


        public bool IsRunning()
        {
            return running;
        }

        public virtual bool Pause()
        {
            paused = true;
            return true;
        }

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
