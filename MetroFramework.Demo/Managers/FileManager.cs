using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Managers
{
    public class FileManager
    {
        public bool SaveBitmapToFile(String file_path,Bitmap bitmap) 
        {
            try
            {
                bitmap.Save(file_path, ImageFormat.Png);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        public bool DeleteBitmapFile(String file_name)
        {
            return false;
        }
    }
}
