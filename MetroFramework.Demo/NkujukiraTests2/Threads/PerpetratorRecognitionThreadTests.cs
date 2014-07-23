using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Nkujukira.Demo.Threads.Tests
{
    [TestClass()]
    public class PerpetratorRecognitionThreadTests
    {
        [TestMethod()]
        public void PerpetratorRecognitionThreadConstructorTest()
        {
            PerpetratorRecognitionThread thread = new PerpetratorRecognitionThread();
            Assert.IsNotNull(thread);
        }

        [TestMethod()]
        public void PerpetratorRecognitionThreadDoWorkTest()
        {
            PerpetratorRecognitionThread thread = new PerpetratorRecognitionThread();
            thread.StartWorking();
            Assert.IsTrue(thread.IsRunning());
        }
    }
}
