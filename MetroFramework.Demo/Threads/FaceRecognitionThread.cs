using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Managers;
using System.Windows.Forms;

namespace Nkujukira.Demo.Threads
{
    public abstract class FaceRecognitionThread : AbstractThread
    {
        //face of the perpetrator to be recognized
        protected Image<Bgr, byte> face_to_recognize = null;
        //protected Entity perp_or_student              = null;
      
        

        public FaceRecognitionThread(Image<Bgr, byte> face_to_recognize)
            : base()
        {
            SLEEP_TIME = 30;
            this.face_to_recognize                    = face_to_recognize;
            //this.perp_or_student                      = null;
            
        }
        
        protected abstract void RecognizeFace(Image<Bgr, byte> face);

        protected abstract void EnrollFacesToBeComparedAgainst();



    }
}
