using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nkujukira.Threads
{
    class FaceRecognitionThread:AbstractThread
    {
        private Image<Bgr, byte> face_to_recognize { get; set; }

        public FaceRecognitionThread(Image<Bgr,byte> face_to_recognize)
        {
            this.face_to_recognize = face_to_recognize;
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (running) 
            {
                if (!paused) 
                {
                    RecognizeFace();
                }
            }
        }

        private void RecognizeFace()
        {
            
        }
    }
}
