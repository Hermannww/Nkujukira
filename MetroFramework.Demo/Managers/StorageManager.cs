using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Managers
{
    public class StorageManager
    {
        public static bool SaveFrameInAVIFormat(VideoWriter output_writer, Image<Bgr, byte> frame)
        {
            try
            {
                using (frame)
                {
                    output_writer.WriteFrame(frame);
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }

        public static bool CreateFolderIfMissing(String path)
        {
            try
            {
                bool folder_exists = Directory.Exists(path);
                if (!folder_exists)
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
