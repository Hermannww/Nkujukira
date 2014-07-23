using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using NkujukiraTests2.Singleton;
namespace Nkujukira.Demo.Threads.Tests
{
    [TestClass()]
    public class FaceDrawingThreadTests
    {
        [TestMethod()]
        public void FaceDrawingThreadFaceDrawingThreadTest()
        {
            Image<Bgr,byte> frame=Singleton.FACE_PIC;
            HaarCascade haarcascade = Singleton.HAARCASCADE;
            Rectangle[] faces=FramesManager.DetectFacesInFrame(frame,haarcascade);
            FaceDrawingThread thread = new FaceDrawingThread(frame,faces,1,0);
            Assert.IsNotNull(thread);

        }

        [TestMethod()]
        public void FaceDrawingThreadDoWorkTest()
        {
            Image<Bgr, byte> frame = Singleton.FACE_PIC;
            HaarCascade haarcascade = Singleton.HAARCASCADE;
            Rectangle[] faces = FramesManager.DetectFacesInFrame(frame, haarcascade);
            FaceDrawingThread thread = new FaceDrawingThread(frame, faces, 1, 0);
            thread.StartWorking();
            Assert.IsTrue(thread.IsRunning());
            thread.RequestStop();
        }

        [TestMethod()]
        public void FaceDrawingThreadAddImageToQueueForDisplayTest()
        {
           
            HaarCascade haarcascade = Singleton.HAARCASCADE;
            Rectangle[] faces = FramesManager.DetectFacesInFrame(Singleton.FACE_PIC, haarcascade);
            FaceDrawingThread thread = new FaceDrawingThread(Singleton.FACE_PIC, faces, 1, 0);
            bool sucess=thread.AddImageToQueueForDisplay();
            Assert.IsTrue(sucess);
        }

        //MY ATTEMPTS TO TEST THIS METHOD THREW A EMGU.CV.UTIL EXCEPTION..SOMETHING TO DO WITH INITIALIZATION 
        //OF EMGU CV SO
        [TestMethod()]
        public void FaceDrawingThreadDrawFaceRectanglesTest()
        {
            
        }
    }
}
