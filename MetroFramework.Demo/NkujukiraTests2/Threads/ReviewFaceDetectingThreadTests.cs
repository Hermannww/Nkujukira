using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NkujukiraTests2.Singleton;
namespace Nkujukira.Demo.Threads.Tests
{
    [TestClass()]
    public class ReviewFaceDetectingThreadTests
    {
        [TestMethod()]
        public void ReviewFaceDetectingThreadConstructorTest()
        {
            Nkujukira.Demo.Singletons.Singleton.HAARCASCADE_FILE_PATH = Singleton.HAARCASCADE_FILE_PATH;
            ReviewFaceDetectingThread thread = new ReviewFaceDetectingThread(10,10);
            Assert.IsNotNull(thread);
        }

        [TestMethod()]
        public void ReviewFaceDetectingThreadDoWorkTest()
        {
            Nkujukira.Demo.Singletons.Singleton.HAARCASCADE_FILE_PATH = Singleton.HAARCASCADE_FILE_PATH;
            ReviewFaceDetectingThread thread = new ReviewFaceDetectingThread(10, 10);
            thread.StartWorking();
            Assert.IsTrue(thread.IsRunning());
        }


        [TestMethod()]
        public void ReviewFaceDetectingThreadThreadIsDoneTest()
        {
        } 

        [TestMethod()]
        public void ReviewFaceDetectingThreadDetectFacesInFrameTest()
        {
            Nkujukira.Demo.Singletons.Singleton.HAARCASCADE_FILE_PATH = Singleton.HAARCASCADE_FILE_PATH;
            ReviewFaceDetectingThread thread = new ReviewFaceDetectingThread(10, 10);
            Nkujukira.Demo.Singletons.Singleton.REVIEW_FRAMES_TO_BE_PROCESSED.Enqueue(Singleton.FACE_PIC);
            bool sucess= thread.DetectFacesInFrame();
            Assert.IsTrue(sucess);
        }
    }
}
