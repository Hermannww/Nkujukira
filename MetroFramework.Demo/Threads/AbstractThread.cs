using MetroFramework.Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nkujukira.Threads
{
    public abstract class AbstractThread:ThreadInterface
    {
        //VOLATILE BOOL BECOZ MULTIPLE THREADS WILL ACCESS IT
        protected volatile bool running;
        protected volatile bool paused;
        protected BackgroundWorker background_worker;

        //CONSTRUCTOR
        public AbstractThread()
        {
            running                                      = true;
            paused                                       = false;

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



        public void StartWorking()
        {
            running = true;
            paused  = false;
            background_worker.RunWorkerAsync();
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
