using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NkujukiraTests2.Singleton
{
    public class Singleton
    {
        //I THINK RATHER THAN INITIALIZIN THESE ALL THE TIME IN EACH SEPARATE TEST ITS BETTER TO
        //PLACE THEM IN A SINGLETON TO PROVIDE GLOBAL ACCESS IN EACH TEST
        public const String FACE_PIC_FILE_PATH    = @"C:\Users\ken\Pictures\pics\2.JPG";
        public const String VIDEO_FILE_PATH       = @"C:\Users\ken\Pictures\VDs\video3.mp4";
        public const String HAARCASCADE_FILE_PATH = @"C:\Users\ken\Documents\GitHub\Nkujukira\MetroFramework.Demo\Resources\Haarcascades\haarcascade_frontalface_default.xml";
        public static Image<Bgr, byte> FACE_PIC   = new Image<Bgr, byte>(FACE_PIC_FILE_PATH);
        public static HaarCascade HAARCASCADE     = new HaarCascade(HAARCASCADE_FILE_PATH);
        public static MainWindow MAIN_WINDOW      = new MainWindow();
    }
}
