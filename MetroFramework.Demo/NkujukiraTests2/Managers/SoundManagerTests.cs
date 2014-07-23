using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Nkujukira.Demo.Managers.Tests
{
    [TestClass()]
    public class SoundManagerTests
    {
        [TestCleanup]
        public void TearDown() 
        {
            SoundManager.StopPlayingSound();
        }

        [TestMethod()]
        public void SoundManagerPlaySoundTest()
        {
            bool sucess = SoundManager.PlaySound();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void SoundManagerStopPlayingSoundTest()
        {
            SoundManager.PlaySound();
            bool sucess = SoundManager.StopPlayingSound();
            Assert.IsTrue(sucess);
        }
    }
}
