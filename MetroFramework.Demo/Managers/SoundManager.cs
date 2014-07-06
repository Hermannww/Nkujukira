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
        private static String ALARM_SOUND = Application.StartupPath + @"\Resources\Sounds\Siren.mp3";
        private static WMPLib.WindowsMediaPlayer windows_media_player;
        private static String WMP_MODE    = "loop";

        public static void PlaySound() 
        {
            try
            {
                if (windows_media_player == null)
                {
                    windows_media_player = new WMPLib.WindowsMediaPlayer();
                    windows_media_player.URL = ALARM_SOUND;
                    windows_media_player.settings.setMode(WMP_MODE, true);
                    windows_media_player.controls.play();
                }
            }
            catch (Exception) 
            {
            
            }
        }

        public static void StopPlayingSound() 
        {
            if (windows_media_player != null) 
            {
                windows_media_player.controls.stop();
            }
            windows_media_player          = null;
        }
    }
}
