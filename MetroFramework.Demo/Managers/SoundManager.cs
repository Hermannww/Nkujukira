using CSCore.Codecs;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Managers
{
    public class SoundManager
    {
        public static void PlaySound(String file_name) 
        {
            using (var source = CodecFactory.Instance.GetCodec(file_name))
            {
                ISoundOut sound_out;
                if (WasapiOut.IsSupportedOnCurrentPlatform)
                {
                    sound_out = new WasapiOut();
                }
                else
                {
                    sound_out = new DirectSoundOut();
                }

                sound_out.Initialize(source);


                sound_out.Play();

                //sound_out.PlaybackState

            }
        }
    }
}
