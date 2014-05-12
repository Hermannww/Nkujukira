using CSCore.Codecs;
using CSCore.SoundOut;
using MetroFramework.Demo.Entitities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo.Managers
{
    public class SoundManager
    {
        public static String ALARM_SOUND = Application.StartupPath + @"\Resources\Sounds\Siren.mp3";
        public static Sound siren = new Sound();
        public static void PlaySound() 
        {
            Debug.WriteLine("FILE_NAME=" + ALARM_SOUND);
            if (siren.finished_playing)
            {
                siren.PlaySound(ALARM_SOUND);
            }
        }

        public static void StopPlayingSound() 
        {
            if (siren != null) 
            {
                siren.Stop();
            }
        }
    }
}
