using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Demo.Managers;
using NUnit.Framework;
using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;

namespace MetroFramework.Demo.Managers.Tests
{
    [TestFixture()]
    public class FacesManagerTests
    {
        String Image_Path=@"C:\Users\ken\Documents\GitHub\Nkujukira\MetroFramework.Demo\bin\x86\Debug\Resources\STUDENTS\1\";
        [Test()]
        public void EnrollFacesTest()
        {
            Image<Gray, byte>[] images = { 
                                             new Image<Gray, byte>(Image_Path + "1 0.png"),
                                             new Image<Gray, byte>(Image_Path + "1 1.png"),
                                             new Image<Gray, byte>(Image_Path + "1 2.png"),
                                             new Image<Gray, byte>(Image_Path + "1 3.png"),
                                             new Image<Gray, byte>(Image_Path + "1 4.png"),
                                         };

            Perpetrator perp=new Perpetrator();
            perp.faces=images;

            FacesManager manager = new FacesManager();
            foreach (var image in images) 
            {
                manager.EnrollFaces(perp);
            }

            //Assert.AreEqual(5, manager.known_faces_list.Count);
        }
    }
}
