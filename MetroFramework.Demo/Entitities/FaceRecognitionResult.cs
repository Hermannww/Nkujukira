using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class FaceRecognitionResult
    {

        public int id { get; set; }
        public bool match_was_found { get; set; }
        public Perpetrator identified_perpetrator { get; set; }
        public Student identified_student { get; set; }
        public float similarity { get; set; }
        public Image<Gray, byte> original_detected_face { get; set; }

        public FaceRecognitionResult()
        {
            match_was_found = false;
        }
    }
}
