using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Nkujukira.Demo.Threads.Tests
{
    [TestClass()]
    public class CameraOutputGrabberThreadUsingVideoTests
    {
        [TestMethod()]
        public void CameraOutputGrabberThreadUsingVideoCameraOutputGrabberThreadUsingVideoTest()
        {
            String FILE_NAME = @"C:\Users\ken\Pictures\VDs\video3.mp4";
            CameraOutputGrabberThreadUsingVideo thread = new CameraOutputGrabberThreadUsingVideo(FILE_NAME);
            Assert.IsNotNull(thread);
        }
    }
}
