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
    public class ReviewDisplayUpdaterTests
    {
        [TestMethod()]
        public void ReviewDisplayUpdaterReviewDisplayUpdaterTest()
        {
            MainWindow main_window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.CURRENT_FILE_NAME = Singleton.VIDEO_FILE_PATH;
            ReviewDisplayUpdater thread = new ReviewDisplayUpdater(main_window.GetReviewFootageImageBox());

            Assert.IsNotNull(thread);
        }

        [TestMethod()]
        public void ReviewDisplayUpdaterUpdateTimerLabelTest()
        {
            MainWindow main_window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.CURRENT_FILE_NAME = Singleton.VIDEO_FILE_PATH;
            ReviewDisplayUpdater thread = new ReviewDisplayUpdater(main_window.GetReviewFootageImageBox());

            bool sucess = thread.UpdateTimerLabel(0.00);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void ReviewDisplayUpdaterDoWorkTest()
        {
            MainWindow main_window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.CURRENT_FILE_NAME = Singleton.VIDEO_FILE_PATH;
            ReviewDisplayUpdater thread = new ReviewDisplayUpdater(main_window.GetReviewFootageImageBox());
            thread.StartWorking();
       
            Assert.IsTrue(thread.IsRunning());
        }

        [TestMethod()]
        public void ReviewDisplayUpdaterThreadIsDoneTest()
        {
            
        }

        [TestMethod()]
        public void ReviewDisplayUpdaterSetTimeElapsedTest()
        {
            MainWindow main_window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.CURRENT_FILE_NAME = Singleton.VIDEO_FILE_PATH;
            ReviewDisplayUpdater thread = new ReviewDisplayUpdater(main_window.GetReviewFootageImageBox());
            bool sucess = thread.SetTimeElapsed(0.0f);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void ReviewDisplayUpdaterDisplayNextFrameTest()
        {
            MainWindow main_window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.CURRENT_FILE_NAME = Singleton.VIDEO_FILE_PATH;
            ReviewDisplayUpdater thread = new ReviewDisplayUpdater(main_window.GetReviewFootageImageBox());
            Nkujukira.Demo.Singletons.Singleton.REVIEW_FRAMES_TO_BE_DISPLAYED.Enqueue(Singleton.FACE_PIC);
            bool sucess=thread.DisplayNextFrame();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void ReviewDisplayUpdaterPauseTest()
        {
            MainWindow main_window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.CURRENT_FILE_NAME = Singleton.VIDEO_FILE_PATH;
            ReviewDisplayUpdater thread = new ReviewDisplayUpdater(main_window.GetReviewFootageImageBox());
            bool sucess=thread.Pause();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void ReviewDisplayUpdaterResumeTest()
        {
            MainWindow main_window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.CURRENT_FILE_NAME = Singleton.VIDEO_FILE_PATH;
            ReviewDisplayUpdater thread = new ReviewDisplayUpdater(main_window.GetReviewFootageImageBox());
            bool sucess = thread.Resume();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void ReviewDisplayUpdaterRequestStopTest()
        {
            MainWindow main_window = new MainWindow();
            Nkujukira.Demo.Singletons.Singleton.CURRENT_FILE_NAME = Singleton.VIDEO_FILE_PATH;
            ReviewDisplayUpdater thread = new ReviewDisplayUpdater(main_window.GetReviewFootageImageBox());
            thread.StartWorking();
            thread.RequestStop();
            Assert.IsFalse(thread.IsRunning());
        }
    }
}
