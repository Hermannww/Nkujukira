using MetroFramework.Demo.Managers;
using Nkujukira.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public class AlertGenerationThread:ThreadSuperClass
    {
        public  String ALARM_SOUND =Application.StartupPath+ @"\Resources\Sounds\Siren.mp3";
        public AlertGenerationThread() 
        {
        
        }

        public override void DoWork()
        {
            try
            {
                if (!paused)
                {
                    SoundManager.PlaySound(ALARM_SOUND);
                }
            }
            catch (Exception) 
            {
            
            }
        }

        public override bool RequestStop(System.Threading.Thread thread)
        {
            return base.RequestStop(thread);
        }
    }
}
