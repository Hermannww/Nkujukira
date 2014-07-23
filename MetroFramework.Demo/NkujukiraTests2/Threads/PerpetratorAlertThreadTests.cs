using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace NkujukiraTests2.Threads
{
    public class PerpetratorAlertThreadTests
    {
        [TestMethod()]
        public void PerpetratorAlertThreadConstructorTest()
        {
            PerpetratorAlertThread thread = new PerpetratorAlertThread();

            Assert.IsNotNull(thread);
        }
    }
}
