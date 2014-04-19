using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nkujukira.Threads
{
    public class ThreadSuperClass
    {
        //VOLATILE BOOL BECOZ MULTIPLE THREADS WILL ACCESS IT
        public volatile bool running;
        public volatile bool paused;

        //CONSTRUCTOR
        public ThreadSuperClass()
        {
            running = true;
            paused = false;
        }

        //CALLED WHEN THREAD IS RUNNING
        public virtual void DoWork()
        {
            while (running)
            {
                if (!paused)
                {
                    //DO SOME WORK
                }
            }
        }

        public virtual void Pause()
        {
            paused = true;
        }

        public virtual void Resume()
        {
            paused = false;
        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL CAMERA OBJECTS
        public virtual bool RequestStop(Thread thread)
        {
            running = false;
            thread.Join();
            return true;
        }
    }
}
