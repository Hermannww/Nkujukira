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
    public class LiveDisplayUpdaterTests
    {
        [TestMethod()]
        public void LiveDisplayUpdaterLiveDisplayUpdaterTest()
        {
            MainWindow main_window = new MainWindow();
            LiveDisplayUpdater thread = new LiveDisplayUpdater(main_window.GetReviewFootageImageBox());
            Assert.IsNotNull(thread);
        }

        [TestMethod()]
        public void LiveDisplayUpdaterDoWorkTest()
        {
            MainWindow main_window = new MainWindow();
            LiveDisplayUpdater thread = new LiveDisplayUpdater(main_window.GetReviewFootageImageBox());
            thread.StartWorking();
            Assert.IsNotNull(thread.IsRunning());
        }

        [TestMethod()]
        public void LiveDisplayUpdaterDisplayNextFrameTest()
        {
            MainWindow main_window = new MainWindow();
            LiveDisplayUpdater thread = new LiveDisplayUpdater(main_window.GetReviewFootageImageBox());
            Nkujukira.Demo.Singletons.Singleton.LIVE_FRAMES_TO_BE_DISPLAYED.Enqueue(Singleton.FACE_PIC);
            bool sucess = thread.DisplayNextFrame();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void LiveDisplayUpdaterRequestStopTest()
        {
            MainWindow main_window = new MainWindow();
            LiveDisplayUpdater thread = new LiveDisplayUpdater(main_window.GetReviewFootageImageBox());
            thread.StartWorking();
            thread.RequestStop();
            Assert.IsFalse(thread.IsRunning());
        }      
    }
}
