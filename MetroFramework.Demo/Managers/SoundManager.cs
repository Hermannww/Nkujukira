using Nkujukira.Demo.Entitities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nkujukira.Demo.Managers
{
    public class SoundManager
    {
        private static String ALARM_SOUND = Application.StartupPath + @"\Resources\Sounds\Siren.mp3";
        private static WMPLib.WindowsMediaPlayer windows_media_player;
        private static String WMP_MODE = "loop";

        public static bool PlaySound()
        {
            try
            {
                if (windows_media_player == null)
                {
                    windows_media_player = new WMPLib.WindowsMediaPlayer();
                    windows_media_player.URL = ALARM_SOUND;
                    windows_media_player.settings.setMode(WMP_MODE, true);
                    windows_media_player.controls.play();
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        public static bool StopPlayingSound()
        {
            try
            {
                if (windows_media_player != null)
                {
                    windows_media_player.controls.stop();
                }
                windows_media_player = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
