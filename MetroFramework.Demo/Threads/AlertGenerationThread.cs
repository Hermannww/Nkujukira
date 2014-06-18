using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using Nkujukira.Entities;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public class AlertGenerationThread:AbstractThread
    {
        private Perpetrator identified_perpetrator;
        private SoundPlayingThread sound_player;
        private Student identified_student;
        
        public AlertGenerationThread(Perpetrator identified_perpetrator) :base()
        {
            this.identified_perpetrator=identified_perpetrator;
            this.sound_player = new SoundPlayingThread();
        }

        public AlertGenerationThread(Student identified_student)
            : base()
        {
            this.identified_student = identified_student;
            this.sound_player = new SoundPlayingThread();
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                sound_player.StartWorking();               
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public bool IsAboutSamePerpetrator(Perpetrator perpetrator) 
        {
            return this.identified_perpetrator.id == perpetrator.id;
        }

        public bool IsAboutSameStudent(Student student)
        {
            return this.identified_student.id == student.id;
        }

        public override void ThreadIsDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            DisplayDetails();
        }
       

        public void DisplayDetails() 
        {
            if (identified_perpetrator != null)
            {
                Debug.WriteLine("Displaying details NOW");
                PerpetratorDetailsForm form = new PerpetratorDetailsForm(identified_perpetrator, true);
                form.Show();
                return;
            }
            

        }

        public override bool RequestStop()
        {
            SoundManager.StopPlayingSound();
            return base.RequestStop();
        }
    }
}
