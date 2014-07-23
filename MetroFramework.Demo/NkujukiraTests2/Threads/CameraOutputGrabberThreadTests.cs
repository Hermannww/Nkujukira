using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Nkujukira.Demo.Threads.Tests
{
    [TestClass()]
    public class CameraOutputGrabberThreadTests
    {
        [TestMethod()]
        public void CameraOutputGrabberThreadConstructorTest()
        {
            CameraOutputGrabberThread thread = new CameraOutputGrabberThread();
            Assert.IsNotNull(thread);
        }

        [TestMethod()]
        public void CameraOutputGrabberThreadDoWorkTest()
        {
            CameraOutputGrabberThread thread = new CameraOutputGrabberThread();
            thread.StartWorking();
            Assert.IsTrue(thread.IsRunning());
        }

        [TestMethod()]
        public void CameraOutputGrabberThreadAddNextFrameToQueuesForProcessingTest()
        {
            CameraOutputGrabberThread thread = new CameraOutputGrabberThread();
            MainWindow window = new MainWindow();
            bool sucess = thread.AddNextFrameToQueuesForProcessing();
            Assert.IsTrue(sucess);
        }
    }
}

