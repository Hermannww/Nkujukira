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
    public class VideoFromFileThreadTests
    {
        [TestMethod()]
        public void VideoFromFileThreadConstructorTest()
        {
            MainWindow main_window = new MainWindow();
            VideoFromFileThread thread = new VideoFromFileThread(Singleton.VIDEO_FILE_PATH);
            Assert.IsNotNull(thread);
        }

        [TestMethod()]
        public void VideoFromFileThreadDoWorkTest()
        {
            MainWindow main_window = new MainWindow();
            VideoFromFileThread thread = new VideoFromFileThread(Singleton.VIDEO_FILE_PATH);
            thread.StartWorking();
            Assert.IsTrue(thread.IsRunning());
        }

        [TestMethod()]
        public void VideoFromFileThreadAddNextFrameToQueueForProcessingTest()
        {
            MainWindow main_window = new MainWindow();
            VideoFromFileThread thread = new VideoFromFileThread(Singleton.VIDEO_FILE_PATH);

            //enqueue test frame
            bool sucess=thread.AddNextFrameToQueueForProcessing();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void VideoFromFileThreadPauseTest()
        {
            MainWindow main_window = new MainWindow();
            VideoFromFileThread thread = new VideoFromFileThread(Singleton.VIDEO_FILE_PATH);
            bool sucess=thread.Pause();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void VideoFromFileThreadRewindOrForwardVideoTest()
        {
            MainWindow main_window = new MainWindow();
            VideoFromFileThread thread = new VideoFromFileThread(Singleton.VIDEO_FILE_PATH);
            bool sucess = thread.RewindOrForwardVideo(100);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void VideoFromFileThreadRequestStopTest()
        {
            MainWindow main_window = new MainWindow();
            VideoFromFileThread thread = new VideoFromFileThread(Singleton.VIDEO_FILE_PATH);
            thread.StartWorking();
            thread.RequestStop();
            Assert.IsFalse(thread.IsRunning());
        }
    }
}
