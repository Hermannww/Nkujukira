using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public abstract class FaceRecognitionThread : AbstractThread
    {
        //face of the perpetrator to be recognized
        protected Image<Gray, byte> face_to_recognize = null;
        protected Entity perp_or_student              = null;
      
        

        public FaceRecognitionThread(Image<Gray, byte> face_to_recognize)
            : base()
        {
            SLEEP_TIME = 30;
            this.face_to_recognize                    = face_to_recognize;
            this.perp_or_student                      = null;
            
        }
        
        protected abstract void RecognizeFace(Image<Gray, byte> face);

        protected abstract void EnrollFacesToBeComparedAgainst();



    }
}
