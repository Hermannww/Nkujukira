using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NkujukiraTests2.Singleton;
using Nkujukira.Demo.Managers;
using Nkujukira.Demo.Entitities;
using Emgu.CV;
using Emgu.CV.Structure;
namespace Nkujukira.Demo.Threads.Tests
{
    [TestClass()]
    public class FaceRecognitionProgressThreadTests
    {

        [TestMethod()]
        public void FaceRecognitionProgressThreadConstructorTest()
        {
            MainWindow window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.InitializeStuff();
            FaceRecognitionProgressThread thread = new FaceRecognitionProgressThread();
            Assert.IsNotNull(thread);
            thread = null;
        }

        [TestMethod()]
        public void FaceRecognitionProgressThreadDoWorkTest()
        {
            MainWindow window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.InitializeStuff();
            FaceRecognitionProgressThread thread = new FaceRecognitionProgressThread();
            thread.StartWorking();
            Assert.IsTrue(thread.IsRunning());
            thread.RequestStop();
        }

        [TestMethod()]
        public void FaceRecognitionProgressThreadDisplayFaceRecognitionProgressTest()
        {
            MainWindow window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.InitializeStuff();
            FaceRecognitionProgressThread thread = new FaceRecognitionProgressThread();
            FaceRecognitionResult result = new FaceRecognitionResult();
            result.id = 1;
            Image<Bgr, byte>[] faces = { Singleton.FACE_PIC };
            result.identified_perpetrator = new Perpetrator(faces,false,"Male");
            result.match_was_found = false;
            result.original_detected_face = Singleton.FACE_PIC;
            result.similarity = 0.0f;
            thread.face_recognition_result = result;
            bool sucess=thread.DisplayFaceRecognitionProgress(Singleton.FACE_PIC);
        }

    }
}
