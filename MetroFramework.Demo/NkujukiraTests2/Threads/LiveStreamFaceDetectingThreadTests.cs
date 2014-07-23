using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using NkujukiraTests2.Singleton;
namespace Nkujukira.Demo.Threads.Tests
{
    [TestClass()]
    public class LiveStreamFaceDetectingThreadTests
    {
        [TestMethod()]
        public void LiveStreamFaceDetectingThreadConstructorTest()
        {
            Size frame_size = new Size(10, 10);
            Nkujukira.Demo.Singletons.Singleton.HAARCASCADE_FILE_PATH = Singleton.HAARCASCADE_FILE_PATH;
            LiveStreamFaceDetectingThread thread = new LiveStreamFaceDetectingThread(frame_size);
            Assert.IsNotNull(thread);
        }

        [TestMethod()]
        public void LiveStreamFaceDetectingThreadDoWorkTest()
        {
            Size frame_size = new Size(10, 10);
            Nkujukira.Demo.Singletons.Singleton.HAARCASCADE_FILE_PATH = Singleton.HAARCASCADE_FILE_PATH;
            LiveStreamFaceDetectingThread thread = new LiveStreamFaceDetectingThread(frame_size);
            thread.StartWorking();
            Assert.IsTrue(thread.IsRunning());
        }

        [TestMethod()]
        public void LiveStreamFaceDetectingThreadThreadIsDoneTest()
        {
            
        }

        [TestMethod()]
        public void LiveStreamFaceDetectingThreadDetectFacesInFrameTest()
        {
            Size frame_size = new Size(200,200);
            Nkujukira.Demo.Singletons.Singleton.HAARCASCADE_FILE_PATH = Singleton.HAARCASCADE_FILE_PATH;
            LiveStreamFaceDetectingThread thread = new LiveStreamFaceDetectingThread(frame_size);
            Nkujukira.Demo.Singletons.Singleton.LIVE_FRAMES_TO_BE_PROCESSED.Enqueue(Singleton.FACE_PIC);
            bool sucess=thread.DetectFacesInFrame();
            Assert.IsTrue(sucess);
        }
    }
}
