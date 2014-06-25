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
        public static Sound siren = new Sound(ALARM_SOUND);

        public static void PlaySound() 
        {
            if (!Sound.playing_sound)
            {
                Debug.WriteLine("Playing sound");
                siren.PlaySound();
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
