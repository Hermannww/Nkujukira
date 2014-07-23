using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Nkujukira.Demo.Threads.Tests
{
    [TestClass()]
    public class StudentAlertThreadTests
    {
        [TestMethod()]
        public void StudentAlertThreadStudentAlertThreadTest()
        {
            StudentAlertThread thread = new StudentAlertThread();
            Assert.IsNotNull(thread);
        }
    }
}
