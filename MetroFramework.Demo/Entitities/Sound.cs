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
        IWavePlayer wave_out_device;
        AudioFileReader audio_file_reader;
        public  Boolean finished_playing = true;

        public void PlaySound(String file_name) 
        {
            try
            {
                finished_playing = false;
                wave_out_device = new WaveOut();
                wave_out_device.PlaybackStopped += wave_out_device_PlaybackStopped;
                audio_file_reader = new AudioFileReader(file_name);
                if (wave_out_device != null&&audio_file_reader!=null)
                {
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
            finished_playing = true;
        }

        public void Stop() 
        {
            try
            {
                if (wave_out_device != null)
                {
                    wave_out_device.Stop(); 
                    audio_file_reader = null;
                    wave_out_device   = null;
                }
            }
            catch (Exception) 
            {
            
            }
        }
    }
}
