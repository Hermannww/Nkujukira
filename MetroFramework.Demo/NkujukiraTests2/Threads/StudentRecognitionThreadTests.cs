using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emgu.CV;
using Emgu.CV.Structure;
using NkujukiraTests2.Singleton;
namespace Nkujukira.Demo.Threads.Tests
{
    [TestClass()]
    public class StudentRecognitionThreadTests
    {
        [TestMethod()]
        public void StudentRecognitionThreadStudentRecognitionThreadTest()
        {
            Image<Bgr,byte>[] faces={Singleton.FACE_PIC};
            StudentRecognitionThread thread = new StudentRecognitionThread(faces);
            Assert.IsNotNull(thread);
        }

        [TestMethod()]
        public void StudentRecognitionThreadDoWorkTest()
        {
            Image<Bgr, byte>[] faces={Singleton.FACE_PIC};
            StudentRecognitionThread thread = new StudentRecognitionThread(faces);
            thread.StartWorking();
            Assert.IsTrue(thread.IsRunning());
        }
    }
}
