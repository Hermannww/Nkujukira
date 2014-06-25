using NAudio;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Sound
    {
        private IWavePlayer wave_out_device;
        private AudioFileReader audio_file_reader;
        public static volatile bool playing_sound    = false;
        private String file_name;

        public Sound(String file_name) 
        {
            wave_out_device                          = null;
            audio_file_reader                        = null;
            this.file_name                           = file_name;
            
        }

        public void PlaySound()
        {
            try
            {
                if (!playing_sound)
                { 
                    playing_sound                    = true;
                    wave_out_device                  = new WaveOut();
                    wave_out_device.PlaybackStopped += wave_out_device_PlaybackStopped;
                    audio_file_reader                = new AudioFileReader(file_name);
                    wave_out_device.Init(audio_file_reader);
                    wave_out_device.Play();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void wave_out_device_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            Debug.WriteLine("sound is done playing");
            playing_sound                            = false;
        }

        public void Stop()
        {
            try
            {
                if (wave_out_device != null)
                {
                    wave_out_device.Stop();
                }

                audio_file_reader                    = null;
                wave_out_device                      = null;
            }
            catch (Exception)
            {

            }
        }
    }
}
